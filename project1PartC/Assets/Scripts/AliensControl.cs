﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensControl : MonoBehaviour
{
    public float direction = 1f;
    public float hStep = 0.15f;
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
                transform.position = new Vector3(direction * 0.8f, 0, transform.position.z - vStep);
                direction = -direction;
                hStep += 0.08f;
            }
        }
    }
}
