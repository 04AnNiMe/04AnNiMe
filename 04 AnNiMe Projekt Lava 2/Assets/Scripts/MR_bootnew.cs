using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_bootnew : MonoBehaviour
{
    Mesh mesh;
    Mesh mesh2;
    GameObject boat;
    GameObject fahne;
    public GameObject empty;

    public Texture texture;
    public Texture texture2;

    List<Vector3> vertices; 
    List<int> faces;     
    List<Vector3> normals;   
    List<Vector2> uvs; 
    List<Vector3> vertices2; 
    List<int> faces2;     
    List<Vector3> normals2;   
    List<Vector2> uvs2;      
    Vector3 a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x;  

    int z = 0;
    int y = 0;

    Vector3 normale;

    Rigidbody rb;
    CapsuleCollider cc;
    BoxCollider bc;
 

    // Start is called before the first frame update
    void Start()
    {
        //listen initialisieren
        vertices = new List<Vector3>();    
        faces = new List<int>();
        normals = new List<Vector3>();
        uvs = new List<Vector2>();
        vertices2 = new List<Vector3>();    
        faces2 = new List<int>();
        normals2 = new List<Vector3>();
        uvs2 = new List<Vector2>();

        //GameObject Boot
        boat = new GameObject("boat");  
        boat.AddComponent<MeshFilter>();     
        boat.AddComponent<MeshRenderer>(); 
        mesh = new Mesh();  
        boat.GetComponent<MeshFilter>().mesh = mesh; 
        
        //Renderer Boot
        Renderer rend = boat.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.mainTexture = texture;

        //GameObject Fahne
        fahne = new GameObject("fahne");  
        fahne.AddComponent<MeshFilter>();     
        fahne.AddComponent<MeshRenderer>();  
        mesh2 = new Mesh();                                      
        fahne.GetComponent<MeshFilter>().mesh = mesh2;  

        //Renderer Fahne
        Renderer rend2 = fahne.GetComponent<Renderer>();   
        rend2.material = new Material(Shader.Find("Diffuse"));
        rend2.material.mainTexture = texture2;

        createBoat();
        createFahne();

        //Beide unter ein empty legen
        empty = new GameObject("EmptyBoot");
        boat.transform.parent = empty.transform;
        fahne.transform.parent = empty.transform;
        empty.AddComponent<MeshFilter>();
        empty.tag = "boot";
       // empty.AddComponent<MR_boatPath>();

         // empty.AddComponent<MeshRenderer>();  

        //To-Array
        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();
        mesh2.vertices = vertices2.ToArray();         
        mesh2.normals = normals2.ToArray();
        mesh2.triangles = faces2.ToArray();
        mesh2.uv = uvs2.ToArray();

        //Collider
        //cc = empty.AddComponent<CapsuleCollider>();
        bc = empty.AddComponent<BoxCollider>();

        //cc.isTrigger = true;

        bc.size = new Vector3(4.11f, 1.0f, 1.38f);
        bc.center = new Vector3(0, 0.45f, 0);

        // cc.radius = 1.5f;
        // cc.height = 4.83f;
        // cc.direction = 0; //x-achse

        empty.transform.position = new Vector3(251, 3, 25);
        empty.transform.localScale = new Vector3(3,3,3);
    }

    void createBoat()
    {
        a = new Vector3(1.0f, 1.0f, 0.7f);
        b = new Vector3(-1.0f, 1.0f, 0.7f);
        c = new Vector3(-1.0f, 1.0f, -0.7f);
        d = new Vector3(1.0f, 1.0f, -0.7f);

        e = new Vector3(1.0f, 0.0f, 0.33f);
        f = new Vector3(-1.0f, 0.0f, 0.33f);
        g = new Vector3(-1.0f, 0.0f, -0.33f);
        h = new Vector3(1.0f, 0.0f, -0.33f);

        i = new Vector3(2.0f, 1.0f, -0.33f);
        j = new Vector3(2.0f, 1.0f, 0.33f);
        k = new Vector3(2.0f, 0.5f, -0.33f);
        l = new Vector3(2.0f, 0.5f, 0.33f);

        m = new Vector3(-2.0f, 1.0f, 0.33f);
        n = new Vector3(-2.0f, 1.0f, -0.33f);
        o = new Vector3(-2.0f, 0.5f, 0.33f);
        p = new Vector3(-2.0f, 0.5f, -0.33f);

        //grundaufbau
        createFaces(a, b, c, d);
        createFaces(h, g, f, e);
        createFaces(g, h, d, c);
        createFaces(e, f, b, a);
        createFaces(h, e, a, d);
        createFaces(f, g, c, b);

        //vorne
        createFaces(j, a, d, i);
        createFaces(k, h, e, l);
        createFaces(k, l, j, i);
        createFaces(i, d, h, k);
        createFaces(a, j, l, e);

        //hinten
        createFaces(b, m, n, c);
        createFaces(g, p, o, f);
        createFaces(o, p, n, m);
        createFaces(f, o, m, b);
        createFaces(p, g, c, n);
    }

    void createFahne()
    {
        q = new Vector3(0.1f, 1.0f, 0.1f);
        r = new Vector3(0.1f, 1.0f, -0.1f);
        s = new Vector3(-0.1f, 1.0f, -0.1f);
        t = new Vector3(-0.1f, 1.0f, 0.1f);

        u = new Vector3(0.1f, 5.0f, 0.1f);
        v = new Vector3(0.1f, 5.0f, -0.1f);
        w = new Vector3(-0.1f, 5.0f, -0.1f);
        x = new Vector3(-0.1f, 5.0f, 0.1f);

        createFaces2(t, s, r, q);
        createFaces2(u, v, w, x);
        createFaces2(u, v, r, q);
        createFaces2(v, w, s, r);
        createFaces2(w, x, t, s);
        createFaces2(x, u, q, t);
    }

    Vector3 createNormals(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 ab = b-a;
        Vector3 ac = c-a;
        return Vector3.Cross(ab, ac).normalized;
    }

    void createFaces( Vector3 a, Vector3 b, Vector3 c, Vector3 d )
    {
        vertices.Add(a); vertices.Add(b); vertices.Add(c); vertices.Add(d);       
        normale = createNormals(c, b, a);
        normals.Add(normale);normals.Add(normale);normals.Add(normale); normals.Add(normale);
        uvs.Add(new Vector2(0,0)); uvs.Add(new Vector2(1,0)); uvs.Add(new Vector2(0,1)); uvs.Add(new Vector2(1,1)); 
        faces.Add(z);
        faces.Add(z+2);
        faces.Add(z+1);
        faces.Add(z+2);
        faces.Add(z+0);
        faces.Add(z+3);
        z+=4;  
    }

       void createFaces2( Vector3 a, Vector3 b, Vector3 c, Vector3 d )
    {
        vertices2.Add(a); vertices2.Add(b); vertices2.Add(c); vertices2.Add(d);       
        normale = createNormals(c, b, a);
        normals2.Add(normale);normals2.Add(normale);normals2.Add(normale); normals2.Add(normale);
        uvs2.Add(new Vector2(0,0)); uvs2.Add(new Vector2(1,0)); uvs2.Add(new Vector2(0,1)); uvs2.Add(new Vector2(1,1)); 
        faces2.Add(y);
        faces2.Add(y+2);
        faces2.Add(y+1);
        faces2.Add(y+2);
        faces2.Add(y+0);
        faces2.Add(y+3);
        y+=4;  
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}


// submesh 
// windbewegung wind force 
// weather System 
