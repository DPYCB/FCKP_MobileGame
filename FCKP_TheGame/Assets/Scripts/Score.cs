using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI highScore;
    private string levelName;


    void Start()
    {
        levelName = PlayerPrefs.GetString("currentLevel");

        int currentScore = 0;
        finalScore.text = PlayerPrefs.GetString(levelName + "Score");
        Int32.TryParse(finalScore.text, out currentScore);

        int currentHighScore = 0;
        highScore.text = PlayerPrefs.GetString(levelName + "HighScore");
        Int32.TryParse(highScore.text, out currentHighScore);

        if (currentScore > currentHighScore)
        {
            highScore.text = PlayerPrefs.GetString(levelName + "Score");
            PlayerPrefs.SetString(levelName + "HighScore", highScore.text);
        }

        PlayerPrefs.Save();
    }
}
