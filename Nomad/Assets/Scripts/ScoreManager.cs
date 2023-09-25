using UnityEngine;
using TMPro;
using EasyUI.Popup;

public class ScoreManager : MonoBehaviour
{
    // Singleton instance
    public static ScoreManager Instance { get; private set; }

    public TextMeshProUGUI myName;
    public TextMeshProUGUI myScore;
    [HideInInspector] public int CurrentScore { get; private set; }
    [HideInInspector] public int Floor { get; private set; }
    
    private int highScore; // Variable to store the high score

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance of ScoreManager exists
            return;
        }
    }

    private void Start()
    {
        // Load the high score from PlayerPrefs during initialization
        highScore = PlayerPrefs.GetInt("highscore", 0);
        UpdateHighScoreText();
    }
    
    void Update()
    {
        myScore.text = $"SCORE: {CurrentScore}";
        UpdateHighScoreText();
    }

    public void AddScore(int points, int floor)
    {
        CurrentScore += points;
        Floor += floor;

        // Check if the current score is higher than the high score
        if (CurrentScore > highScore)
        {
            highScore = CurrentScore;
            PlayerPrefs.SetInt("highscore", highScore);
            UpdateHighScoreText();
        }

        GameSharedUI.Instance.UpdateScoreUIText();
    }

    public void RemoveScore(int points)
    {
        CurrentScore -= points;
        GameSharedUI.Instance.UpdateScoreUIText();
    }

    public int GetCurrentScore()
    {
        return CurrentScore;
    }

    public int GetFloor()
    {
        return Floor / 2;
    }

    public void SendScore()
    {
        Popup.Show("Результат", "Для зачисления результата, пожалуйста введите имя и сделайте фото профиля", "Хорошо");
        // Upload the score if it's a new high score
        if (CurrentScore > PlayerPrefs.GetInt("highscore"))
        {
            HighScores.UploadScore(myName.text, CurrentScore);
        }
    }

    // Update the high score text
    private void UpdateHighScoreText()
    {
        myScore.text = $"{highScore}";
    }
}
