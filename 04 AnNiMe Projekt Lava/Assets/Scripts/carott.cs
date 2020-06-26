using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carott : MonoBehaviour
{
    Mesh mesh;
    GameObject karotte;
    public Texture texture;
    List<Vector3> vertices; 
    List<int> faces;     
    List<Vector3> normals;   
    List<Vector2> uvs;      
    Vector3 a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t;  
    int z = 0;
    Vector3 normale;


    // Start is called before the first frame update
    void Start()
    {
        vertices = new List<Vector3>();    
        faces = new List<int>();
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        karotte = new GameObject("carott");      
        karotte.AddComponent<MeshFilter>();     
        karotte.AddComponent<MeshRenderer>();   

        mesh = new Mesh();                           
        karotte.GetComponent<MeshFilter>().mesh = mesh;  

        Renderer rend = karotte.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.mainTexture = texture;

        createCarott();
        karotte.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        karotte.transform.Rotate(200, 0, 0);

        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();

    }

    void createCarott()
    {
        a = new Vector3(1.0f, 0.0f, 1.0f);
        b = new Vector3(-1.0f, 0.0f, 1.0f);
        c = new Vector3(-1.0f, 0.0f, -1.0f);
        d = new Vector3(1.0f, 0.0f, -1.0f);

        e = new Vector3(1.0f, 2.0f, 1.0f);
        f = new Vector3(-1.0f, 2.0f, 1.0f);
        g = new Vector3(-1.0f, 2.0f, -1.0f);
        h = new Vector3(1.0f, 2.0f, -1.0f);

        i = new Vector3(0.5f, 8.0f, 0.5f);
        j = new Vector3(-0.5f, 8.0f, 0.5f);
        k = new Vector3(-0.5f, 8.0f, -0.5f);
        l = new Vector3(0.5f, 8.0f, -0.5f);

        m = new Vector3(0.5f, 0.0f, 0.5f);
        n = new Vector3(-0.5f, 0.0f, 0.5f);
        o = new Vector3(-0.5f, 0.0f, -0.5f);
        p = new Vector3(0.5f, 0.0f, -0.5f);

        q = new Vector3(1.0f, -3.0f, 1.0f);
        r = new Vector3(-1.0f, -3.0f, 1.0f);
        s = new Vector3(-1.0f, -3.0f, -1.0f);
        t = new Vector3(1.0f, -3.0f, -1.0f);

        //stamm
        createFaces(a, b, c, d);
        createFaces(d, c, b, a);
        createFaces(e, f, g, h);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
        createFaces(d, a, e, h);
        createFaces(b, c, g, f);

        //spitze
        createFaces(i, j, k, l);
        createFaces(i, l, h, e);
        createFaces(l, k, g, h);
        createFaces(j, i, e, f);
        createFaces(k, j, f, g);

        //Stängel
        createFaces(t, s, r, q);
        createFaces(p, o, s, t);
        createFaces(m, p, t, q);
        createFaces(n, m, q, r);
        createFaces(o, n, r, s);

       // karotte.transform.Rotate(0, 0, rotation);
        // karotte.transform.position = new Vector3();
        // karotte.transform.localScale = new Vector3();
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

    // Update is called once per frame
    void Update()
    {
        karotte.transform.Rotate(0, 1, 0);
    }
}
