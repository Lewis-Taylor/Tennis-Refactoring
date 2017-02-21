using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const int DeuceScore = 3;
        private const string PlayerOneName = "player1";
        private const int PlayerPoint = 1;
        private const string PlayerTwoName = "player2";
        private int _playerOneScore;
        private int _playerTwoScore;
     
        private static readonly Dictionary<int, string> PlayerScore = new Dictionary<int, string>
        {
            { 0, "Love"},
            { 1, "Fifteen"},
            { 2, "Thirty"},
            { 3, "Forty"}
        };

        private static readonly Dictionary<int, string> PlayerAdvantage = new Dictionary<int, string>
        {
            { 1, "Advantage player1" },
            {-1, "Advantage player2" }
        };

        public void WonPoint(string playerName)
        {
            if (playerName == PlayerOneName)
            {
                _playerOneScore += PlayerPoint;
            }
            else
            {
                _playerTwoScore += PlayerPoint;
            }
        }

        public string CalculateScore()
        {
            var score = string.Empty;
            if (IsPlayerScoresEqual())
            {
                score = CalculateEqualScore();
            }
            else if (IsPlayersScoresDeuce())
            {
                score = CalculateDeuceScores();
            }
            else
            {
                score = CalculateCurrentScore();
            }
            return score;
        }

        private bool IsPlayersScoresDeuce()
        {
            return _playerOneScore > DeuceScore || _playerTwoScore > DeuceScore;
        }

        private bool IsPlayerScoresEqual()
        {
            return _playerOneScore == _playerTwoScore;
        }

        private string CalculateCurrentScore()
        {
            return PlayerScore[_playerOneScore] + "-" + PlayerScore[_playerTwoScore];
        }

        private string CalculateDeuceScores()
        {
            var scoreDifference = _playerOneScore - _playerTwoScore;
            if (PlayerAdvantage.ContainsKey(scoreDifference))
            {
                return PlayerAdvantage[scoreDifference];
            }

            return "Win for " + SelectPlayer(scoreDifference);
        }

        private static string SelectPlayer(int scoreDifference)
        {
            return scoreDifference > 1 ? PlayerOneName : PlayerTwoName;
        }

        private string CalculateEqualScore()
        {
            if (_playerOneScore > 2)
            {
                return "Deuce";
            }

            return PlayerScore[_playerOneScore] + "-All";
        }
    }
}