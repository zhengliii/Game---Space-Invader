using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch12 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        Global.score = 0;
        Global.livesRemaining = 3;
    }

    void OnClick()
    {
        SceneManager.LoadScene("Level2");
    }

    // Update is called once per frame
    void Update()
    {

    }
}