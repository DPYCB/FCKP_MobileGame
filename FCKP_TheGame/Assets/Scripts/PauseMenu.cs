using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Image muteButtonImage; 
    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        PauseGame();
    }

    private void OnApplicationQuit()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Color color = muteButtonImage.color;
        if (audioManager.isMuted == true)
        {
            color.a = 0.5f;
            muteButtonImage.color = color;
        }
        else
        {
            color.a = 1f;
            muteButtonImage.color = color;
        }
    }

    public void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResetLevel()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().Stop(PlayerPrefs.GetString("currentLevel") + "_theme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().Stop(PlayerPrefs.GetString("currentLevel") + "_theme");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void SetMute()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Color color = muteButtonImage.color;
        if (audioManager.isMuted == true)
        {
            audioManager.SetMute(false);
            color.a = 1f;
            muteButtonImage.color = color;
        }
        else
        {
            audioManager.SetMute(true);
            color.a = 0.5f;
            muteButtonImage.color = color;
        }
        

    }
}
