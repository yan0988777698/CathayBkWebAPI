namespace CathayBkWebAPI.Model
{
    public class BTCPrice
    {
        public int Id {  get; set; }
        public DateTime UpdateTime { get; set; }
        public double USDRate { get; set; }
        public double GBPRate { get; set; }
        public double EURRate { get; set; }
    }
}
