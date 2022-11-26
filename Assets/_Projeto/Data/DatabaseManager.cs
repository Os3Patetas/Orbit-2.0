using Firebase.Database;
using UnityEngine;
using System.Collections;

namespace com.icypeak.data
{
    public class DatabaseManager : MonoBehaviour
    {
        public static DatabaseManager Instance;
        string userId;
        DatabaseReference dbRef;

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
        }

        void Start()
        {
            userId = "caioPTLULA";
            dbRef = FirebaseDatabase.DefaultInstance.RootReference;

            StartCoroutine(StartDB());
        }

        IEnumerator StartDB()
        {
            var currency = dbRef.Child("currency").Child(userId).GetValueAsync();
            var gameData = dbRef.Child(LocalDataManager.Instance.GameDataResource.GameName).Child(userId).GetValueAsync();
            yield return new WaitUntil(predicate: () => currency.IsCompleted && gameData.IsCompleted);
            if (currency != null && gameData != null)
            {
                DataSnapshot snapshotCurrency = currency.Result;
                DataSnapshot snapshotGameData = gameData.Result;
                print("Currency Exists: " + snapshotCurrency.Exists);
                print("GameInfo Exists: " + snapshotGameData.Exists);

                if (snapshotCurrency.Exists)
                {
                    LocalDataManager.Instance.UpdateLocalCurrencyData(new CurrencyData(
                        int.Parse(snapshotCurrency.Child("coins").Value.ToString()),
                        int.Parse(snapshotCurrency.Child("cash").Value.ToString())
                    ));
                }
                else
                {
                    var info = new CurrencyJSONFY(LocalDataManager.Instance.CurrencyDataResource);
                    var infoToJson = JsonUtility.ToJson(info);
                    dbRef.Child("currency").Child(userId).SetRawJsonValueAsync(infoToJson);
                }

                if (snapshotGameData.Exists)
                {
                    LocalDataManager.Instance.UpdateLocalGameData(new GameData(
                        int.Parse(snapshotGameData.Child("daily_score").Value.ToString()),
                        int.Parse(snapshotGameData.Child("weekly_score").Value.ToString()),
                        int.Parse(snapshotGameData.Child("monthly_score").Value.ToString()),
                        int.Parse(snapshotGameData.Child("alltime_score").Value.ToString())
                    ));
                }
                else
                {
                    var info = new GameDataJSONFY(LocalDataManager.Instance.GameDataResource);
                    var infoToJson = JsonUtility.ToJson(info);
                    dbRef.Child(LocalDataManager.Instance.GameDataResource.GameName).Child(userId).SetRawJsonValueAsync(infoToJson);
                }
            }
        }

        public void UpdateCurrencyDB()
        {
            var infoCurrency = new CurrencyJSONFY(LocalDataManager.Instance.CurrencyDataResource);
            var infoCurrencyToJson = JsonUtility.ToJson(infoCurrency);
            dbRef.Child("currency").Child(userId).SetRawJsonValueAsync(infoCurrencyToJson);
        }

        public void UpdateGameDataDB()
        {
            var infoGame = new GameDataJSONFY(LocalDataManager.Instance.GameDataResource);
            var infoGameToJson = JsonUtility.ToJson(infoGame);
            dbRef.Child(LocalDataManager.Instance.GameDataResource.GameName).Child(userId).SetRawJsonValueAsync(infoGameToJson);

        }

        void OnEnable()
        {
            LocalDataManager.Instance.OnCurrencyChange += UpdateCurrencyDB;
            LocalDataManager.Instance.OnGameDataChange += UpdateGameDataDB;
        }

        void OnDisable()
        {
            if (LocalDataManager.Instance != null)
            {
                LocalDataManager.Instance.OnCurrencyChange -= UpdateCurrencyDB;
                LocalDataManager.Instance.OnGameDataChange -= UpdateGameDataDB;
            }
        }

    }
}