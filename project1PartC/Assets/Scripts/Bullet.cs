using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigidbody;
    public Vector3 thrust;
    // Start is called before the first frame update
    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        thrust.z = 100f;
        rigidbody.AddForce(thrust);
        SoundManager.instance.PlayShoot();
    }

    // Update is called once per frame
    void Update()
    {
       if (rigidbody.position.z > 3.2f || rigidbody.position.z < 0.0f)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide!");
        Collider collider = collision.collider;
        if (collider.CompareTag("Enemy") || collider.CompareTag("EnemyOnGround"))
        {
            Debug.Log("Collide with " + collider.tag);
            Alien alien = collider.gameObject.GetComponent<Alien>();
            alien.Fall();
            Destroy(gameObject);
        }
    }
}
