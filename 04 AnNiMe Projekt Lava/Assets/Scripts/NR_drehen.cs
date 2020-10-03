using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_drehen : MonoBehaviour
{
    public GameObject drehCube;
    public GameObject drehCubeZwei;
    public GameObject drehCubeDrei;
    public GameObject drehCubeVier;
    public GameObject drehCubeFuenf;
    public GameObject drehCubeSechs;
    public GameObject drehCubeSieben;
    public GameObject drehCubeAcht;
    public Texture steintextur;
    public GameObject Player;

    // // Geschwindigkeit:
    // private float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // erster Cube:
        drehCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCube.name = "sich drehender Stein 01";   
        drehCube.transform.localScale = new Vector3(4, 3, 4);
        drehCube.transform.position = new Vector3(71.5f, 3, 147.5f);

        // Material:
        Renderer rend = drehCube.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", steintextur);
 


        // zweiter Cube:
        drehCubeZwei = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCubeZwei.name = "sich drehender Stein 02";   
        drehCubeZwei.transform.localScale = new Vector3(4, 3, 4);
        drehCubeZwei.transform.position = new Vector3(152.5f, 3, 185.5f);
       
        // Material:
        Renderer rendz = drehCubeZwei.GetComponent<Renderer>();   
        rendz.material = new Material(Shader.Find("Diffuse"));
        rendz.material.SetTexture("_MainTex", steintextur);



        // dritter Cube:
        drehCubeDrei = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCubeDrei.name = "sich drehender Stein 03";   
        drehCubeDrei.transform.localScale = new Vector3(4, 3, 4);
        drehCubeDrei.transform.position = new Vector3(162.5f, 3, 188.5f);
       
        // Material:
        Renderer rendd = drehCubeDrei.GetComponent<Renderer>();   
        rendd.material = new Material(Shader.Find("Diffuse"));
        rendd.material.SetTexture("_MainTex", steintextur);



        // vierter Cube:
        drehCubeVier = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCubeVier.name = "sich drehender Stein 04";   
        drehCubeVier.transform.localScale = new Vector3(4, 3, 4);
        drehCubeVier.transform.position = new Vector3(165.0f, 3, 183.5f);
       
        // Material:
        Renderer rendv = drehCubeVier.GetComponent<Renderer>();   
        rendv.material = new Material(Shader.Find("Diffuse"));
        rendv.material.SetTexture("_MainTex", steintextur);



        // fünfter Cube:
        drehCubeFuenf = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCubeFuenf.name = "sich drehender Stein 05";   
        drehCubeFuenf.transform.localScale = new Vector3(4, 3, 4);
        drehCubeFuenf.transform.position = new Vector3(170.0f, 3, 182.5f);
       
        // Material:
        Renderer rendf = drehCubeFuenf.GetComponent<Renderer>();   
        rendf.material = new Material(Shader.Find("Diffuse"));
        rendf.material.SetTexture("_MainTex", steintextur);



        // sechster Cube:
        drehCubeSechs = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCubeSechs.name = "sich drehender Stein 06";   
        drehCubeSechs.transform.localScale = new Vector3(4, 3, 4);
        drehCubeSechs.transform.position = new Vector3(157.5f, 3, 182.5f);
       
        // Material:
        Renderer rends = drehCubeSechs.GetComponent<Renderer>();   
        rends.material = new Material(Shader.Find("Diffuse"));
        rends.material.SetTexture("_MainTex", steintextur);



        // achter Cube:
        drehCubeAcht = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCubeAcht.name = "sich drehender Stein 08";   
        drehCubeAcht.transform.localScale = new Vector3(4, 3, 4);
        drehCubeAcht.transform.position = new Vector3(157.5f, 3, 187.5f);
       
        // Material:
        Renderer renda = drehCubeAcht.GetComponent<Renderer>();   
        renda.material = new Material(Shader.Find("Diffuse"));
        renda.material.SetTexture("_MainTex", steintextur);



        // siebter Cube:
        drehCubeSieben = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drehCubeSieben.name = "sich drehender Stein 07";   
        drehCubeSieben.transform.localScale = new Vector3(4, 3, 4);
        drehCubeSieben.transform.position = new Vector3(170.0f, 3, 187.5f);
       
        // Material:
        Renderer rendsi = drehCubeSieben.GetComponent<Renderer>();   
        rendsi.material = new Material(Shader.Find("Diffuse"));
        rendsi.material.SetTexture("_MainTex", steintextur);


        // Verbinden mit Script:
        drehCube.AddComponent<AM_charHolder>();
    }

    
    // Update is called once per frame
    void Update()
    {
            // Rotation gesamt:
            drehCube.transform.Rotate(0, 0, 1);
            drehCubeZwei.transform.Rotate(0, 0, -1);
            drehCubeDrei.transform.Rotate(0, 0, 1);
            drehCubeVier.transform.Rotate(0, 0, -1);
            drehCubeFuenf.transform.Rotate(0, 0, 1);
    }
}
