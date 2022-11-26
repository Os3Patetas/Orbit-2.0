namespace com.icypeak.data
{
    public class CurrencyJSONFY
    {
        public int coins;
        public int cash;

        public CurrencyJSONFY(CurrencyData currency)
        {
            coins = currency.Coins;
            cash = currency.Cash;
        }
    }
}