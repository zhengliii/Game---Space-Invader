using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SwitchScene1", 1f);
    }

    void SwitchScene1()
    {
        SceneManager.LoadScene("Level1");
    }
    
}
