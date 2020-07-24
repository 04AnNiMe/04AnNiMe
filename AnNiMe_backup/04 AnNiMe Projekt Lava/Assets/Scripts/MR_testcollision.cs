using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcollision : MonoBehaviour
{
    public GameObject sphere;
    Rigidbody rb;
    MeshCollider mc;

    // Start is called before the first frame update
    void Start()
    {
        //sphere.transform.Translate(5, 0 ,0);
        mc = sphere.AddComponent<MeshCollider>();
        rb = sphere.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        mc.sharedMesh = sphere.GetComponent<MeshFilter>().mesh;
       // Destroy(sphere.GetComponent<SphereCollider>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
