using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using com.icypeak.data;

namespace com.Icypeak.Orbit.Scene
{
    public class SelectSkin : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI cashTextEl;
        [SerializeField] TextMeshProUGUI coinsTextEl;

        void Start()
        {
            cashTextEl.text = LocalDataManager.Instance.CurrencyDataResource.Cash.ToString();
            coinsTextEl.text = LocalDataManager.Instance.CurrencyDataResource.Coins.ToString();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
