using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestShaparak.Extention;
using TestShaparak.Models;

namespace TestShaparak
{
    public partial class Form1 : Form
    {
        public List<ShaparakRequest> person { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //time span

            //person = Person.Instance.FillAllData3();
            person = Person.Instance.FillAllDatamainChange();
            //var x = (ShaparakRequest)Extention.Extra.DeepCopy(person);
            //x.merchant.firstNameFa = "ahamad";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var x = (List<ShaparakRequest>)Extention.Extra.DeepCopy(person);
                x[0].requestType = RequstTypeEnum.DefineMerchant;
                var engineResponse = Environments.Environments.Instance.CallServiceString<List<ShaparakRequest>>(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var postalCode = "1516714414";
                var x = (List<ShaparakRequest>)Extention.Extra.DeepCopy(person);
                x[0].requestType = RequstTypeEnum.DefineShop;
                x[0].pspRequestShopAcceptors[0].acceptors.Clear();
                x[0].contract = null;
                x[0].pspRequestShopAcceptors[0].shop = new Shop
                {
                    taxPayerCode = "1234567891",
                    farsiName = "فروشگاه دوم",
                    englishName = "secend shop",
                    telephoneNumber = "021-44589814",
                    postalCode = postalCode,
                    businessCategoryCode = "5812",
                    businessSubCategoryCode = "0",
                    countryCode = "IR",// just Ir
                    businessType = BusinessTypeEnum.FisikiMajazi,
                    websiteAddress = "https://faraboom.com",
                    emailAddress = "faraboom2@gmail.com",
                };

                var engineResponse = Environments.Environments.Instance.CallServiceString<List<ShaparakRequest>>(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //var setelment = Person.Instance.FillFileSettelment();

            //var filename = "TFMF_" + PersianDateHelper.Instance.ConvertToPersianDate(DateTime.Now).Replace("/", "").Trim() + "_01.json";//01 sikl shparak
            //var signFile = filename + ".sign";

            //using (StreamWriter sw = new StreamWriter("E:/Boom/Files/" + filename, false))
            //{
            //    sw.WriteLine(setelment.SerializeDataContractAsJsonString());
            //}
            //var privateKeys = "";
            //var xw = new RSAParameters { };

            //RSA rsa = RSA.Create();

            //using (var sr = new StreamReader("E:/Boom/Files/PrivateKeyXml.txt"))
            //{
            //    privateKeys = sr.ReadToEnd();
            //    rsa.FromXmlString(privateKeys);
            //}
            //SignWrite(setelment.SerializeDataContractAsJsonString(), rsa.ExportParameters(true), "E:/Boom/Files/" + signFile);




            ////////////////////////////
            var setelment = Person.Instance.FillFileSettelmentOk();
            setelment = Person.Instance.FillFileSettelmentNotOk1();
            setelment = Person.Instance.FillFileSettelmentNotOk2();
            var filename = "TFMF_" + PersianDateHelper.Instance.ConvertToPersianDate(DateTime.Now).Replace("/", "").Trim() + "_01_NOK1" + ".txt";//01 sikl shparak
            filename = "TFMF_" + PersianDateHelper.Instance.ConvertToPersianDate(DateTime.Now).Replace("/", "").Trim() + "_01_NOK2" + ".txt";//01 sikl shparak
            filename = "TFMF_" + PersianDateHelper.Instance.ConvertToPersianDate(DateTime.Now).Replace("/", "").Trim() + "_01_OK" + ".txt";//01 sikl shparak
            var signFile = "TFMF_" + PersianDateHelper.Instance.ConvertToPersianDate(DateTime.Now).Replace("/", "").Trim() + "sign.txt";

            using (StreamWriter sw = new StreamWriter("E:/TestShaparak/" + filename, false))
            {
                sw.WriteLine(setelment.SerializeDataContractAsJsonString());
            }


            var privateKeys = "";
            var xw = new RSAParameters { };

            RSA rsa = RSA.Create();

            using (var sr = new StreamReader("E:/Boom/Files/PrivateKeyXml.txt"))
            {
                privateKeys = sr.ReadToEnd();
                rsa.FromXmlString(privateKeys);
            }
            using (var sr = new StreamReader("E:/Boom/Files/" + filename))
            {
                SignWrite(sr.ReadToEnd(), rsa.ExportParameters(true), "E:/Boom/Files/" + signFile);
            }


        }


        public static string SignData(string message, RSAParameters privateKey)
        {
            //// The array to store the signed message in bytes
            byte[] signedBytes;
            using (var rsa = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(message);

                try
                {
                    //// Import the private key used for signing the message
                    rsa.ImportParameters(privateKey);

                    //// Sign the data, using SHA512 as the hashing algorithm 
                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA256"));
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally
                {
                    //// Set the keycontainer to be cleared when rsa is garbage collected.
                    rsa.PersistKeyInCsp = false;
                }
            }
            //// Convert the a base64 string before returning
            //string yourByteString = Convert.ToString(signedBytes, 2).PadLeft(8, '0');
            string[] b = signedBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
            //string ret = "";
            //foreach (var item in b)
            //{
            //    ret += item;
            //}
            //return ret;
            return Convert.ToBase64String(signedBytes);
        }

        public static string SignData1(string message, RSAParameters privateKey)
        {


            // Display the strings created before and after the conversion.
            //var xxc = Encoding.GetEncoding("EUC-KR").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes("salam"));
            //var xx = Encoding.GetEncoding("CP949").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes("salam"));

            //string test = "敭畳灴獩楫n"; //incoming data. must be mesutpiskin 

            //byte[] bytes = Encoding.Unicode.GetBytes(test);

            //string s = string.Empty;

            //for (int i = 0; i < bytes.Length; i++)
            //{
            //    s += (char)bytes[i];
            //}








            //// The array to store the signed message in bytes
            byte[] signedBytes;
            using (var rsa = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                Encoding window1252 = Encoding.GetEncoding("Windows-1252");
                //byte[] originalData = window1252.GetBytes(message);
                byte[] originalData = encoder.GetBytes(message);
                try
                {
                    //// Import the private key used for signing the message
                    rsa.ImportParameters(privateKey);

                    //// Sign the data, using SHA512 as the hashing algorithm 
                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA256"));
                    string decodedText = encoder.GetString(signedBytes);
                    string decodedText2 = window1252.GetString(signedBytes);
                    return decodedText;
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally
                {
                    //// Set the keycontainer to be cleared when rsa is garbage collected.
                    rsa.PersistKeyInCsp = false;
                }
            }
            //// Convert the a base64 string before returning
            //string yourByteString = Convert.ToString(signedBytes, 2).PadLeft(8, '0');
            string[] b = signedBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
            //string ret = "";
            //foreach (var item in b)
            //{
            //    ret += item;
            //}
            //return ret;
            return Convert.ToBase64String(signedBytes);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 open = new Form2();
            open.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var x = (List<ShaparakRequest>)Extention.Extra.DeepCopy(person);
                x[0].requestType = RequstTypeEnum.ChangeIban;
                x[0].pspRequestShopAcceptors[0].acceptors[0].terminals = null;
                x[0].merchant.merchantIbans = new List<MerchantIban> { new MerchantIban { merchantIban = "IR880560085602002134463001" } };
                x[0].pspRequestShopAcceptors[0].acceptors[0].shaparakSettlementIbans[0] = "IR880560085602002134463001";
                //x[0].pspRequestShopAcceptors[0].acceptors[0].[0] = "IR330560085680002134463001";
                var engineResponse = Environments.Environments.Instance.CallServiceString<List<ShaparakRequest>>(x);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //109106846127908

            var request = new ShaparakTrackingRequest { trackingNumbers = new List<string> { textBox1.Text } };
            var engineResponse = Environments.Environments.Instance.CallServiceTracking<ShaparakTrackingRequest>(request);
            textBox2.Text = engineResponse;
            var data = engineResponse.DeserializeFromJsonString<List<TrackingResponses>>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //101068462359305
            try
            {
                var x = (List<ShaparakRequest>)Extention.Extra.DeepCopy(person);

                x[0].pspRequestShopAcceptors[0].acceptors[0].shaparakSettlementIbans[0] = "IR";
                x[0].requestType = RequstTypeEnum.DisableTerminal;
                x[0].pspRequestShopAcceptors[0].acceptors[0].shaparakSettlementIbans.Clear();
                x[0].merchant.merchantIbans.Clear();

                var engineResponse = Environments.Environments.Instance.CallServiceString<List<ShaparakRequest>>(x);
                var data = engineResponse.DeserializeFromJsonString<List<ShaparakResponse>>();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var x = (List<ShaparakRequest>)Extention.Extra.DeepCopy(person);

                x[0].requestType = RequstTypeEnum.EnableTerminal;
                x[0].pspRequestShopAcceptors[0].acceptors[0].shaparakSettlementIbans.Clear();
                x[0].merchant.merchantIbans.Clear();

                var engineResponse = Environments.Environments.Instance.CallServiceString<List<ShaparakRequest>>(x);
            }
            catch (Exception)
            {

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var postalCode = "8459143344";
                var x = (List<ShaparakRequest>)Extention.Extra.DeepCopy(person);
                x[0].requestType = RequstTypeEnum.ChangeShop;

                x[0].pspRequestShopAcceptors[0].shop = new Shop
                {
                    farsiName = "فروشگاه سوم",
                    englishName = "secend shop",
                    telephoneNumber = "021-44589814",
                    postalCode = postalCode,
                    businessCategoryCode = "5812",
                    businessSubCategoryCode = "0",
                    countryCode = "IR",// just Ir
                    businessType = BusinessTypeEnum.FisikiMajazi,
                    websiteAddress = "https://faraboom.com",
                    emailAddress = "faraboom2@gmail.com",
                    updateAction = UpdateActionEnum.Edit,
                    taxPayerCode = "1234567891",
                };
                x[0].pspRequestShopAcceptors[0].acceptors[0].shaparakSettlementIbans.Clear();
                x[0].merchant.merchantIbans.Clear();
                x[0].pspRequestShopAcceptors[0].acceptors[0].terminals.Clear();
                //x[0].merchant.merchantIbans.Clear();
                x[0].pspRequestShopAcceptors[0].acceptors[0].terminals = null;
                var engineResponse = Environments.Environments.Instance.CallServiceString<List<ShaparakRequest>>(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var postalCode = "8459143344";
                var x = (List<ShaparakRequest>)Extention.Extra.DeepCopy(person);
                x[0].requestType = RequstTypeEnum.Edit;
                //x[0].pspRequestShopAcceptors[0].acceptors.Clear();
                //x[0].contract = null;
                x[0].pspRequestShopAcceptors[0].shop = new Shop
                {
                    farsiName = "فروشگاه سوم2",
                    englishName = "secend shop2",
                    telephoneNumber = "021-44589814",
                    postalCode = postalCode,
                    businessCategoryCode = "5812",
                    businessSubCategoryCode = "0",
                    countryCode = "IR",// just Ir
                    businessType = BusinessTypeEnum.FisikiMajazi,
                    websiteAddress = "https://faraboom.com",
                    emailAddress = "faraboom2@gmail.com",
                    updateAction = UpdateActionEnum.Edit,
                    taxPayerCode = "1234567891",


                };
                x[0].pspRequestShopAcceptors[0].acceptors[0].shaparakSettlementIbans.Clear();
                x[0].merchant.merchantIbans.Clear();
                var engineResponse = Environments.Environments.Instance.CallServiceString<List<ShaparakRequest>>(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button12_Click(object sender, EventArgs e)
        {
            Form3 oo = new Form3();
            oo.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var privateKeys = "";
            var xw = new RSAParameters { };

            RSA rsa = RSA.Create();

            using (var sr = new StreamReader("E:/Boom/Files/PrivateKeyXml.txt"))
            {
                privateKeys = sr.ReadToEnd();
                rsa.FromXmlString(privateKeys);
            }
            //using (StreamWriter sw = new StreamWriter("E:/Boom/Files/SignFileByApp.txt", false))
            //{
            using (var sr = new StreamReader("E:/Boom/Files/TestFile.txt"))
            {
                var data1 = sr.ReadToEnd();
                SignWrite(data1, rsa.ExportParameters(true), "E:/Boom/Files/SignFileByApp1.txt");
                //sw.Write(xx.Trim());
            }


        }

        public static void SignWrite(string message, RSAParameters privateKey, string fileAddress)
        {
            //// The array to store the signed message in bytes
            byte[] signedBytes;
            using (var rsa = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(message);
                try
                {
                    //// Import the private key used for signing the message
                    rsa.ImportParameters(privateKey);

                    //// Sign the data, using SHA512 as the hashing algorithm 
                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA256"));
                    File.WriteAllBytes(fileAddress, signedBytes);
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //// Set the keycontainer to be cleared when rsa is garbage collected.
                    rsa.PersistKeyInCsp = false;
                }
            }

        }

        static byte[] Sign(string text, string certSubject)
        {
            X509Store my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);

            RSACryptoServiceProvider csp = null;
            foreach (X509Certificate2 cert in my.Certificates)
            {
                if (cert.Subject.Contains(certSubject))
                {
                    csp = (RSACryptoServiceProvider)cert.PrivateKey;
                    break;
                }
            }

            SHA1Managed sha1 = new SHA1Managed();
            byte[] data = Encoding.ASCII.GetBytes(text);
            byte[] hash = sha1.ComputeHash(data);

            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // OpenSSL.Crypto.RSA s = new OpenSSL.Crypto.RSA()


        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
