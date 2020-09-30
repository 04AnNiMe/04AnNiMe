using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NR_Collisionen : MonoBehaviour
{

    public AM_end guiScript;
    public AM_respawnPoint respawnScript;

    public GameObject fass;
    bool fassfahrt = false;
        
    // Start is called before the first frame update
    void Start()
    {
        //respawnScript = GameObject.Find("RabbitWarrior01").GetComponent<AM_respawnPoint>();
        // verlinken:
        guiScript = GameObject.Find("AM_Teleportplatte").GetComponent<AM_end>();
        respawnScript = gameObject.GetComponent<AM_respawnPoint>();
        fass.AddComponent<AM_charHolder>();
    }

    // Bei Berührung Triggern
    private void OnTriggerEnter(Collider other)
    {
        // Bei Berührung eines Herzens soll dieses zerstört werden
         if (other.gameObject.name == "Herz")
         {
            Debug.Log(this.name + " bekommt ein " + other.gameObject.name);
           // Destroy(other.gameObject);
            guiScript.hearts++;
        }

        if (other.gameObject.name == "Herz_right")
         {
            Debug.Log(this.name + " bekommt ein " + other.gameObject.name);
            //Destroy(other.gameObject);
            guiScript.hearts++;
        }


        // Bei Berührung einer Karotte soll dieses eingesammelt werden
         if (other.gameObject.name == "Karotte")
         {
            Debug.Log(this.name + " bekommt eine " + other.gameObject.name);
            guiScript.carrots++;
        }

        // Bei Kollision mit der Lava: Leben--
        if (other.gameObject.name == "Lava")
        {
            Debug.Log(this.name + " triggert " + other.gameObject.name);
            guiScript.hearts--;

            respawnScript.teleport();
        }

        if(other.gameObject.name == "NR_Fass" )
        {
            fassfahrt = true;
            Debug.Log("Collision mit Boot");
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if(fassfahrt == true)
        {
            fass.transform.position = Vector3.Lerp(fass.transform.position, 
            new Vector3(72, 3, 20.2f), Time.deltaTime * 0.8f);
        }
        
    }
}
