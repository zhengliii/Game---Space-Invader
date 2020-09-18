using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer SR;
    public Sprite sprite1;
    Sprite sprite0;
    public float dt = 0.3f;
    float currTime;
    public int score;
    public GameObject EnemyBullet;
    void Start()
    {
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ExchangeSprite();
        if (transform.position.z <= 0.3)
        {
            Debug.Log("switch");
            Invoke("SwitchScene3", 1f);
        }
    }
    
    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        sprite0 = SR.sprite;
    }

    void ExchangeSprite()
    {
        currTime += Time.deltaTime;
        if (currTime < dt)
        {
            SR.sprite = sprite0;
        }else if (currTime < 2 * dt)
        {
            SR.sprite = sprite1;
        }else {
            currTime = 0;
        }
    }
    public void Die()
    {
        SoundManager.instance.PlayInvaderKilled();
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        Global.score += score;
        g.enemiesRemaining--;
        g.aliens.Remove(this);
        Destroy(gameObject);
    }

    public void Fire()
    {
        Vector3 spawnPos = gameObject.transform.position;
        spawnPos.z -= 0.16f;
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        GameObject obj = Instantiate(EnemyBullet, spawnPos, rot) as GameObject;
        EnemyBullet b = obj.GetComponent<EnemyBullet>();
    }
    void SwitchScene3()
    {
        SceneManager.LoadScene("Level3");
    }
}
