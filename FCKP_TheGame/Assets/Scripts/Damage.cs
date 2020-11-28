using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Damage");
            FindObjectOfType<AudioManager>().Stop(PlayerPrefs.GetString("currentLevel") + "_theme");
            SceneManager.LoadScene("Dead");
        }
    }
}
