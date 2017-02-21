namespace Tennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string CalculateScore();
    }
}

