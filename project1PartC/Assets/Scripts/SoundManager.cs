using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource AS;
    public AudioClip clipShoot, clipExplosion, clipInvaderKilled;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        instance = this;
        AS = GetComponent<AudioSource>();

    }
    public void PlayShoot()
    {
        AS.PlayOneShot(clipShoot);
    }

    public void PlayExplosion()
    {
        AS.PlayOneShot(clipExplosion);
    }
    public void PlayInvaderKilled()
    {
        AS.PlayOneShot(clipInvaderKilled);
    }
}
