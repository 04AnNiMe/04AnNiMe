using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AM_timeStop : MonoBehaviour
{
    AM_plattformen platten;
    public float timer;
    public Material standardMat;
    public Material stopMat;
    AudioSource tickSound;

    // Start is called before the first frame update
    void Start()
    {
        platten = GameObject.Find("AM_Empty Plattformen").GetComponent<AM_plattformen>();
        GetComponent<Renderer>().material = standardMat;

        tickSound = GetComponent<AudioSource>();
        tickSound.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        platten.timestop = true;
        tickSound.Play();
    }

    void stoptime()
    {
        timer += Time.deltaTime;

        if (timer >= 6)
        {
            platten.timestop = false;
            GetComponent<Renderer>().material = standardMat;
            tickSound.Stop();
            timer = 0;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (platten.timestop == true)
        {
            GetComponent<Renderer>().material = stopMat;
            stoptime();
        }
    }
}
