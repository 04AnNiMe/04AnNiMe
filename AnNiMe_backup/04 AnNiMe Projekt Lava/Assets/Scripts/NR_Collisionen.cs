using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NR_Collisionen : MonoBehaviour
{

    public NR_gui script;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Bei Berührung Triggern
    private void OnTriggerEnter(Collider other)
    {
        // // Bei Berührung eines Herzens soll dieses zerstört werden (Test: Herz hier Kugel)
        // if (other.gameObject.name == "Kugel")
        // {
        //     Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
        //     //Destroy(other);
        //     //score.leben++;
        // }

        // Bei Kollision mit der Kugel (Lava): Leben--
        if (other.gameObject.name == "Lava")
        {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            script.leben = 0;
            //score.leben--;
            //score.collectedItems = 0;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        // if (script.leben == 0)
        // {
        //     Debug.Log("Tot");
        //     Scene thisScene = SceneManager.GetActiveScene();
        //     SceneManager.LoadScene(thisScene.name);
        // }
        
    }
}
