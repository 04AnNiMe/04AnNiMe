using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcollision : MonoBehaviour
{
    GameObject snakee;
    // Start is called before the first frame update
    void Start()
    {
        //Ground
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ground.name = "ground";
        ground.transform.localScale = new Vector3(-10.0f*2,0.1f,10.0f*2);
        ground.AddComponent<MeshCollider>();

        
        //Spieler
        snakee = GameObject.CreatePrimitive(PrimitiveType.Cube);
        snakee.name = "Cube";
        Rigidbody rb=  snakee.AddComponent<Rigidbody>();
        rb.isKinematic = false;

        //Kugeln
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.name = "Sphere";
        sphere.transform.Translate(10, 0 ,0);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Bei Berührung einer Kugel soll diese Zerstört werden
        // if (other.gameObject.name == "Sphere")
        // {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            Destroy(other);
        // }
    }

    // Update is called once per frame
    void Update()
    {
         
       //Steuerung:
       snakee.transform.position += snakee.transform.localRotation * new Vector3(0.01f, 0, 0);

        if(Input.GetKeyDown(KeyCode.A)) {
            snakee.transform.position += snakee.transform.localRotation * new Vector3(0.001f, 0, 0);
            snakee.transform.rotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.D)) {
            snakee.transform.rotation *= Quaternion.AngleAxis(90, Vector3.up);
        }
    }
}
