﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code für Lavagrundplatte: 
public class NR_lavaplane : MonoBehaviour
{

    GameObject lava;
    MeshCollider nlava;

    // über Gui zugewiesen:
    public Texture lavatextur;


    // Start is called before the first frame update
    void Start()
    {
        // Lavaplatte:
        lava = GameObject.CreatePrimitive(PrimitiveType.Plane);
        lava.name = "Lava";
        lava.transform.position = new Vector3(175.0f, 3.0f, 175.0f);
        lava.transform.localScale += new Vector3(35.0f, 1.0f, 35.0f);

        nlava = lava.AddComponent<MeshCollider>();
        nlava.sharedMesh = lava.GetComponent<MeshFilter>().mesh;
        Destroy(lava.GetComponent<MeshCollider>());
        nlava.convex = true;
        nlava.isTrigger = true;

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
