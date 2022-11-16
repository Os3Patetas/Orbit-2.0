using UnityEngine;

namespace com.icypeak.data
{
    [CreateAssetMenu(fileName = "CurrencyData", menuName = "Database/CurrencyData")]
    public class CurrencyData : ScriptableObject
    {
        public int Coins;
        public int Cash;

        public CurrencyData(int coins, int cash)
        {
            this.Coins = coins;
            this.Cash = cash;
        }
    }
}