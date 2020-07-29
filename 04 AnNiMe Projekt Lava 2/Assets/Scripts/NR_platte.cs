using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code für Plattform die hoch und runter geht:
public class NR_platte : MonoBehaviour
{
    public GameObject platte;
    public Texture plattentextur;
    Mesh mesh;
    MeshCollider nPlattform;
    
    List<Vector3> vertices;  
    List<int> faces;    
    List<Vector3> normals;   
    List<Vector2> uvs; 
    
    Vector3 a, b, c, d, e, f, g, h; 
    Vector3 n;


    public GameObject Player;

    int j = 0;
    private float time = 0.0f;
    private float waitTime = 2.0f;
    private bool move = true;
    public float randDelta;

    // (links/rechts, hoehe, vorne/hinten);
    public float randX;
    public float randY;
    public float randZ;


    // Start is called before the first frame update
    void Start()
    {
        platte = new GameObject("NR_Aufzug"); 

        vertices = new List<Vector3>(); 
        faces = new List<int>();   
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        /* platte = GameObject.CreatePrimitive(PrimitiveType.Plane);
        platte = GameObject.CreatePrimitive(PrimitiveType.Cube);
        platte.transform.localScale = new Vector3(1,1,1);
        */

        platte.AddComponent<MeshFilter>();     
        platte.AddComponent<MeshRenderer>();  
        mesh = new Mesh();  
        platte.GetComponent<MeshFilter>().mesh = mesh; 
        // Skalierung Platte:
        platte.transform.localScale = new Vector3(5, 2, 5);

        Renderer rend = platte.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", plattentextur);
       
        // mehrere Platten erzeugen:
        createPlattformEins();
        createPlattformZwei();
        createPlattformDrei();
        
        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();

        nPlattform = platte.AddComponent<MeshCollider>();
        nPlattform.convex = true;
        nPlattform.GetComponent<MeshFilter>().mesh = mesh;


        // Verbinden mit Script:
        platte.AddComponent<AM_charHolder>();

        // Test Plattform    
        randX = 8; 
        randY = 18; 
        randZ = 8;
    }

    // Plattformen:
    void createPlattformEins()
    {
        Vector3 position;
        // (Verschiebung nach links/rechts, hoehe, Verschiebung vorne/hinten);
        position = new Vector3(26.0f, 8.2f, 10.0f);
        createPlatte(position);    
    }

    void createPlattformZwei()
    {
        Vector3 position;
        position = new Vector3(24.0f, 2.0f, 8.0f);
        createPlatte(position);
    }

    void createPlattformDrei()
    {
        Vector3 position;
        position = new Vector3(17.5f, 2.5f, 34.5f);
        createPlatteQuer(position);  
    }


    private Vector3 getNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ba = new Vector3(b.x, b.y, b.z);
            Vector3 ca = new Vector3(b.x, b.y, b.z); 
            ba = b - a;
            ca = c - a;
            return (Vector3.Cross(ba, ca));
        }


    void createPlatte(Vector3 position)
    {
        a = new Vector3(3.0f, 0.0f, 2.0f) + position;
        b = new Vector3(0.0f, 0.0f, 2.0f) + position;
        c = new Vector3(0.0f, 0.0f, 0.0f) + position;
        d = new Vector3(3.0f, 0.0f, 0.0f) + position;

        e = new Vector3(3.0f, 0.2f, 2.0f) + position;
        f = new Vector3(0.0f, 0.2f, 2.0f) + position;
        g = new Vector3(0.0f, 0.2f, 0.0f) + position;
        h = new Vector3(3.0f, 0.2f, 0.0f) + position;

        createFaces(a, b, c, d);
        createFaces(d, c, b, a);
        createFaces(e, f, g, h);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
        createFaces(d, a, e, h);
        createFaces(b, c, g, f);
    }

    void createPlatteQuer(Vector3 position)
    {
        a = new Vector3(2.0f, 0.0f, 3.0f) + position;
        b = new Vector3(0.0f, 0.0f, 3.0f) + position;
        c = new Vector3(0.0f, 0.0f, 0.0f) + position;
        d = new Vector3(2.0f, 0.0f, 0.0f) + position;

        e = new Vector3(2.0f, 0.2f, 3.0f) + position;
        f = new Vector3(0.0f, 0.2f, 3.0f) + position;
        g = new Vector3(0.0f, 0.2f, 0.0f) + position;
        h = new Vector3(2.0f, 0.2f, 0.0f) + position;

        createFaces(a, b, c, d);
        createFaces(d, c, b, a);
        createFaces(e, f, g, h);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
        createFaces(d, a, e, h);
        createFaces(b, c, g, f);
    }

    void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        vertices.Add(a); 
        vertices.Add(b); 
        vertices.Add(c); 
        vertices.Add(d);  

        n = getNormal(c, b, a);
        normals.Add(n);
        normals.Add(n);
        normals.Add(n);
        normals.Add(n);

        uvs.Add(new Vector2(0, 0)); 
        uvs.Add(new Vector2(1, 0)); 
        uvs.Add(new Vector2(0, 1)); 
        uvs.Add(new Vector2(1, 1)); 

        faces.Add(j);
        faces.Add(j + 2);
        faces.Add(j + 1);
        faces.Add(j + 2);
        faces.Add(j + 0);
        faces.Add(j + 3);
        j += 4;   
    }


    void floatingup()
    {
        platte.transform.position = Vector3.Lerp(platte.transform.position, new Vector3(0 + randX, 0 + randY, 0 + randZ), Time.deltaTime * randDelta);
    }

    void floatingdown()
    {
        platte.transform.position = Vector3.Lerp(platte.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 0.5f);
    }

    
    // Update is called once per frame
    void Update()
    {
            // Bewegung hoch und runter:
            time += Time.deltaTime;

                if (time > waitTime && move == false)
                {
                    floatingdown();
                    if (time > 5)
                    {
                        time = 0;
                        move = true;
                    }

                } else {  
                    floatingup();
                    if (time > 2)
                    {
                        randDelta = Random.Range(0.5f, 1.0f);
                        move = false;
                    }
                }
    }
    
}
