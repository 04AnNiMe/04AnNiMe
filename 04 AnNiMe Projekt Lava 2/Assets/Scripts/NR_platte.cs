using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code für Plattform die hoch und runter geht:
public class NR_platte : MonoBehaviour
{
    public GameObject platte;
    public GameObject platte2;
    public GameObject platte3;
    public GameObject platte4;
    public Texture plattentextur;
    Mesh mesh;
    Mesh mesh2;
    Mesh mesh3;
    Mesh mesh4;

    // MeshCollider nPlattform;
    BoxCollider cplatte;
    
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

    // links/rechts, hoehe, vorne/hinten
    public float randX;
    public float randY;
    public float randZ;


    // Start is called before the first frame update
    void Start()
    {
        platte = new GameObject("NR_Aufzug"); 
        platte2 = new GameObject("NR_Aufzug2"); 
        platte3 = new GameObject("NR_Aufzug3"); 
        platte4 = new GameObject("NR_Aufzug4"); 

        vertices = new List<Vector3>(); 
        faces = new List<int>();   
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        platte.AddComponent<MeshFilter>();     
        platte.AddComponent<MeshRenderer>(); 

         platte2.AddComponent<MeshFilter>();     
        platte2.AddComponent<MeshRenderer>(); 

         platte3.AddComponent<MeshFilter>();     
        platte3.AddComponent<MeshRenderer>(); 

         platte4.AddComponent<MeshFilter>();     
        platte4.AddComponent<MeshRenderer>();  

        mesh = new Mesh();
        mesh2 = new Mesh();
        mesh3 = new Mesh();
        mesh4 = new Mesh();  

        platte.GetComponent<MeshFilter>().mesh = mesh; 
        platte2.GetComponent<MeshFilter>().mesh = mesh2; 
        platte3.GetComponent<MeshFilter>().mesh = mesh3; 
        platte4.GetComponent<MeshFilter>().mesh = mesh4; 

        // Skalierung Platte:
        platte.transform.localScale = new Vector3(5, 2, 5);
        platte2.transform.localScale = new Vector3(5, 2, 5);
        platte3.transform.localScale = new Vector3(5, 2, 5);
        platte4.transform.localScale = new Vector3(5, 2, 5);

        // Material:
        Renderer rend = platte.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", plattentextur);

        rend = platte2.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", plattentextur);

        rend = platte3.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", plattentextur);

        rend = platte4.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", plattentextur);
       
        // mehrere Platten erzeugen:
        createPlattformEins();
        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();

        createPlattformZwei();
        mesh2.vertices = vertices.ToArray();         
        mesh2.normals = normals.ToArray();
        mesh2.triangles = faces.ToArray();
        mesh2.uv = uvs.ToArray();

        createPlattformDrei();
        mesh3.vertices = vertices.ToArray();         
        mesh3.normals = normals.ToArray();
        mesh3.triangles = faces.ToArray();
        mesh3.uv = uvs.ToArray();

        createPlattformVier();
        mesh4.vertices = vertices.ToArray();         
        mesh4.normals = normals.ToArray();
        mesh4.triangles = faces.ToArray();
        mesh4.uv = uvs.ToArray();

        // createPlattformFuenf();

    

        // // MeshCollider:
        // nPlattform = platte.AddComponent<MeshCollider>();
        // nPlattform.GetComponent<MeshFilter>().mesh = mesh;
        // nPlattform.isTrigger = true;

        //  nPlattform = platte2.AddComponent<MeshCollider>();
        // nPlattform.GetComponent<MeshFilter>().mesh = mesh2;
        // nPlattform.isTrigger = true;

        //  nPlattform = platte3.AddComponent<MeshCollider>();
        // nPlattform.GetComponent<MeshFilter>().mesh = mesh3;
        // nPlattform.isTrigger = true;

        //  nPlattform = platte4.AddComponent<MeshCollider>();
        // nPlattform.GetComponent<MeshFilter>().mesh = mesh4;
        // nPlattform.isTrigger = true;

        // BoxCollider:
        cplatte = platte.AddComponent<BoxCollider>();
        cplatte.isTrigger = true;
        cplatte.size = new Vector3(8, 4, 4);
        cplatte.center = new Vector3(0, 0.5f, 0);

        cplatte = platte2.AddComponent<BoxCollider>();
        cplatte.isTrigger = true;
        cplatte.size = new Vector3(8, 4, 4);
        cplatte.center = new Vector3(0, 0.5f, 0);

        cplatte = platte3.AddComponent<BoxCollider>();
        cplatte.isTrigger = true;
        cplatte.size = new Vector3(8, 4, 4);
        cplatte.center = new Vector3(0, 0.5f, 0);

        cplatte = platte4.AddComponent<BoxCollider>();
        cplatte.isTrigger = true;
        cplatte.size = new Vector3(8, 4, 4);
        cplatte.center = new Vector3(0, 0.5f, 0);

        randX = 8; 
        randY = 18; 
        randZ = 8;

        // Verbinden mit Script:
        platte.AddComponent<AM_charHolder>();
        platte2.AddComponent<AM_charHolder>();
        platte3.AddComponent<AM_charHolder>();
        platte4.AddComponent<AM_charHolder>();
    }


