using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoVC_Form
{
    public partial class VCPumps : Form
    {
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
            if (time > DateTime.Now)
            {
                waitTime = time - DateTime.Now;
            }
            countdownTimer.Enabled = true;
            beginBtn.Enabled = false;
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            Collection cryptos = new Collection();

            countdownTimerLbl.Text = "Countdown: " + waitTime.ToString(@"hh\:mm\:ss");
            waitTime = waitTime.Subtract(new TimeSpan(2500000)); //Currently has a 250ms delay which means if another transaction goes through in that time there could be different coins chosen.

            if (waitTime.TotalSeconds < 1)
            {
                countdownTimer.Enabled = false;

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
                        if (token.Item2 > priceBase / btcPrice && token.Item2 < priceScale / btcPrice)
                            textBox1.Text += String.Format("{0} | {1}", token.Item1, token.Item2) + Environment.NewLine;
                    else if (ethRadio.Checked)
                        if (token.Item2 > priceBase / ethPrice && token.Item2 < priceScale / ethPrice)
                            textBox1.Text += String.Format("{0} | {1}", token.Item1, token.Item2) + Environment.NewLine;
                }
            }
            if (waitTime.TotalSeconds < 1)
                coinLbl.Text = String.Format("Selected Coin: {0}", cryptos.SelectCoin());
            textBox2.Text = String.Format("Seed used: {0}\r\nTXID: {1} ", cryptos.rSeed, cryptos.rHash);
            rollLbl.Text = "Rolled: " + cryptos.roll;
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            Verify verify = new Verify();
            verify.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            coinCountLbl.Text = prices.Count.ToString();
        }

        private void coinCountLbl_Click(object sender, EventArgs e)
        {

        }
    }
}