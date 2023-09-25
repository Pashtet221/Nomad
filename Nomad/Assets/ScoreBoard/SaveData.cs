// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class SaveData : MonoBehaviour
// {
//     public TextMeshProUGUI myScore;
//     public TextMeshProUGUI myName;
//     public int currentScore;

    
//     void Update()
//     {
//         myScore. text = $"SCORE: {PlayerPrefs. GetInt("highscore")}";
//     }

//     public void SendScore()
//     {
//         if (currentScore > PlayerPrefs.GetInt("highscore"))
//         {
//             PlayerPrefs.SetInt("highscore", currentScore);
//             HighScores.UploadScore(myName.text, currentScore);
//         }
//     }
// }
