using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private Score _scoreSystem;

    private void OnEnable()
    {
        if (_scoreSystem != null)
        {
            // Grab final score from score script and update text
            int scoreToDisplay = _scoreSystem.GetFinalScore();
            DisplayGameOver(scoreToDisplay);
        }
        else
        {
            Debug.LogError("GameOver Script: Drag Score object in Score System slot");
        }
    }

    public void DisplayGameOver(int finalScore)
    {
        if (_finalScoreText != null)
        {
            _finalScoreText.text = finalScore + " seconds";
        }
    }

    public void ResetGame()
    {
        Debug.Log("peepeepoopoo");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
