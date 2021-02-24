using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoVC_Form
{
    public partial class VCPumps : Form
    {
        Collection cryptos = new Collection();
        Hash hash = new Hash();

        public DateTime time = new DateTime();
        TimeSpan waitTime = new TimeSpan();
        List<Tuple<string, double>> prices = new List<Tuple<string, double>>();
        public List<string> newList = new List<string>();
        public double priceBase = 0;
        public double priceScale = 0;
        public double btcPrice = 0;
        public double ethPrice = 0;
        public double marketCapPrice = 0;
        int type = 0;
        int price = 2;

        public VCPumps()
        {
            InitializeComponent();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            time = dateTimePicker.Value;
            dateTimeCalander.SetDate(time);
            dateTimeCalander.SetSelectionRange(time, time);
        }

        private void dateTimeCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            time = dateTimeCalander.SelectionRange.Start;
            dateTimePicker.Value = time;
        }

        private void beginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                marketCapPrice = double.Parse(marketCapTxt.Text);
            }
            catch { }

            //BackgroundWorker worker = new BackgroundWorker();
            if (time > DateTime.Now)
            {
                waitTime = time - DateTime.Now;
            }
            if (btcRadio.Checked)
                type = 0;
            if (ethRadio.Checked)
                type = 1;
            if (tenPlusRadio.Checked)
                price = 0;
            if (underTenRadio.Checked)
                price = 1;
            if (underOneRadio.Checked)
                price = 2;

            textBox4.Text = hash.EncodeBase64(time, type, price, marketCapPrice);
            //worker.DoWork += Worker_DoWork;
            //worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            //worker.ProgressChanged += Worker_ProgressChanged;
            //worker.WorkerReportsProgress = true;
            //worker.RunWorkerAsync();

            countdownTimer.Enabled = true;
            beginBtn.Enabled = false;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            Collection cryptos = new Collection();

            countdownTimerLbl.Text = "Countdown: " + waitTime.ToString(@"dd\:hh\:mm\:ss");//\.ff");
            waitTime = time - DateTime.Now; //Currently has a 200ms delay which means if another transaction goes through in that time there could be different coins chosen.

            if (waitTime.TotalSeconds < 1)
            {
                countdownTimer.Enabled = false;
                waitTime -= waitTime;

                if (btcRadio.Checked)
                    prices = cryptos.BinanceCoins("BTC");
                else if (ethRadio.Checked)
                    prices = cryptos.BinanceCoins("ETH");

                if (tenPlusRadio.Checked)
                {
                    priceBase = 10;
                    priceScale = double.MaxValue;
                }
                else if (underTenRadio.Checked)
                {
                    priceBase = 1;
                    priceScale = 10;
                }
                else
                {
                    priceBase = double.MinValue;
                    priceScale = 1;
                }

                btcPrice = cryptos.btcPrice;
                ethPrice = cryptos.ethPrice;

                btcPriceLbl.Text = String.Format("Bitcoin Price: {0}", btcPrice.ToString());
                ethPriceLbl.Text = String.Format("Etherium Price: {0}", ethPrice.ToString());

                foreach (var token in prices)
                {
                    if (btcRadio.Checked)
                    {
                        if (token.Item2 > priceBase / btcPrice && token.Item2 < priceScale / btcPrice)
                        {
                            {
                                cryptos.rollCryptos.Add(token.Item1);
                                textBox1.Text += String.Format("{0} | {1}", token.Item1, token.Item2) + Environment.NewLine;
                            }
                        }
                    }
                    else if (ethRadio.Checked)
                    {
                        if (token.Item2 > priceBase / ethPrice && token.Item2 < priceScale / ethPrice)
                        {
                            cryptos.rollCryptos.Add(token.Item1);
                            textBox1.Text += String.Format("{0} | {1}", token.Item1, token.Item2) + Environment.NewLine;
                        }
                    }
                }
            }
            if (waitTime.TotalSeconds < 1)
            {
                //newList = cryptos.rollCryptos;
                textBox1.Clear();
                cryptos.CoinbaseMarket(marketCapPrice);
                int i = 0;
                foreach (var v in cryptos.newList)
                    textBox1.Text +=String.Format("({0}): {1}" + Environment.NewLine, i++, v);
                coinLbl.Text = String.Format("Selected: {0}", cryptos.SelectCoin());
                textBox2.Text = String.Format("Seed used: {0}\r\nTXID: {1}\r\nRecieved Time: {2} ", cryptos.rSeed, cryptos.rHash, cryptos.rTime);
                rollLbl.Text = "Rolled: " + cryptos.roll;
                coinCountLbl.Text = cryptos.newList.Count.ToString();
            }
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            Verify verify = new Verify();
            verify.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cryptos.CoinbaseMarket(marketCapPrice);
            textBox3.Text = newList.Count.ToString() + Environment.NewLine;
            foreach (var v in cryptos.marketCap)
                if(v.Item1 != "ETH" && v.Item1 != "BTC")
                    if(newList.Contains(string.Concat(v.Item1, "BTC")) || newList.Contains(string.Concat(v.Item1, "ETH")))
                        textBox3.Text += v.Item1 + " | " + v.Item2 + Environment.NewLine;//textBox3.Text += v + Environment.NewLine;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            base64Btn.Enabled = true;
        }

        private void base64Btn_Click(object sender, EventArgs e)
        {
            int current = 0;
            string settings = hash.DecodeBase64(textBox4.Text);
            foreach(string setting in settings.Split('|'))
            {
                switch (current)
                {
                    case 0:
                        time = DateTime.FromFileTimeUtc(long.Parse(setting));
                        dateTimeCalander.SetDate(time);
                        dateTimeCalander.SetSelectionRange(time, time);
                        dateTimePicker.Value = time;
                        break;
                    case 1:
                        if (int.Parse(setting) == 0)
                            btcRadio.Checked = true;
                        else if (int.Parse(setting) == 1)
                            ethRadio.Checked = true;
                        break;
                    case 2:
                        if (int.Parse(setting) == 0)
                            tenPlusRadio.Checked = true;
                        else if (int.Parse(setting) == 1)
                            underTenRadio.Checked = true;
                        else if (int.Parse(setting) == 2)
                            underOneRadio.Checked = true;
                        break;
                    case 3:
                        marketCapPrice = double.Parse(setting);
                        marketCapTxt.Text = marketCapPrice.ToString();
                        break;
                }

                current++;
            }
        }
    }
}