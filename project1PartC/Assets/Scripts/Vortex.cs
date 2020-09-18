using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vortex : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer SR;
    float currTime;
    public float dt = 0.3f;
    public Sprite sprite1;
    Sprite sprite0;
    public Vector3 thrust;
    void Start()
    {
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ExchangeSprite();
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
        }
        else if (currTime < 2 * dt)
        {
            SR.sprite = sprite1;
        }
        else
        {
            currTime = 0;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("BulletsOnGround"))
        {
            EnemyBullet enemyBullet = collider.gameObject.GetComponent<EnemyBullet>();
            enemyBullet.Die();
        }
        if (collider.CompareTag("EnemyOnGround"))
        {
            Alien alien = collider.gameObject.GetComponent<Alien>();
            alien.Die();
        }
    }
}
