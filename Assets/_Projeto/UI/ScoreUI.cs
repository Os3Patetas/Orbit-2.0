using UnityEngine;
using TMPro;
using com.Icypeak.Orbit.Manager;

namespace com.Icypeak.Orbit.UI
{
    public class ScoreUI : MonoBehaviour
    {
        TextMeshProUGUI _textComponent;

        private void RefreshScoreText(int score) =>
            _textComponent.text = score.ToString();

        void Awake() =>
            _textComponent = GetComponent<TextMeshProUGUI>();

        void OnEnable() =>
            ScoreManager.Instance.OnScoreChange += RefreshScoreText;
        void OnDisable()
        {
            if (ScoreManager.Instance is not null)
            {
                ScoreManager.Instance.OnScoreChange -= RefreshScoreText;
            }
        }

    }
}
