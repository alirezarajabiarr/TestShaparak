using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestShaparak.Models
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
            ExportPrivateKey(RSA);


        }



        //public static string ExportPrivateKey(RSACryptoServiceProvider csp)
        //{
        //    StringWriter outputStream = new StringWriter();
        //    if (csp.PublicOnly) throw new ArgumentException("CSP does not contain a private key", "csp");
        //    var parameters = csp.ExportParameters(true);
        //    using (var stream = new MemoryStream())
        //    {
        //        var writer = new BinaryWriter(stream);
        //        writer.Write((byte)0x30); // SEQUENCE
        //        using (var innerStream = new MemoryStream())
        //        {
        //            var innerWriter = new BinaryWriter(innerStream);
        //            EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
        //            EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
        //            EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
        //            EncodeIntegerBigEndian(innerWriter, parameters.D);
        //            EncodeIntegerBigEndian(innerWriter, parameters.P);
        //            EncodeIntegerBigEndian(innerWriter, parameters.Q);
        //            EncodeIntegerBigEndian(innerWriter, parameters.DP);
        //            EncodeIntegerBigEndian(innerWriter, parameters.DQ);
        //            EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
        //            var length = (int)innerStream.Length;
        //            EncodeLength(writer, length);
        //            writer.Write(innerStream.GetBuffer(), 0, length);
        //        }

        //        var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
        //        // WriteLine terminates with \r\n, we want only \n
        //        outputStream.Write("-----BEGIN RSA PRIVATE KEY-----\n");
        //        // Output as Base64 with lines chopped at 64 characters
        //        for (var i = 0; i < base64.Length; i += 64)
        //        {
        //            outputStream.Write(base64, i, Math.Min(64, base64.Length - i));
        //            outputStream.Write("\n");
        //        }
        //        outputStream.Write("-----END RSA PRIVATE KEY-----");
        //    }

        //    return outputStream.ToString();
        //}
        private static void ExportPrivateKey(RSACryptoServiceProvider csp)
        {
            
            var privateKeyBytes = csp.ExportCspBlob(true);
            string str = csp.ToXmlString(true);//private key
            string str2 = csp.ToXmlString(false);//public key

            //var parameters = csp.ExportParameters(true);
            //textBox1.Text = str;
            //textBox2.Text = str2;
            using (StreamWriter sw = new StreamWriter("E:/TestShaparak/PrivateKeyXml.txt", false))
            {
                
                sw.WriteLine(str);
            }
            using (StreamWriter sw = new StreamWriter("E:/TestShaparak/publicKeyXml.txt", false))
            {

                sw.WriteLine(str2);
            }

            var builder = new StringBuilder("-----BEGIN RSA PRIVATE KEY");
            builder.AppendLine("-----");

            var base64PrivateKeyString = Convert.ToBase64String(privateKeyBytes);
            var offset = 0;
            const int LINE_LENGTH = 64;

            while (offset < base64PrivateKeyString.Length)
            {
                var lineEnd = Math.Min(offset + LINE_LENGTH, base64PrivateKeyString.Length);
                builder.AppendLine(base64PrivateKeyString.Substring(offset, lineEnd - offset));
                offset = lineEnd;
            }

            builder.Append("-----END RSA PRIVATE KEY");
            builder.AppendLine("-----");
            var xxxx=  builder.ToString();









            if (csp.PublicOnly) throw new ArgumentException("CSP does not contain a private key", "csp");
            var parameters = csp.ExportParameters(true);

            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); // SEQUENCE
                using (var innerStream = new MemoryStream())
                {
                    var xd = Convert.ToBase64String(parameters.Modulus);
                    var innerWriter = new BinaryWriter(innerStream);
                    EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                    EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                    EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
                    EncodeIntegerBigEndian(innerWriter, parameters.D);
                    EncodeIntegerBigEndian(innerWriter, parameters.P);
                    EncodeIntegerBigEndian(innerWriter, parameters.Q);
                    EncodeIntegerBigEndian(innerWriter, parameters.DP);
                    EncodeIntegerBigEndian(innerWriter, parameters.DQ);
                    EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
                using (StreamWriter sw =new StreamWriter("E:/TestShaparak/pem.txt", false))
                {
                    sw.WriteLine("-----BEGIN RSA PRIVATE KEY-----");
                    // Output as Base64 with lines chopped at 64 characters
                    for (var i = 0; i < base64.Length; i += 64)
                    {
                        sw.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                    }
                    sw.WriteLine("-----END RSA PRIVATE KEY-----");
                }
                //outputStream.WriteLine("-----BEGIN RSA PRIVATE KEY-----");
                //// Output as Base64 with lines chopped at 64 characters
                //for (var i = 0; i < base64.Length; i += 64)
                //{
                //    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                //}
                //outputStream.WriteLine("-----END RSA PRIVATE KEY-----");
            }
        }

        private static void EncodeLength(BinaryWriter stream, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "Length must be non-negative");
            if (length < 0x80)
            {
                // Short form
                stream.Write((byte)length);
            }
            else
            {
                // Long form
                var temp = length;
                var bytesRequired = 0;
                while (temp > 0)
                {
                    temp >>= 8;
                    bytesRequired++;
                }
                stream.Write((byte)(bytesRequired | 0x80));
                for (var i = bytesRequired - 1; i >= 0; i--)
                {
                    stream.Write((byte)(length >> (8 * i) & 0xff));
                }
            }
        }

        private static void EncodeIntegerBigEndian(BinaryWriter stream, byte[] value, bool forceUnsigned = true)
        {
            stream.Write((byte)0x02); // INTEGER
            var prefixZeros = 0;
            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] != 0) break;
                prefixZeros++;
            }
            if (value.Length - prefixZeros == 0)
            {
                EncodeLength(stream, 1);
                stream.Write((byte)0);
            }
            else
            {
                if (forceUnsigned && value[prefixZeros] > 0x7f)
                {
                    // Add a prefix zero to force unsigned if the MSB is 1
                    EncodeLength(stream, value.Length - prefixZeros + 1);
                    stream.Write((byte)0);
                }
                else
                {
                    EncodeLength(stream, value.Length - prefixZeros);
                }
                for (var i = prefixZeros; i < value.Length; i++)
                {
                    stream.Write(value[i]);
                }
            }
        }
    }
}
