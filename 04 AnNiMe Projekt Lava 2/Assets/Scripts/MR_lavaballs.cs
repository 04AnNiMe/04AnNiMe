using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_lavaballs : MonoBehaviour
{
    GameObject lavakugel, lavakugel2, lavakugel3, lavakugel4;
    BoxCollider lc, lc2, lc3, lc4;
    Rigidbody rig, rig2, rig3, rig4;

    public GameObject lavaBallCollisionGo;
    MR_lavaBallCollision lavaBallScript;

    float time = 0.0f;

    public Texture texture;

    // Start is called before the first frame update
    void Start()
    {
        lavaBallScript = lavaBallCollisionGo.GetComponent<MR_lavaBallCollision>();

        //Kugel1
        lavakugel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lavakugel.name = "Kugel1";
        lc = lavakugel.AddComponent<BoxCollider>();
        lc.isTrigger = true;
        lavakugel.transform.position = new Vector3(72, 2.0f, 20.2f);
        lavakugel.AddComponent<Rigidbody>();
        rig = lavakugel.GetComponent<Rigidbody>();
        rig.isKinematic = true;
        lavakugel.GetComponent<Renderer>().material.color = Color.red;
        Renderer(lavakugel);       
        Audio(lavakugel);   


        //Kugel2
        lavakugel2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lavakugel2.name = "Kugel2";
        lc2 = lavakugel2.AddComponent<BoxCollider>();
        lc2.isTrigger = true;
        lavakugel2.transform.position = new Vector3(75, 2.0f, 18.0f);
        rig2 = lavakugel2.AddComponent<Rigidbody>();
        rig2 = lavakugel2.GetComponent<Rigidbody>();
        rig2.isKinematic = true;
        lavakugel2.GetComponent<Renderer>().material.color = Color.red;
        Renderer(lavakugel2);       
        Audio(lavakugel2);   


        //Kugel3
        lavakugel3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lavakugel3.name = "Kugel3";
        lc3 = lavakugel3.AddComponent<BoxCollider>();
        lc3.isTrigger = true;
        lavakugel3.transform.position = new Vector3(76, 2.0f, 18.0f);
        rig3 = lavakugel3.AddComponent<Rigidbody>();
        rig3 = lavakugel3.GetComponent<Rigidbody>();
        rig3.isKinematic = true;
        lavakugel3.GetComponent<Renderer>().material.color = Color.red;
        Renderer(lavakugel3);       
        Audio(lavakugel3);   

        //Kugel4
        lavakugel4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lavakugel4.name = "Kugel4";
        lc4 = lavakugel4.AddComponent<BoxCollider>();
        lc4.isTrigger = true;
        lavakugel4.transform.position = new Vector3(78, 2.0f, 18.0f);
        rig4 = lavakugel4.AddComponent<Rigidbody>();
        rig4 = lavakugel4.GetComponent<Rigidbody>();
        rig4.isKinematic = true;
        Renderer(lavakugel4);    
        Audio(lavakugel4);   

       // m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
   
    }

    void Audio(GameObject gameobject)
    {
        AudioSource audioSource = gameobject.AddComponent<AudioSource>();
        var audioClip = Resources.Load<AudioClip>("Sounds/lava");
        audioSource.clip = audioClip;
        audioSource.volume = 0.1f;
    }

    void Renderer(GameObject gameobject)
    {
        Renderer rend = gameobject.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.mainTexture = texture;
    }

    void Animation(GameObject gameobject, float x, float y, float z) //Koordinaten, wo die Kugel aufkommen soll
    {
        gameobject.transform.position = Vector3.Lerp(gameobject.transform.position, 
        new Vector3(x, y+30, z), Time.deltaTime * 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(lavaBallScript.kugelattack)
        {
            time += Time.deltaTime;

            //Kugel1
            if(time >= 3.0f && time <= 5.0f)
            {
                Debug.Log("1");
                Animation(lavakugel, 78.0f, 5.0f, 30.0f);
                rig.isKinematic = false;
            }

            //Kugel 2
            if(time >= 2.0f && time <= 4.0f)
            {
                Debug.Log("2");
                Animation(lavakugel2, 80.0f, 5.0f, 30.0f);
                rig2.isKinematic = false;
            }

            //Kugel 3
            if(time >= 2.5f && time <= 4.5f)
            {
                Debug.Log("3");
                Animation(lavakugel3, 82.0f, 5.0f, 30.0f);
                rig3.isKinematic = false;
            }

            //Kugel 4
            if(time >= 1.0f && time <= 3.0f)
            {
                Debug.Log("4");
                Animation(lavakugel4, 85.0f, 5.0f, 30.0f);
                rig4.isKinematic = false;
            }
        }
    }

            
    
}
