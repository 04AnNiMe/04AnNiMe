using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_lavaBallCollision : MonoBehaviour
{
    public bool kugelattack = false;
    public AM_end guiScript;


    // Start is called before the first frame update
    void Start()
    {
        guiScript = GameObject.Find("AM_Teleportplatte").GetComponent<AM_end>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "kugeltrigger")
        {
            Debug.Log("Kugelattack");
            kugelattack = true;
        }
        
        if(other.gameObject.name == "Kugel1" || other.gameObject.name == "Kugel2" || other.gameObject.name == "Kugel3" || other.gameObject.name == "Kugel4" )
        {
            guiScript.hearts--;
            other.gameObject.transform.position += new Vector3(0,1000,0);
            Destroy(other.gameObject, 3.0f);
            other.gameObject.GetComponent<AudioSource>().Play();
        }


    }
}
