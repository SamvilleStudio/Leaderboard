using UnityEngine;
using TMPro;

namespace Samville.Leaderboard
{
    public class UIPlayerNameInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _playerNameInputField;

        public void SubmitScore()
        {
            string playerName = _playerNameInputField.text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                Debug.LogWarning("Player name is empty! Score will not be added to the leaderboard.");
                return;
            }

            int score = LeaderboardManager.Instance.CurrentScore;

            bool success = LeaderboardManager.Instance.AddEntry(playerName, score);

            if (!success)
            {
                Debug.LogWarning("You already have a higher score!");
            }
            else
            {
                Debug.Log($"Submitted {playerName} with score {score}");
            }
        }
    }
}