using UnityEngine;
using TMPro;
using com.Icypeak.Orbit.Manager;
using com.icypeak.data;

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
            var currency = Resources.Load<CurrencyData>("Data/CurrencyData");
            var gameData = Resources.Load<GameData>("Data/GameData");

            var scoreCoins = score / 10.0f;
            var bonusCoins = (scoreCoins * gameData.ScoreMultiplier) - scoreCoins;

            gameData.ScoreMultiplier = 1.0f;
            currency.Coins += (int)(scoreCoins + bonusCoins);

            scorePointsText.text = score.ToString();
            scoreCoinsText.text = $"Score Coins: + {(int)scoreCoins}";
            bonusCoinsText.text = $"Bonus({gameData.ScoreMultiplier}x): {(int)bonusCoins}";
            totalCoinsText.text = $"Total Earned: {(int)(scoreCoins + bonusCoins)}";
            currentCoinsText.text = $"Coins: {currency.Coins}";
        }
    }
}
