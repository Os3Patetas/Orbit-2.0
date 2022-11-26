using UnityEngine;
using TMPro;
using com.Icypeak.Orbit.Manager;
using com.icypeak.data;
using com.icypeak.data.middlemen;

namespace com.Icypeak.Orbit
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scorePointsText;
        [SerializeField] TextMeshProUGUI scoreCoinsText;
        [SerializeField] TextMeshProUGUI bonusCoinsText;
        [SerializeField] TextMeshProUGUI totalCoinsText;
        [SerializeField] TextMeshProUGUI currentCoinsText;

        private void OnEnable()
        {
            var score = ScoreManager.Instance.ScorePoints;

            var scoreCoins = score / 10.0f;
            var bonusCoins = (scoreCoins * LocalDataManager.Instance.GameDataResource.ScoreMultiplier) - scoreCoins;

            LocalDataManager.Instance.UpdateLocalCurrencyData(new CurrencyMiddleman(
                LocalDataManager.Instance.CurrencyDataResource.Coins += (int)(scoreCoins + bonusCoins),
                LocalDataManager.Instance.CurrencyDataResource.Cash
            ));

            scorePointsText.text = score.ToString();
            scoreCoinsText.text = $"Score Coins: + {(int)scoreCoins}";
            bonusCoinsText.text = $"Bonus({LocalDataManager.Instance.GameDataResource.ScoreMultiplier}x): {(int)bonusCoins}";
            totalCoinsText.text = $"Total Earned: {(int)(scoreCoins + bonusCoins)}";
        }
    }
}
