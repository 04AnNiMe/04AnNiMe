using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaboden : MonoBehaviour
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
        Renderer lavamaterial = lava.GetComponent<Renderer>();
        lavamaterial.material = new Material(Shader.Find("Diffuse"));
        lavamaterial.material.SetTexture("_MainTex", lavatextur);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
