using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NR_Collisionen : MonoBehaviour
{

    public NR_gui guiScript;
    public MR_carott guiScript2;

    public AM_respawnPoint respawnScript;
        
    // Start is called before the first frame update
    void Start()
    {

        //respawnScript = GameObject.Find("RabbitWarrior01").GetComponent<AM_respawnPoint>();
        // verlinken:
        guiScript = GameObject.Find("NR_GuiEmpty").GetComponent<NR_gui>();
        guiScript2 = GameObject.Find("MR_karotten").GetComponent<MR_carott>();
        respawnScript = gameObject.GetComponent<AM_respawnPoint>();

    }

    // Bei Berührung Triggern
    private void OnTriggerEnter(Collider other)
    {
        // Bei Berührung eines Herzens soll dieses zerstört werden
         if (other.gameObject.name == "Herz")
         {
            Debug.Log(this.name + " bekommt ein " + other.gameObject.name);
            Destroy(other.gameObject);
            guiScript.leben++;
        }

        // Bei Berührung einer Karotte soll dieses eingesammelt werden
         if (other.gameObject.name == "KarottenEmpty")
         {
            Debug.Log(this.name + " bekommt eine " + other.gameObject.name);
            Destroy(other.gameObject);
            guiScript.collectedItems++;
        }

        // Bei Kollision mit der Lava: Leben--
        if (other.gameObject.name == "Lava")
        {
            Debug.Log(this.name + " triggert " + other.gameObject.name);
            guiScript.leben--;

            respawnScript.teleport();

                //if (guiScript.leben == 0)
                //{
                //    Debug.Log("Tot");
                //    Scene thisScene = SceneManager.GetActiveScene();
                //    SceneManager.LoadScene(thisScene.name);
                //}
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
