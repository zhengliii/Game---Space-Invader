using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public float view_value = 1f;
    public float move_speed = 1f;

    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        // Scale
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            this.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * view_value));
        }
        // Translate
        if (Input.GetMouseButton(2))
        {
            this.transform.Translate(Vector3.left * Input.GetAxis("Mouse X") * move_speed);
            this.transform.Translate(Vector3.up * Input.GetAxis("Mouse Y") * -move_speed);
        }
        // Rotate
        if (Input.GetMouseButton(1))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 5);
            this.transform.RotateAround(this.transform.position, Vector3.right, Input.GetAxis("Mouse Y") * 5);
        }
    }
}
