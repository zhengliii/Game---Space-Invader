using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public float timer;
    public static int score;
    public static int livesRemaining;
    public int enemiesRemaining;
    public List<Alien> aliens;
    public GameObject PlayerShip;
    public GameObject UFO;
    public GameObject Star;
    // Use this for initialization

    void Start()
    {
        timer = 0;
        enemiesRemaining = 44;
        aliens = new List<Alien>();
        GameObject[] aliensObj = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject a in aliensObj)
        {
            aliens.Add(a.GetComponent<Alien>());
        }
        InvokeRepeating("FireBullets", 1, 5);
        InvokeRepeating("SpawnUFO", 2, 8);
        InvokeRepeating("SpawnStar", 4, 15);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(livesRemaining <= 0){
            SceneManager.LoadScene("Level3");
        }
        if(enemiesRemaining <= 0)
        {
            SceneManager.LoadScene("Level2");
            livesRemaining++;
        }
    }

    void FireBullets()
    {
        int bullets = Random.Range(1, 5);
        bullets = Mathf.Clamp(bullets, 0, enemiesRemaining);
        for (int i = 0; i < bullets; i++)
        {
            int index = Random.Range(1, enemiesRemaining);

            Alien alienWithBullets = aliens[index];
            alienWithBullets.Fire();
        }
    }

    public void CreatePlayer()
    {
        Invoke("CreatePlayerWithLatency", 1);
    }

    void CreatePlayerWithLatency()
    { 
        if (livesRemaining > 0)
        {
            Vector3 spawnPos = new Vector3(0, 0, 0.1f);
            spawnPos.z -= 0.16f;
            Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
            GameObject obj = Instantiate(PlayerShip, spawnPos, rot) as GameObject;
            PlayerShip p = obj.GetComponent<PlayerShip>();
        }
    }

    void SpawnUFO()
    {
        Vector3 spawnPos = new Vector3(-3f, 0, 3f);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        GameObject obj = Instantiate(UFO, spawnPos, rot) as GameObject;
    }
    void SpawnStar()
    {
        float x = Random.Range(-2.5f, 2.5f);
        float z = Random.Range(0.3f, 1.5f);
        Vector3 spawnPos = new Vector3(x, 0, z);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        GameObject obj = Instantiate(Star, spawnPos, rot) as GameObject;
    }
}
