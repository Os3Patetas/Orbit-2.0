using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using com.Icypeak.Orbit.Manager;
using com.icypeak.data;

namespace com.Icypeak.Orbit.Scene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI CoinsTextEl;
        [SerializeField] TextMeshProUGUI CashTextEl;

        void Start()
        {
            CoinsTextEl.text = LocalDataManager.Instance.CurrencyDataResource.Coins.ToString();
            CashTextEl.text = LocalDataManager.Instance.CurrencyDataResource.Cash.ToString();
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
