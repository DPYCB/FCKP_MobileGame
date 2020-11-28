using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetLevel()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
        //SceneManager.LoadScene("LikeLevel");
    }
}
