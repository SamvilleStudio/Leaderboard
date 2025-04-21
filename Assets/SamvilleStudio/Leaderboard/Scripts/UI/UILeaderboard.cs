using System.Linq;
using UnityEngine;
using TMPro;

namespace Samville.Leaderboard
{
    public class UILeaderboard : MonoBehaviour
    {
        [SerializeField] private GameObject _leaderboardPanel;
        [SerializeField] private TMP_Text _scoreListText;

        // Start is called before the first frame update
        void Start()
        {
            DisplayTopScores();
        }

        void OnEnable()
        {
            DisplayTopScores();
        }

        [ContextMenu("Show Leaderboard")]
        public void DisplayTopScores()
        {
            var topScores = LeaderboardManager.Instance.Data.Scores
            .OrderByDescending(s => s.playerScore)
            .ThenBy(s => s.playerName)
            .Take(10)
            .ToList();

            _scoreListText.text = string.Empty;

            for (int i = 0; i < topScores.Count; i++)
            {
                _scoreListText.text += $"{i + 1}. {topScores[i].playerName} - {topScores[i].playerScore}\n";
            }
        }
    }
}