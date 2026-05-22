using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private Score _scoreSystem;

    private void OnEnable()
    {
        if (_scoreSystem != null)
        {
            int currentScore = _scoreSystem.GetFinalScore();

            // 1. Check and handle high score logic
            int savedHighScore = HandleHighScore(currentScore);

            // 2. Display both scores
            DisplayGameOver(currentScore, savedHighScore);
        }
        else
        {
            Debug.LogError("GameOver Script: Drag Score object to Score System slot");
        }
    }

    // Added function to handle PlayerPrefs saving/loading
    private int HandleHighScore(int currentScore)
    {
        // Get existing high score from device or 0 if it doesn't exist yet
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        // If player's score is higher than previous record: overwrite best score
        if (currentScore > currentHighScore)
        {
            currentHighScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentHighScore);
            PlayerPrefs.Save(); // Force save data
            Debug.Log("New best score saved");
        }

        return currentHighScore;
    }

    // Accepts both scores to UI
    public void DisplayGameOver(int finalScore, int bestScore)
    {
        if (_finalScoreText != null)
        {
            _finalScoreText.text = finalScore + " seconds";
        }

        if (_bestScoreText != null)
        {
            _bestScoreText.text = "Best: " + bestScore + " seconds";
        }
    }

    public void ResetGame()
    {
        Debug.Log("peepeepoopoo");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
