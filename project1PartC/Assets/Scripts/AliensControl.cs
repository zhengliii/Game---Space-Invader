using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensControl : MonoBehaviour
{
    public float direction = 1f;
    public float hStep = 0.2f;
    public float vStep = 0.1f;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            transform.Translate(hStep * direction * Time.deltaTime, 0, 0);
            if (transform.position.x > 0.8 || transform.position.x < -0.8)
            {
                direction = -direction;
                //transform.Translate(0, 0, -2f * Time.deltaTime);
                transform.position -= new Vector3(0, 0, vStep);
                hStep += 0.08f;
                Invoke("Delay", 1);
            }
        }
    }

    void Delay()
    {
    }
}
