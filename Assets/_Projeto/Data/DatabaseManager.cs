using Firebase.Database;
using UnityEngine;
using TMPro;
using System.Collections;
using System;

namespace com.icypeak.data
{
    public class DatabaseManager : MonoBehaviour
    {
        public static DatabaseManager Instance;
        [SerializeField] TextMeshProUGUI CoinsTxt;
        [SerializeField] TextMeshProUGUI CashTxt;

        string userId;
        DatabaseReference dbRef;
        CurrencyData currencyDataResource;
        GameData gameDataResource;

        private void Awake()
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

            currencyDataResource = Resources.Load<CurrencyData>("Data/CurrencyData");
            gameDataResource = Resources.Load<GameData>("Data/GameData");
        }

        void Start()
        {
            userId = "caioPTLULA";
            dbRef = FirebaseDatabase.DefaultInstance.RootReference;

            StartCoroutine(StartCurrency());
            StartCoroutine(StartGameData());
        }

        IEnumerator StartCurrency()
        {
            var currency = dbRef.Child("currency").Child(userId).GetValueAsync();
            yield return new WaitUntil(predicate: () => currency.IsCompleted);
            if (currency != null)
            {
                DataSnapshot snapshot = currency.Result;
                print("Currency Exists: " + snapshot.Exists);
                if (snapshot.Exists)
                {
                    var coins = snapshot.Child("coins").Value.ToString();
                    var cash = snapshot.Child("cash").Value.ToString();
                    print(coins);
                    print(cash);

                    CoinsTxt.text = coins;
                    CashTxt.text = cash;

                    currencyDataResource.Coins = int.Parse(coins);
                    currencyDataResource.Cash = int.Parse(cash);
                }
                else
                {
                    var info = new CurrencyJSONFY(currencyDataResource);
                    var infoToJson = JsonUtility.ToJson(info);
                    dbRef.Child("currency").Child(userId).SetRawJsonValueAsync(infoToJson);
                }
            }
        }

        IEnumerator StartGameData()
        {
            var gameInfo = dbRef.Child(this.gameDataResource.GameName).Child(userId).GetValueAsync();
            yield return new WaitUntil(predicate: () => gameInfo.IsCompleted);
            if (gameInfo != null)
            {
                DataSnapshot snapshot = gameInfo.Result;
                print("GameInfo Exists: " + snapshot.Exists);
                if (snapshot.Exists)
                {
                    var daily = snapshot.Child("daily_score").Value.ToString();
                    var weekly = snapshot.Child("weekly_score").Value.ToString();
                    var monthly = snapshot.Child("monthly_score").Value.ToString();
                    var alltime = snapshot.Child("alltime_score").Value.ToString();

                    gameDataResource.DailyScore = int.Parse(daily);
                    gameDataResource.WeeklyScore = int.Parse(weekly);
                    gameDataResource.MonthlyScore = int.Parse(monthly);
                    gameDataResource.AllTimeScore = int.Parse(alltime);
                }
                else
                {
                    var info = new GameDataJSONFY(gameDataResource);
                    var infoToJson = JsonUtility.ToJson(info);
                    dbRef.Child(gameDataResource.GameName).Child(userId).SetRawJsonValueAsync(infoToJson);
                }
            }
        }

        public void UpdateDB()
        {
            var infoGame = new GameDataJSONFY(gameDataResource);
            var infoGameToJson = JsonUtility.ToJson(infoGame);
            dbRef.Child(gameDataResource.GameName).Child(userId).SetRawJsonValueAsync(infoGameToJson);

            var infoCurrency = new CurrencyJSONFY(currencyDataResource);
            var infoCurrencyToJson = JsonUtility.ToJson(infoCurrency);
            dbRef.Child("currency").Child(userId).SetRawJsonValueAsync(infoCurrencyToJson);
        }

        public IEnumerator ReadDB(Action<CurrencyData, GameData> onComplete = null)
        {
            var currency = dbRef.Child(gameDataResource.GameName).Child(userId).GetValueAsync();
            yield return new WaitUntil(predicate: () => currency.IsCompleted);
            var gameInfo = dbRef.Child(gameDataResource.GameName).Child(userId).GetValueAsync();
            yield return new WaitUntil(predicate: () => gameInfo.IsCompleted);
            if (currency != null && gameInfo != null)
            {
                DataSnapshot snapshotCurrency = currency.Result;
                DataSnapshot snapshotGameInfo = currency.Result;

                if (snapshotCurrency.Exists && snapshotGameInfo.Exists)
                {
                    var coins = snapshotCurrency.Child("coins").Value.ToString();
                    var cash = snapshotCurrency.Child("cash").Value.ToString();
                    var daily = snapshotGameInfo.Child("daily_score").Value.ToString();
                    var weekly = snapshotGameInfo.Child("weekly_score").Value.ToString();
                    var monthly = snapshotGameInfo.Child("monthly_score").Value.ToString();
                    var alltime = snapshotGameInfo.Child("alltime_score").Value.ToString();

                    currencyDataResource.Coins = int.Parse(coins);
                    currencyDataResource.Cash = int.Parse(cash);
                    gameDataResource.DailyScore = int.Parse(daily);
                    gameDataResource.WeeklyScore = int.Parse(weekly);
                    gameDataResource.MonthlyScore = int.Parse(monthly);
                    gameDataResource.AllTimeScore = int.Parse(alltime);

                    onComplete?.Invoke(currencyDataResource, gameDataResource);
                }
            }
        }
    }
}