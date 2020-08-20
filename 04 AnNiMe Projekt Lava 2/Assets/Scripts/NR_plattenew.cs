using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_plattenew : MonoBehaviour
{
    public GameObject platte;
    public Texture plattentextur;
    Mesh mesh;

    
    List<Vector3> vertices;  
    List<int> faces;    
    List<Vector3> normals;   
    List<Vector2> uvs; 

    Vector3 a, b, c, d, e, f, g, h;     
    Vector3 n;

    // Start is called before the first frame update
    void Start()
    {
        platte = new GameObject("NR_Platte_neu"); 
        platte.AddComponent<MeshFilter>();
        platte.AddComponent<MeshRenderer>();

        mesh = new Mesh();
        platte.GetComponent<MeshFilter>().mesh = mesh;

        createPlattform();
    }


      void createPlattform()
    {
        Vector3 position;
        position = new Vector3(120, 3, 30);
        createPlatte(position);    
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

        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();

        // Material:
        Renderer rend = platte.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", plattentextur);

        // platte.transform.position = new Vector3(26, 7, 9);
    }

    int j = 0;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
