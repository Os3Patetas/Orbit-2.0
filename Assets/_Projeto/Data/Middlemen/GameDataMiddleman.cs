namespace com.icypeak.data.middlemen
{
    public class GameDataMiddleman
    {
        public int DailyScore;
        public int WeeklyScore;
        public int MonthlyScore;
        public int AllTimeScore;

        public GameDataMiddleman(int dailyScore, int weeklyScore, int monthlyScore, int allTimeScore)
        {
            this.DailyScore = dailyScore;
            this.WeeklyScore = weeklyScore;
            this.MonthlyScore = monthlyScore;
            this.AllTimeScore = allTimeScore;
        }
    }
}