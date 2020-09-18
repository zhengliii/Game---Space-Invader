using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{ 
    // Start is called before the first frame update
    Rigidbody rigidbody;
    public Vector3 thrust;

    // Start is called before the first frame update
    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        thrust.z = -100f;
        rigidbody.AddForce(thrust);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.position.z > 3.2f || rigidbody.position.z < 0.0f)
        {
            transform.position = new Vector3(rigidbody.position.x, rigidbody.position.y, 0f);
            gameObject.tag = "BulletsOnGround";
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
