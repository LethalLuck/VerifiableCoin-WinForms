using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoVC_Form
{
    public partial class Verify : Form
    {
        string result = String.Empty;
        DateTime checkTime = new DateTime();

        public Verify(DateTime test)
        {
            InitializeComponent();
            checkTime = test.ToUniversalTime();
            seedTxt.Text = checkTime.ToString();
            long unixTime = ((DateTimeOffset)checkTime).ToUnixTimeSeconds();
            txIDTxt.Text = String.Format("https://beacon.nist.gov/beacon/2.0/pulse/time/{0}000", unixTime);
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            Regex randomVal = new Regex("\"localRandomValue\" : \"([a-zA-Z0-9]*)\"");
            Regex timestamp = new Regex("\"timeStamp\" : \"([0-9]*-[0-9]*-[0-9]*T[0-9]*:[0-9]*:[0-9]*.[0-9]*Z)\"");

            try
            {
                if (coinAmountTxt.Text == "")
                {
                    MessageBox.Show("Don't forget to input coin amount to get the correct roll!");
                    return;
                }

                WebRequest request = WebRequest.Create(txIDTxt.Text);
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
                textBox1.Text = result;

                var rValue = randomVal.Match(result).Groups[1].Value;
                var rSeed = rValue.Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "");
                rSeed = rSeed.Substring(rSeed.Count() - 7);
                var rTime = timestamp.Match(result).Groups[1].Value;

                seedLblMatch.Text = String.Format("Seed: {0}", rSeed);
                tsLblMatch.Text = String.Format("Timestamp: {0}", rTime);
                Random random = new Random(Int32.Parse(rSeed));
                rollLbl.Text = random.Next(0, int.Parse(coinAmountTxt.Text) - 1).ToString();
            }
            catch { }
        }
    }
}
