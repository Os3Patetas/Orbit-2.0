namespace com.icypeak.data
{
    public class GameDataJSONFY
    {
        public int daily_score;
        public int weekly_score;
        public int monthly_score;
        public int alltime_score;
        public float score_multiplier;

        public GameDataJSONFY(GameData info)
        {
            daily_score = info.DailyScore;
            weekly_score = info.WeeklyScore;
            monthly_score = info.MonthlyScore;
            alltime_score = info.AllTimeScore;
            score_multiplier = info.ScoreMultiplier;
        }
    }

}