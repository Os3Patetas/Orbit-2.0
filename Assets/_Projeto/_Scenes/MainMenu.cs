using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using com.Icypeak.Orbit.Manager;
using com.Icypeak.Data;

namespace com.Icypeak.Orbit.Scene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI CoinsTextEl;
        [SerializeField] TextMeshProUGUI CashTextEl;

        void Start()
        {
            RefreshCurrencyUI();
        }

        void RefreshCurrencyUI()
        {
            CoinsTextEl.text = LocalDataManager.Instance.Currency.Coins.ToString();
            CashTextEl.text = LocalDataManager.Instance.Currency.Cash.ToString();
        }

        void OnEnable()
        {
            LocalDataManager.Instance.OnCurrencyChange += RefreshCurrencyUI;
        }
        void OnDisable()
        {
            if (LocalDataManager.Instance is null) return;

            LocalDataManager.Instance.OnCurrencyChange -= RefreshCurrencyUI;
        }

        public void GoToChooseGameMode()
        {
            SceneManager.LoadScene("ChooseGameMode");
        }
        public void GoToOptionsScene()
        {
            SceneManager.LoadScene("Options");
        }
        public void GoToLeaderboardScene()
        {
            SceneManager.LoadScene("Leaderboard");
        }
        public void GoToStoreScene()
        {
            SceneManager.LoadScene("Store");
        }
        public void GoToSelectSkin()
        {
            SceneManager.LoadScene("SelectSkin");
        }
        public void GoToTwitter()
        {
            Application.OpenURL("https://twitter.com/IcyPeakStudio");
        }
        public void GoToWebsite()
        {
            Application.OpenURL("http://localhost:4200");
        }
        public void ActivateBonus()
        {
            FindObjectOfType<AdManager>().ShowRewardedInterstitialAd();
        }
    }
}
