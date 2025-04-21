# 🏆 Unity Leaderboard System (JSON-Based)

A flexible leaderboard system for Unity that saves player scores using a JSON file instead of `PlayerPrefs`. It supports name input, prevents duplicate names (unless the new score is higher), and displays the top 10 high scores.

---

## ✨ Features

- ✅ JSON-based saving (`Application.persistentDataPath`)
- ✅ Input field for player name submission
- ✅ Automatically replaces score if a duplicate name submits a higher score
- ✅ Displays top 10 highest scores sorted by value
- ✅ In-Editor utility to generate dummy scores for testing
- ✅ Clear leaderboard function for clean slate testing

---

## 🛠️ How to Use

1. **Attach Scripts:**
   - `LeaderboardManager.cs` → Empty GameObject (e.g., "GameManager")
   - `UIPlayerNameInput.cs` → UI Handler (with InputField + optional warning text)

2. **Set References in Inspector:**
   - `LeaderboardManager`: Assign `leaderboardDisplay` (Text)
   - `UIPlayerNameInput`: Assign `nameInputField` and `warningText`

3. **Call Methods:**
   - `UIPlayerNameInput.SubmitNameAndScore()` → Submits name + current score
   - `LeaderboardManager.Instance.currentScore` → Set this from your game logic when the session ends

4. **Optional Debug Tools:**
   - `LeaderboardManager → Generate Dummy Scores` (via Inspector context menu)
   - `LeaderboardManager.ClearLeaderboard()` to reset

---

## 📸 Sample UI Setup

- `InputField` for name
- `Button` → calls `SubmitScore()`
- Show warning if submission fails in Console
- `Text` to display the leaderboard

---

## 🔄 Example Behavior

| Name   | Existing Score | Submitted Score | Result             |
|--------|----------------|-----------------|--------------------|
| Alex   | 1200           | 1300            | ✅ Score updated    |
| Jordan | 1500           | 1000            | ❌ Not updated      |
| Sam    | —              | 900             | ✅ New entry added  |

---

## 🧪 Testing Tips

- Set `LeaderboardManager.Instance.currentScore` manually for quick tests.
- Use the **Generate Dummy Scores** menu to simulate leaderboard data.

---

## 📄 License

This project was developed for a Samville Studio and serves as an educational reference.

---

## 🙌 Credits

Developed by
1. Rizaldy Saputra Dharma Winata

---
