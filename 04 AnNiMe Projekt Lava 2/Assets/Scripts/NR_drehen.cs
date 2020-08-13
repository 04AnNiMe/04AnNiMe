using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_drehen : MonoBehaviour
{
    public GameObject drehCube;
    public Texture steintextur;
    Mesh mesh;
   

    // Start is called before the first frame update
    void Start()
    {
        drehCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCube.name = "sich drehender Stein";   
        drehCube.transform.localScale = new Vector3(10, 15, 10);
        
        drehCube.AddComponent<MeshFilter>();     
        drehCube.AddComponent<MeshRenderer>();  
        drehCube.GetComponent<MeshFilter>().mesh = mesh; 

        // Material:
        Renderer rendCube = drehCube.GetComponent<Renderer>();   
        rendCube.material = new Material(Shader.Find("Diffuse"));
        rendCube.material.SetTexture("_MainTex", steintextur);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation gesamt:
        this.transform.Rotate(0,0,-1);
    }
}
