using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoVC_Form
{
    class Collection
    {
        List<Tuple<string, double>> cryptos = new List<Tuple<string, double>>();
        public List<string> rollCryptos = new List<string>();
        public List<Tuple<string, double>> marketCap = new List<Tuple<string, double>>();
        public List<string> newList = new List<string>();
        double cMarketCapPrice = 0;

        //Regex regex = new Regex("class=\"crypto-symbol\">([a-zA-Z0-9]*)</span></a></td><td><span>\\$<!-- -->([0-9]*.[0-9]*)</span>");
        Regex regex = new Regex("\"symbol\":\"([a-zA-Z0-9]*)\",\"price\":\"([0-9]*.[0-9]*)\"");
        public double btcPrice = 0;
        public double ethPrice = 0;
        public string rValue = String.Empty;
        public string rSeed = "";
        public string url = "";
        //public string rHash = String.Empty;
        public string rTime = String.Empty;
        public int roll = 0;

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

        public void CoinbaseMarket(double marketCapPrice)
        {
            cMarketCapPrice = marketCapPrice;
            Regex symbolCap = new Regex("\"symbol\":\"([a-zA-Z0-9]*).*?\"marketCap\":([0-9]*.[0-9]*?),");

            string result = String.Empty;
            WebRequest request = WebRequest.Create("https://api.coinmarketcap.com/data-api/v3/cryptocurrency/listing?start=1&limit=1000&convert=USD");
            WebResponse response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            foreach (Match match in symbolCap.Matches(result))
            {
                marketCap.Add(new Tuple<string, double>(match.Groups[1].Value.ToString(), double.Parse(match.Groups[2].Value)));
            }

            foreach (var cap in marketCap)
            {
                if(cap.Item2 < cMarketCapPrice)
                    if(rollCryptos.Contains(cap.Item1 + "BTC") || rollCryptos.Contains(cap.Item1 + "ETH"))
                    {
                        newList.Add(cap.Item1);
                    }
            }
            newList.Sort();
            newList = newList.Distinct().ToList();
            //foreach(var basic in rollCryptos)
            //{
            //    foreach(var advanced in marketCap)
            //    {
            //        if(advanced.Item1 != "BTC" && advanced.Item1 != "ETH")
            //        {
            //            if(basic == advanced.Item1 + "BTC")
            //            {
            //                if(advanced.Item2 < 200000000)
            //                {
            //                    marketCap.Remove(advanced);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        public string SelectCoin(DateTime time)
        {
            long unixTime = ((DateTimeOffset)time).ToUnixTimeSeconds();

            Regex randomVal = new Regex("\"localRandomValue\" : \"([a-zA-Z0-9]*)\"");
            //Regex hash = new Regex("\"hash\": \"([a-zA-Z0-9]*)\"");
            //Regex seed = new Regex("\"total\": ([0-9]*),");
            Regex timestamp = new Regex("\"timeStamp\" : \"([0-9]*-[0-9]*-[0-9]*T[0-9]*:[0-9]*:[0-9]*.[0-9]*Z)\"");
            string result = String.Empty;
            url = String.Format("https://beacon.nist.gov/beacon/2.0/pulse/time/{0}000", unixTime);
            Thread.Sleep(5000);
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            //CoinbaseMarket(cMarketCapPrice);
            rValue = randomVal.Match(result).Groups[1].Value;
            rSeed = rValue.Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "");
            rSeed = rSeed.Substring(rSeed.Count() - 7);
            //rHash = hash.Match(result).Groups[1].Value;
            rTime = timestamp.Match(result).Groups[1].Value;
            Random random = new Random(int.Parse(rSeed));
            roll = random.Next(0, newList.Count - 1);
            return newList[roll];
        }
    }
}
