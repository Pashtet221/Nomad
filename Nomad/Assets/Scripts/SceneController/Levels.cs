using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Popup;
using UnityEngine.SceneManagement; // Add this line to use SceneManager

public class Levels : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public int scoreToUnlock;
        public string sceneToLoad; // Add a field to specify the scene to load
    }

    public Level[] levels;
    public GameObject levelPrefab;
    public Transform content;

    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    private void Start()
    {
        CreateLevelButtons();
    }

    private void CreateLevelButtons()
    {
        int highScore = PlayerPrefs.GetInt("highscore", 0); // Get the high score from PlayerPrefs

        for (int i = 0; i < levels.Length; i++)
        {
            GameObject buttonGO = Instantiate(levelPrefab, content);
            Button button = buttonGO.GetComponent<Button>();

            if (button != null)
            {
                int levelIndex = i; // Store level index for the lambda function

                Text buttonText = button.GetComponentInChildren<Text>();
                Image levelImage = button.GetComponent<Image>();

                // Enable or disable sprites based on high score
                if (highScore >= levels[i].scoreToUnlock)
                {
                    levelImage.sprite = unlockedSprite;
                    button.interactable = true; // Unlock the button

                    // Display the buttonText on unlocked levels
                    if (buttonText != null)
                    {
                        buttonText.text = (i + 1).ToString(); // Customize the button text
                    }

                    // Add a click event to load the scene
                    button.onClick.AddListener(() => LoadLevel(levels[levelIndex].sceneToLoad));
                }
                else
                {
                    levelImage.sprite = lockedSprite;
                    button.onClick.AddListener(() => ShowPopup(levels[levelIndex].scoreToUnlock));

                    // Hide the buttonText on locked levels
                    if (buttonText != null)
                    {
                        buttonText.text = ""; // Clear the button text
                    }
                }
            }
        }
    }

    private void ShowPopup(int scoreToUnlock)
    {
        Popup.Show(scoreToUnlock + " очков", "Для перехода на следующий уровень наберите " + scoreToUnlock + " очков", "Начать игру");
    }

    private void LoadLevel(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
