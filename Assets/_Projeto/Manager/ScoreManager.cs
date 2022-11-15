using System;
using com.Icypeak.Orbit.Obstacle;
using UnityEngine;

namespace com.Icypeak.Orbit.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        [SerializeField] int scorePoints;
        public int ScorePoints { get => scorePoints; }
        public Action<int> OnScoreChange;

        void Awake()
        {
            if(Instance != this && Instance != null)
            { 
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void IncreaseScore()
        {
            scorePoints++;
            OnScoreChange?.Invoke(scorePoints);
        }

        void OnEnable()
        {
            if (Director.GameMode == 1)
                ObstacleBehaviour.OnDeath += IncreaseScore;
            else
                ObstacleBehaviour.OnEscape += IncreaseScore;
        }

        void OnDisable()
        {
            if (Director.GameMode == 1)
                ObstacleBehaviour.OnDeath -= IncreaseScore;
            else
                ObstacleBehaviour.OnEscape -= IncreaseScore;
        }
    }
}
