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

        public DateTime time = new DateTime();
        TimeSpan waitTime = new TimeSpan();
        List<Tuple<string, double>> prices = new List<Tuple<string, double>>();
        public double priceBase = 0;
        public double priceScale = 0;
        public double btcPrice = 0;
        public double ethPrice = 0;

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
            //BackgroundWorker worker = new BackgroundWorker();
            if (time > DateTime.Now)
            {
                waitTime = time - DateTime.Now;
            }

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
            waitTime = waitTime.Subtract(new TimeSpan(0,0,0,0,200)); //Currently has a 200ms delay which means if another transaction goes through in that time there could be different coins chosen.

            if (waitTime.TotalSeconds < 1.5)
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
            if (waitTime.TotalSeconds < 1.5)
            {
                coinLbl.Text = String.Format("Selected: {0}", cryptos.SelectCoin());
                textBox2.Text = String.Format("Seed used: {0}\r\nTXID: {1} ", cryptos.rSeed, cryptos.rHash);
                rollLbl.Text = "Rolled: " + cryptos.roll;
                coinCountLbl.Text = cryptos.rollCryptos.Count.ToString();
            }
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            Verify verify = new Verify();
            verify.Show();
        }
    }
}