    // Plattformen:

    // erste obere:
    void createPlattformEins()
    {
        Vector3 position;
        // (Verschiebung nach vorne/hinten, hoehe, Verschiebung links/rechts);
        position = new Vector3(26.0f, 7.5f, 9.5f);
        createPlatte(position);    
    }

    // erste untere:
    void createPlattformZwei()
    {
        Vector3 position;
        position = new Vector3(24.5f, 1.0f, 7.5f);
        createPlatte(position);
    }

    // zweite obere:
    void createPlattformDrei()
    {
        Vector3 position;
        position = new Vector3(17.0f, 7.5f, 9.5f);
        createPlatte(position);    
    }

    // zweite untere:
    void createPlattformVier()
    {
        Vector3 position;
        position = new Vector3(18.0f, 1.0f, 7.0f);
        createPlatte(position);
    }

    // void createPlattformFuenf()
    // {
    //     Vector3 position;
    //     position = new Vector3(45.5f, 0.3f, 23.5f);
    //     createPlatteQuer(position);  
    // }



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
        a = new Vector3(2.0f, 0.0f, 1.5f) + position;
        b = new Vector3(0.0f, 0.0f, 1.5f) + position;
        c = new Vector3(0.0f, 0.0f, 0.0f) + position;
        d = new Vector3(2.0f, 0.0f, 0.0f) + position;

        e = new Vector3(2.0f, 0.2f, 1.5f) + position;
        f = new Vector3(0.0f, 0.2f, 1.5f) + position;
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
        faces.Add(2 + j);
        faces.Add(1 + j);
        faces.Add(2 + j);
        faces.Add(0 + j);
        faces.Add(3 + j);
        j += 4;   
    }


    void floatingup()
    {
        platte.transform.position = Vector3.Lerp(platte.transform.position, new Vector3(0 + randX, 0 + randY, 0 + randZ), Time.deltaTime * randDelta);
        platte2.transform.position = Vector3.Lerp(platte2.transform.position, new Vector3(0 + randX, 0 + randY, 0 + randZ), Time.deltaTime * randDelta);
        platte3.transform.position = Vector3.Lerp(platte3.transform.position, new Vector3(0 + randX, 0 + randY, 0 + randZ), Time.deltaTime * randDelta);
        platte4.transform.position = Vector3.Lerp(platte4.transform.position, new Vector3(0 + randX, 0 + randY, 0 + randZ), Time.deltaTime * randDelta);
    
    }

    void floatingdown()
    {
        platte.transform.position = Vector3.Lerp(platte.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 0.5f);
        platte2.transform.position = Vector3.Lerp(platte2.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 0.5f);
        platte3.transform.position = Vector3.Lerp(platte3.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 0.5f);
        platte4.transform.position = Vector3.Lerp(platte4.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 0.5f);
    }

    
    // Update is called once per frame
    void Update()
    {
            // Bewegung hoch und runter:
            time += Time.deltaTime;

                if (time > waitTime && move == false)
                {
                    floatingdown();
                    if (time > 7)
                    {
                        time = 0;
                        move = true;
                    }

                } else {  
                    floatingup();
                    if (time > 2)
                    {
                        randDelta = Random.Range(1.5f, 2.0f);
                        move = false;
                    }
                }
    }
    
}
