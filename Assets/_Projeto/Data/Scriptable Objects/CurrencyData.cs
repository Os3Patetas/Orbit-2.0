using UnityEngine;

namespace com.icypeak.data
{
    [CreateAssetMenu(fileName = "CurrencyData", menuName = "Database/CurrencyData")]
    public class CurrencyData : ScriptableObject
    {
        public int Coins;
        public int Cash;
    }
}