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
    float dropTime;
    public int score;
    public GameObject EnemyBullet;
    Rigidbody rigidbody;
    public Vector3 thrust;
    public GameObject Explosion;
    void Start()
    {
        currTime = 0;
        dropTime = 0;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ExchangeSprite();
        if (gameObject.tag == "Enemy" && rigidbody.position.z <= 0.3f)
        {
            Invoke("SwitchScene3", 1f);
        }
        if (rigidbody.position.z < 0f)
        {
            transform.position = new Vector3(rigidbody.position.x, rigidbody.position.y, 0f);
        }
        if (gameObject.tag == "EnemyOnGround")
        {
            dropTime += Time.deltaTime;
            if (dropTime > 4f)
            {
                GameObject obj = GameObject.Find("GlobalObject");
                Global g = obj.GetComponent<Global>();
                g.enemiesRemaining--;
                g.aliens.Remove(this);
                Instantiate(Explosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
                Destroy(gameObject);
            }
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
    public void Fall()
    {
        thrust.z = -200f;
        rigidbody.AddForce(thrust);
        SoundManager.instance.PlayInvaderKilled();
        gameObject.tag = "EnemyOnGround";
        Debug.Log(gameObject.tag);
    }
}
