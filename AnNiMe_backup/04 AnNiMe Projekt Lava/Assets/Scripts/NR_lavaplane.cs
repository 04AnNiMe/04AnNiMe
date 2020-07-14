using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code für Lavagrundplatte: 
public class NR_lavaplane : MonoBehaviour
{

    GameObject lava;

    // über Gui zugewiesen:
    public Texture lavatextur;


    // Start is called before the first frame update
    void Start()
    {
        // Lavaplatte:
        lava = GameObject.CreatePrimitive(PrimitiveType.Plane);
        lava.transform.position = new Vector3(-3.0f, 0.0f, -3.0f);
        lava.transform.localScale += new Vector3(5.0f, 0.0f, 5.0f);

        // Material:
        Renderer lavaboden = lava.GetComponent<Renderer>();
        lavaboden.material = new Material(Shader.Find("Diffuse"));
        lavaboden.material.SetTexture("_MainTex", lavatextur);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
