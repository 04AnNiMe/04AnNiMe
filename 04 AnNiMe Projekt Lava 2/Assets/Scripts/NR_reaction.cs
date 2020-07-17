using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Testcode Kollision- und Berührungsreaktionen
public class NR_reaction : MonoBehaviour
{  
    //GameObject lava;
    GameObject testherz;

    // Testobjekterstellung:
    GameObject sphere; 
    Rigidbody sphereRigid;
    private int sphereX;
    private int sphereZ;
    public MeshCollider herzCollider;   // Herzcollider


    //GameObject score = 0; ??


    // Start is called before the first frame update
    void Start()
    {
        // // Lava:
        // lava = GameObject.CreatePrimitive(PrimitiveType.Plane);
        // lava.name = "Lava";
        // lava.transform.localScale = new Vector3(10,1,10);
        // lava.AddComponent<MeshCollider>();

        // // Material Lava:
        // Renderer rendlava = lava.GetComponent<Renderer>();
        // rendlava.material = new Material(Shader.Find("Diffuse"));
        


        // Testobjekt:
        testherz = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testherz.name = "Spieler";
        testherz.transform.localScale = new Vector3(1,2,1);
        // Material:
        Renderer rend = testherz.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Diffuse"));



        // Collision hinzufügen mit sphere:
        //herzCollider = sphere.AddComponent<MeshCollider>();

        // Testkugeln:
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.name = "Kugel";
        sphere.transform.localScale = new Vector3(1,1,1); 
        sphere.transform.position = new Vector3(1,0.5f,1);
        // für Collision hinzufügen mit sphere:
        sphere.AddComponent<MeshCollider>(); 

        // Testobjekte erstellen
        createSphere(10);
    


        // Score:
       // score = GameObject.Find("Herz").GetComponent<GameObject>();
    }

    void createSphere(int anzahl)
    {
        for (int i = 0; i < anzahl; i++)
        {
            sphereX = Random.Range(-10, 10);
            sphereZ = Random.Range(-10, 10);

            //ein neues GameObject erstellen das eine Instanz von sphere ist
            GameObject cloneObject = Instantiate(sphere, new Vector3(sphereX, 5.0f, sphereZ), sphere.transform.rotation);

            // Rigidbody hinzufügen
            sphereRigid = cloneObject.AddComponent<Rigidbody>();
        }
    }




    // Update is called once per frame
    void Update()
    {
        // Bewegung Testspielfigur:
        testherz.transform.position += testherz.transform.localRotation * new Vector3(0.01f, 0, 0);        
        //Taste "a": Drehung der Orientierung um -90 Grad, nach links
        if (Input.GetKeyDown(KeyCode.A))
        {
            testherz.transform.rotation*=Quaternion.AngleAxis(-90.0f,Vector3.up);
            Debug.Log("A key was pressed. Linksdrehung");
        }

        // Taste "d": Drehung der Orientierung um 90 Grad, nach rechts
        if (Input.GetKeyDown(KeyCode.D))
        {
            testherz.transform.rotation*=Quaternion.AngleAxis(90.0f,Vector3.up);
            Debug.Log("D key was pressed. Rechtsdrehung");
        }

    
    }
}
