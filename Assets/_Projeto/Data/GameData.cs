using UnityEngine;

namespace com.icypeak.data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Database/GameData")]
    public class GameData : ScriptableObject
    {
        public string GameName;
        public int DailyScore;
        public int WeeklyScore;
        public int MonthlyScore;
        public int AllTimeScore;
        public float ScoreMultiplier;

        public GameData(int dailyScore, int weeklyScore, int monthlyScore, int allTimeScore)
        {
            this.DailyScore = dailyScore;
            this.WeeklyScore = weeklyScore;
            this.MonthlyScore = monthlyScore;
            this.AllTimeScore = allTimeScore;
        }
    }
}