using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public static PlayerShip instance;
    public GameObject Bullet;
    public float speed = 70f;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z += 0.16f;
            Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
            GameObject obj = Instantiate(Bullet, spawnPos, rot) as GameObject;
            Bullet b = obj.GetComponent<Bullet>();
        }
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, -3f, 3f), 0f, 0f);
    }

    void Awake()
    {
        instance = this;
        rigidbody = GetComponent<Rigidbody>();
       
    }

    void FixedUpdate()
    {
        float dx = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = Vector3.right * dx * speed * Time.deltaTime;
    }
    public void Die()
    {
        SoundManager.instance.PlayExplosion();
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        Global.livesRemaining --;
        g.CreatePlayer();
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide!");
        Collider collider = collision.collider;
        if (collider.CompareTag("EnemyBullet"))
        {
            Debug.Log("Collide with " + collider.tag);
            EnemyBullet enemyBullet = collider.gameObject.GetComponent<EnemyBullet>();
            enemyBullet.Die();
            Die();
        }
    }
}
