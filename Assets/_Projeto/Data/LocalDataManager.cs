using System;
using UnityEngine;

namespace com.icypeak.data
{
    public class LocalDataManager : MonoBehaviour
    {
        public static LocalDataManager Instance;

        public GameData GameDataResource { get; private set; }
        public CurrencyData CurrencyDataResource { get; private set; }

        public Action OnGameDataChange;
        public Action OnCurrencyChange;

        void Awake()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            CurrencyDataResource = Resources.Load<CurrencyData>("Data/CurrencyData");
            GameDataResource = Resources.Load<GameData>("Data/GameData");
        }

        public void UpdateLocalGameData(GameData newData)
        {
            GameDataResource.DailyScore = newData.DailyScore;
            GameDataResource.WeeklyScore = newData.WeeklyScore;
            GameDataResource.MonthlyScore = newData.MonthlyScore;
            GameDataResource.AllTimeScore = newData.AllTimeScore;
            OnGameDataChange?.Invoke();
        }

        public void UpdateLocalCurrencyData(CurrencyData newData)
        {
            CurrencyDataResource.Coins = newData.Coins;
            CurrencyDataResource.Cash = newData.Cash;
            OnCurrencyChange?.Invoke();
        }

    }
}