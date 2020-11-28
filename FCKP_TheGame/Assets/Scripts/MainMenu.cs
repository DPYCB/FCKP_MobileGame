using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videoSource;
    public GameObject videoOutput;

    public TextMeshProUGUI partyLabel;
    public TextMeshProUGUI guruLabel;
    public TextMeshProUGUI likeLabel;
    public TextMeshProUGUI bitardLabel;
    public TextMeshProUGUI barLabel;

    public Image muteButtonImage;

    private string currentLevel;
    private string best = "Рекорд: ";


    private void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Color color = muteButtonImage.color;
        if (audioManager.isMuted == true)
        {
            color.a = 0.25f;
            muteButtonImage.color = color;
        }
        else
        {
            color.a = 0.5f;
            muteButtonImage.color = color;
        }

        audioManager.Play("MainMenu_theme");
        setLabels();
        videoPlayer.Prepare();
        videoOutput.SetActive(false);
    }
    private void Update()
    {
        if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
        {
            SceneManager.LoadScene(currentLevel);
        }
    }

    private void setLabels()
    {
        string partyHigh = PlayerPrefs.GetString("PartyLevelHighScore");
        string guruHigh = PlayerPrefs.GetString("GuruLevelHighScore");
        string likeHigh = PlayerPrefs.GetString("LikeLevelHighScore");
        string bitardHigh = PlayerPrefs.GetString("BitardLevelHighScore");
        string barHigh = PlayerPrefs.GetString("BarLevelHighScore");

        partyLabel.text = best + partyHigh;
        guruLabel.text = best + guruHigh;
        likeLabel.text = best + likeHigh;
        bitardLabel.text = best + bitardHigh;
        barLabel.text = best + barHigh;
    }

    public void StartPartyLevel()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu_theme");

        FindObjectOfType<AudioManager>().Play("Button");
        PlayerPrefs.SetString("currentLevel", "PartyLevel");
        currentLevel = "PartyLevel";
        videoPlayer.clip = videoSource[0];
        if (partyLabel.text == best)
        {
            videoOutput.SetActive(true);
            videoPlayer.SetDirectAudioVolume(0, 0.1f);
            videoPlayer.Play();
        }
        else
        {
            SceneManager.LoadScene(currentLevel);
        }
    }

    public void StartGuruLevel()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu_theme");

        FindObjectOfType<AudioManager>().Play("Button");
        PlayerPrefs.SetString("currentLevel", "GuruLevel");
        currentLevel = "GuruLevel";
        videoPlayer.clip = videoSource[1];
        if (guruLabel.text == best)
        {
            videoOutput.SetActive(true);
            videoPlayer.SetDirectAudioVolume(0, 0.1f);
            videoPlayer.Play();
        }
        else
        {
            SceneManager.LoadScene(currentLevel);
        }
    }
    public void StartLikeLevel()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu_theme");

        FindObjectOfType<AudioManager>().Play("Button");
        PlayerPrefs.SetString("currentLevel", "LikeLevel");
        currentLevel = "LikeLevel";
        videoPlayer.clip = videoSource[2];
        if (likeLabel.text == best)
        {
            videoOutput.SetActive(true);
            videoPlayer.SetDirectAudioVolume(0, 0.1f);
            videoPlayer.Play();
        }
        else
        {
            SceneManager.LoadScene(currentLevel);
        }
    }    

    public void StartBitardLevel()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu_theme");

        FindObjectOfType<AudioManager>().Play("Button");
        PlayerPrefs.SetString("currentLevel", "BitardLevel");
        currentLevel = "BitardLevel";
        videoPlayer.clip = videoSource[3];
        if (bitardLabel.text == best)
        {
            videoOutput.SetActive(true);
            videoPlayer.SetDirectAudioVolume(0, 0.1f);
            videoPlayer.Play();
        }
        else
        {
            SceneManager.LoadScene(currentLevel);
        }
    }

    public void StartBarLevel()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu_theme");

        FindObjectOfType<AudioManager>().Play("Button");
        PlayerPrefs.SetString("currentLevel", "BarLevel");
        currentLevel = "BarLevel";
        videoPlayer.clip = videoSource[4];
        if (barLabel.text == best)
        {
            videoOutput.SetActive(true);
            videoPlayer.SetDirectAudioVolume(0, 0.1f);
            videoPlayer.Play();
        }
        else
        {
            SceneManager.LoadScene(currentLevel);
        }
    }

    public void SetMute()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Color color = muteButtonImage.color;
        if (audioManager.isMuted == true)
        {
            audioManager.SetMute(false);
            videoPlayer.SetDirectAudioMute(0, false);
            color.a = 0.5f;
            muteButtonImage.color = color;
        }
        else
        {
            audioManager.SetMute(true);
            videoPlayer.SetDirectAudioMute(0, true);
            color.a = 0.25f;
            muteButtonImage.color = color;
        }
    }
}
