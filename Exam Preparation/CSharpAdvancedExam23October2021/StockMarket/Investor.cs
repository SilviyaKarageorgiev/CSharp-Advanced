using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {

        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {            
            if (this.Portfolio.Any(x => x.CompanyName == companyName) == false)
            {
                return $"{companyName} does not exist.";
            }
            if (sellPrice < this.Portfolio.First(x => x.CompanyName == companyName).PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(Portfolio.First(x => x.CompanyName == companyName));
            this.MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {            
            return this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
