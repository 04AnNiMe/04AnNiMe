using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_plattformen : MonoBehaviour
{
    Mesh mPlattform;
    GameObject goPlattform;

    List<Vector3> vPlattform;
    List<int> fPlattform;
    List<Vector3> nPlattform;
    List<Vector2> uvPlattform;

    public Texture pTexture;
    public Vector3 position;

    public float hoehe;
    public float breite;
    public float tiefe;

    private float xPos = 0.0f;
    private float yPos = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        vPlattform = new List<Vector3>();
        fPlattform = new List<int>();
        nPlattform = new List<Vector3>();
        uvPlattform = new List<Vector2>();

        goPlattform = new GameObject("Plattform");
        goPlattform.AddComponent<MeshFilter>();
        goPlattform.AddComponent<MeshRenderer>();

        mPlattform = new Mesh();

        goPlattform.GetComponent<MeshFilter>().mesh = mPlattform;

        
        createWeg(1);

    }

    void createWeg(int stufen)
    {
        
        position = new Vector3(325, 4, 18);
        createPlattform(position);

        //for (int i = 0; i < stufen; i++)
        //{
        //    xPos = xPos + 1.1f;
        //    if (i <= stufen / 2)
        //    {
        //        yPos -= 0.3f;
        //    }
        //    else
        //    {
        //        yPos += 0.3f;
        //    }
        //    position = new Vector3(0, yPos, xPos);
        //    createPlattform(position);
        //}
    }

    void createPlattform(Vector3 position)
    {
        Vector3 a = new Vector3(breite, hoehe, tiefe) + position;       //0
        Vector3 b = new Vector3(-breite, hoehe, tiefe) + position;      //1
        Vector3 c = new Vector3(-breite, -1, tiefe) + position;         //2
        Vector3 d = new Vector3(breite, -1, tiefe) + position;          //3
        Vector3 e = new Vector3(-breite, hoehe, -tiefe) + position;     //4
        Vector3 f = new Vector3(breite, hoehe, -tiefe) + position;      //5
        Vector3 g = new Vector3(breite, -1, -tiefe) + position;         //6
        Vector3 h = new Vector3(-breite, -1, -tiefe) + position;        //7

        vPlattform.Add(a);
        vPlattform.Add(b);
        vPlattform.Add(c);
        vPlattform.Add(d);
        vPlattform.Add(e);
        vPlattform.Add(f);
        vPlattform.Add(f);
        vPlattform.Add(g);
        vPlattform.Add(h);

        //North
        fPlattform.Add(0);
        fPlattform.Add(1);
        fPlattform.Add(2);
        fPlattform.Add(0);
        fPlattform.Add(2);
        fPlattform.Add(3);

        //East 12
        fPlattform.Add(0);
        fPlattform.Add(3);
        fPlattform.Add(5);
        fPlattform.Add(5);
        fPlattform.Add(3);
        fPlattform.Add(7);

        ////South 18
        //fPlattform.Add(4);
        //fPlattform.Add(5);
        //fPlattform.Add(6);
        //fPlattform.Add(4);
        //fPlattform.Add(6);
        //fPlattform.Add(7);

        ////West 24
        //fPlattform.Add(1);
        //fPlattform.Add(4);
        //fPlattform.Add(7);
        //fPlattform.Add(1);
        //fPlattform.Add(7);
        //fPlattform.Add(2);

        ////Up 30
        //fPlattform.Add(1);
        //fPlattform.Add(0);
        //fPlattform.Add(5);
        //fPlattform.Add(1);
        //fPlattform.Add(5);
        //fPlattform.Add(4);

        uvPlattform.Add(new Vector2(0.0f, 0.0f));
        uvPlattform.Add(new Vector2(0.0f, 1.0f));
        uvPlattform.Add(new Vector2(1.0f, 1.0f));
        uvPlattform.Add(new Vector2(1.0f, 0.0f));
        //uvPlattform.Add(new Vector2(0.0f, 0.0f));
        //uvPlattform.Add(new Vector2(0.0f, 1.0f));
        //uvPlattform.Add(new Vector2(1.0f, 1.0f));
        //uvPlattform.Add(new Vector2(1.0f, 0.0f));

        mPlattform.vertices = vPlattform.ToArray();
        mPlattform.normals = nPlattform.ToArray();
        mPlattform.triangles = fPlattform.ToArray();
        mPlattform.uv = uvPlattform.ToArray();

        mPlattform.RecalculateNormals();

        Renderer rendPlattform = goPlattform.GetComponent<Renderer>();
        rendPlattform.material = new Material(Shader.Find("Diffuse"));
        rendPlattform.material.mainTexture = pTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
