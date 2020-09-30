using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_AudioManager : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Stop();
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.Play();

    }

}