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
    }
}