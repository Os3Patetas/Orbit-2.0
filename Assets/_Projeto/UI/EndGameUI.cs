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

            var scoreCoins = (int)(score / 10.0f);
            var bonusCoins = (int)((scoreCoins * LocalDataManager.Instance.GameDataResource.ScoreMultiplier) - scoreCoins);
            var totalReceivedCoins = scoreCoins + bonusCoins;
            var currentCoins = LocalDataManager.Instance.CurrencyDataResource.Coins + totalReceivedCoins;

            LocalDataManager.Instance.UpdateLocalCurrencyData(new CurrencyMiddleman(
                currentCoins,
                LocalDataManager.Instance.CurrencyDataResource.Cash
            ));

            scorePointsText.text = score.ToString();
            scoreCoinsText.text = $"Score Coins: + {scoreCoins}";
            bonusCoinsText.text = $"Bonus({LocalDataManager.Instance.GameDataResource.ScoreMultiplier}x): {bonusCoins}";
            totalCoinsText.text = $"Total Earned: {totalReceivedCoins}";
            currentCoinsText.text = $"Current Coins: {currentCoins}";
        }
    }
}
