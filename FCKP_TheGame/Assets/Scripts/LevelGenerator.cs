using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platfromPrefab;
    public GameObject platformGhostPrefab;
    public GameObject bonusPrefab;
    public GameObject damagePrefab;
    public GameObject player;
    public Text scoreText;

    private float originHeight;

    private Vector2 levelBounds;
    private float minY;
    private float maxY;

    //to spawn bottles every 8 seconds
    private float spawnRate = 8f;
    private float nextSpawn = 0f;

    void Start()
    {
        AudioManager.instance.Play(PlayerPrefs.GetString("currentLevel")+"_theme");


        originHeight = transform.position.y;
        levelBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minY = 0f;
        maxY = levelBounds.y / 2;

        GeneratePlatforms(3);
        GenerateBonus(1);
        GeneratePlatforms(3);
        GenerateBonus(1);
        GeneratePlatforms(3);
        GenerateBonus(1);
    }

    void Update()
    {
        int res = 0;
        Int32.TryParse(scoreText.text, out res);
        if (res < 30000)
        {
            GenerateDamage(1);
        }
        else
        {
            GenerateDamage(2);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Platform_Ghost")
        {
            float chance = Random.value;
            if (chance <= 0.35)
            {
                GenerateBonus(1);
            }

            int res = 0;
            Int32.TryParse(scoreText.text, out res);

            if (res >= 20000 && chance <= 0.25)
            {
                GenerateGhostPlatforms(1);
            }
            GeneratePlatforms(1);

        }
        else if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D playerBody = collision.GetComponent<Rigidbody2D>();
            if (player != null)
            {
                AudioManager.instance.Play("Damage");
                AudioManager.instance.Stop(PlayerPrefs.GetString("currentLevel") + "_theme");


                SceneManager.LoadScene("Dead");
                return;
            }
        }
        Destroy(collision.gameObject);
    }

    
    void GenerateBonus(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-levelBounds.x, levelBounds.x), Random.Range(minY, maxY));
            spawnPos.y += originHeight;
            Instantiate(bonusPrefab, spawnPos, Quaternion.identity);
        }
    }

    
    void GeneratePlatforms(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-levelBounds.x, levelBounds.x), Random.Range(minY, maxY));
            spawnPos.y += originHeight;
            Instantiate(platfromPrefab, spawnPos, Quaternion.identity);
            originHeight = spawnPos.y;
        }
    }

    void GenerateGhostPlatforms(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-levelBounds.x, levelBounds.x), Random.Range(minY, maxY));
            spawnPos.y += originHeight;
            Instantiate(platformGhostPrefab, spawnPos, Quaternion.identity);
            originHeight = spawnPos.y;
        }
    }


    void GenerateDamage(int number)
    {
        if (Time.timeSinceLevelLoad > 8 && Time.timeSinceLevelLoad > nextSpawn)
        {
            for (int i = 0; i < number; i++)
            {
                Vector2 spawnPos = new Vector2(Random.Range(-levelBounds.x, levelBounds.x), (levelBounds.y + transform.position.y));
                Instantiate(damagePrefab, spawnPos, Quaternion.identity);
            }
                    
            nextSpawn = Time.timeSinceLevelLoad + spawnRate;
            if (spawnRate > 3f)
            {
                spawnRate -= 0.2f;
            }
        }
        
    }
}
