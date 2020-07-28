using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NR_Collisionen : MonoBehaviour
{

    public NR_gui guiScript;

    
    // Start is called before the first frame update
    void Start()
    {
        // verlinken:
        guiScript = GameObject.Find("NR_GuiEmpty").GetComponent<NR_gui>();
    }

    // Bei Berührung Triggern
    private void OnTriggerEnter(Collider other)
    {
        // Bei Berührung eines Herzens soll dieses zerstört werden
         if (other.gameObject.name == "Herz")
         {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            Destroy(other);
            guiScript.leben++;
        }

        // Bei Berührung einer Karotte soll dieses eingesammelt werden
         if (other.gameObject.name == "karotte")
         {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            guiScript.collectedItems++;
            //script.collectedItems = 0;
        }

        // Bei Kollision mit der Kugel (Lava): Leben--
        if (other.gameObject.name == "Lava")
        {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            guiScript.leben--;

                if (guiScript.leben == 0)
                {
                    Debug.Log("Tot");
                    Scene thisScene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(thisScene.name);
                }
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
