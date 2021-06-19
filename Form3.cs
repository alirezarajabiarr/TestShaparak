using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestShaparak
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            ds.ReadXml("E:/TestShaparak/ct.txt");
            var allAmount = ds.Tables["TtlIntrBkSttlmAmt"].Rows[0].ItemArray[1].ToString();
            long amount = 0;
            foreach (DataRow item in ds.Tables["IntrBkSttlmAmt"].Rows)
            {
                amount += long.Parse(item[1].ToString());//riz tasvih

                var s = ds.Tables["RmtInf"].Select(" CdtTrfTxInf_Id = " + item[2].ToString());
                if (s.Length > 0)
                {
                   var acceptor = s[0].ItemArray[0].ToString().Substring(s[0].ItemArray[0].ToString().Length-15,15);
                    var amountKoli = item[1].ToString();
                    var wageAmount = 30000;
                    var WageP = Math.Ceiling(decimal.Parse(amountKoli) * 5 /100);
                    var amountkhodmon = long.Parse(amountKoli) - WageP;
                }
                
            }





        }
    }
}
