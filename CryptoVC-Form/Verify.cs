using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoVC_Form
{
    public partial class Verify : Form
    {
        string result = String.Empty;

        public Verify()
        {
            InitializeComponent();
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random(Int32.Parse(seedTxt.Text));
                rollLbl.Text = random.Next(0, int.Parse(coinAmountTxt.Text) - 1).ToString();

                WebRequest request = WebRequest.Create(txIDTxt.Text);
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
                textBox1.Text = result;
            }
            catch { }
        }
    }
}
