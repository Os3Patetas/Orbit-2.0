using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using com.Icypeak.Data;

namespace com.Icypeak.Orbit.Scene
{
    public class SelectSkin : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI cashTextEl;
        [SerializeField] TextMeshProUGUI coinsTextEl;

        void Start()
        {
            cashTextEl.text = LocalDataManager.Instance.Currency.Cash.ToString();
            coinsTextEl.text = LocalDataManager.Instance.Currency.Coins.ToString();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
