using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoVC_Form
{
    class Collection
    {
        List<Tuple<string, double>> cryptos = new List<Tuple<string, double>>();
        //Regex regex = new Regex("class=\"crypto-symbol\">([a-zA-Z0-9]*)</span></a></td><td><span>\\$<!-- -->([0-9]*.[0-9]*)</span>");
        Regex regex = new Regex("\"symbol\":\"([a-zA-Z0-9]*)\",\"price\":\"([0-9]*.[0-9]*)\"");
        public double btcPrice = 0;
        public double ethPrice = 0;
        public int rSeed = 0;
        public string rHash = String.Empty;

        public List<Tuple<string, double>> GenerateCoins(string type)
        {
            string result = String.Empty;
            WebRequest request = WebRequest.Create("https://coinmarketcap.com/" + type);
            WebResponse response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            foreach (Match match in regex.Matches(result))
            {
                cryptos.Add(new Tuple<string, double>(match.Groups[1].Value, double.Parse(match.Groups[2].Value)));
            }

            return cryptos;
        }

        public List<Tuple<string, double>> BinanceCoins(string type)
        {
            string result = String.Empty;
            WebRequest request = WebRequest.Create("https://api.binance.com/api/v3/ticker/price");
            WebResponse response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            foreach (Match match in regex.Matches(result))
            {
                if (match.Groups[1].Value.Contains(type))
                    cryptos.Add(new Tuple<string, double>(match.Groups[1].Value, double.Parse(match.Groups[2].Value)));

                if (match.Groups[1].Value.Contains("BTCUSDC"))
                    btcPrice = double.Parse(match.Groups[2].Value);
                if (match.Groups[1].Value.Contains("ETHUSDC"))
                    ethPrice = double.Parse(match.Groups[2].Value);
            }

            return cryptos;
        }

        public string SelectCoin()
        {
            Regex hash = new Regex("\"hash\": \"([a-zA-Z0-9]*)\"");
            Regex seed = new Regex("\"total\": ([0-9]*),");
            string result = String.Empty;
            WebRequest request = WebRequest.Create("https://api.blockcypher.com/v1/btc/main/txs");
            WebResponse response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            rSeed = Int32.Parse(seed.Match(result).Groups[1].Value);
            rHash = hash.Match(result).Groups[1].Value;
            Random random = new Random(rSeed);

            return cryptos[random.Next(0, cryptos.Count-1)].Item1;
        }
    }
}
