using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaction : MonoBehaviour
{

   
    GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        // Kugel:
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
        // Material:
        Renderer rend = sphere.GetComponent<MeshRenderer>();
        rend.material = new Material(Shader.Find("Diffuse"));
        rend = stadt.GetComponent<MeshFilter>().mesh; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
