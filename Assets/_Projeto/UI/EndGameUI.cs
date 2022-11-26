using UnityEngine;
using TMPro;
using com.Icypeak.Orbit.Manager;
using com.Icypeak.Data;

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

            var scoreCoins = (int)(score);
            //var bonusCoins = (int)((scoreCoins * LocalDataManager.Instance.Game.ScoreMultiplier) - scoreCoins);
            var bonusCoins = 0;
            var totalReceivedCoins = scoreCoins + bonusCoins;
            var currentCoins = LocalDataManager.Instance.Currency.Coins + totalReceivedCoins;

            LocalDataManager.Instance.UpdateLocalCoins(currentCoins);

            scorePointsText.text = score.ToString();
            scoreCoinsText.text = $"Score Coins: + {scoreCoins}";
            //bonusCoinsText.text = $"Bonus({LocalDataManager.Instance.Game.ScoreMultiplier}x): {bonusCoins}";
            bonusCoinsText.text = $"Bonus({0}x): {bonusCoins}";
            totalCoinsText.text = $"Total Earned: {totalReceivedCoins}";
            currentCoinsText.text = $"Current Coins: {currentCoins}";
        }
    }
}
