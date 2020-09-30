using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_Sounds : MonoBehaviour
{
    GameObject empty;
    GameObject empty2;
    GameObject empty3;
    GameObject musik;
    AudioSource audioSource3;

    // Start is called before the first frame update
    void Start()
    {
        musik = new GameObject("Hintergrundmusik");
        AudioSource audioSource5 = musik.AddComponent<AudioSource>();
        var audioClip5 = Resources.Load<AudioClip>("Sounds/music");
        audioSource5.clip = audioClip5;
        audioSource5.volume = 0.1f;
        audioSource5.loop = true;
        musik.gameObject.GetComponent<AudioSource>().Play();

        empty = new GameObject("JumpSound");
        AudioSource audioSource = empty.AddComponent<AudioSource>();
        var audioClip = Resources.Load<AudioClip>("Sounds/jump2");
        audioSource.clip = audioClip;
        audioSource.volume = 0.1f;


        empty2 = new GameObject("LavaSound");
        AudioSource audioSource2 = empty2.AddComponent<AudioSource>();
        var audioClip2 = Resources.Load<AudioClip>("Sounds/lava");
        audioSource2.clip = audioClip2;


        empty3 = new GameObject("BootSound");
        audioSource3 = empty3.AddComponent<AudioSource>();
        var audioClip3 = Resources.Load<AudioClip>("Sounds/boot");
        audioSource3.clip = audioClip3;
        audioSource3.volume = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
    
         if(Input.GetKeyDown("space"))
        {
            empty.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.name == "Herz")
         {
            other.gameObject.transform.position += new Vector3(0,1000,0);
            Destroy(other.gameObject, 3.0f);
            other.gameObject.GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.name == "Herz_right")
         {
            other.gameObject.transform.position += new Vector3(0,1000,0);
            Destroy(other.gameObject, 3.0f);
            other.gameObject.GetComponent<AudioSource>().Play();
        }

         if (other.gameObject.name == "Karotte")
         {
            other.gameObject.transform.position += new Vector3(0,1000,0);
            Destroy(other.gameObject, 3.0f);
            other.gameObject.GetComponent<AudioSource>().Play();
         }

        if (other.gameObject.name == "Lava")
        {
            //Debug.Log("blubb");
            empty2.gameObject.GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.tag == "boot" || other.gameObject.tag == "boot2")
        {
            empty3.gameObject.GetComponent<AudioSource>().Play();
        }

        //  if (other.gameObject.tag == "destinyBoot" || 
        //      other.gameObject.tag == "destinyBoot2" ) 
        
        // {
        //     Debug.Log("shut up");
        // }

        if (other.gameObject.name == "GoldenCarrott")
        {
            other.gameObject.transform.position += new Vector3(0,1000,0);
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 5.0f);
        }

        if(other.gameObject.tag == "knopf1" || other.gameObject.tag == "knopf2" )
        {
            //Debug.Log("beeep");
            other.gameObject.GetComponent<AudioSource>().Play();

        }

        if (other.gameObject.name == "Checkpoint_Knopf_0" || 
            other.gameObject.name == "Checkpoint_Knopf_1" || 
            other.gameObject.name == "Checkpoint_Knopf_2" || 
            other.gameObject.name == "Checkpoint_Knopf_3" || 
            other.gameObject.name == "Checkpoint_Knopf_4" || 
            other.gameObject.name == "Checkpoint_Knopf_5" || 
            other.gameObject.name == "Checkpoint_Knopf_6")
        {
            //Debug.Log("check");
            other.gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
