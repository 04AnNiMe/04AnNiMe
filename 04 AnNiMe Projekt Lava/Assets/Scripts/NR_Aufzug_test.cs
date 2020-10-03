using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_Aufzug_test : MonoBehaviour
{
    GameObject platte;
    public Texture plattentextur;
    Mesh mesh;
    
    List<Vector3> vertices;  
    List<int> faces;    
    List<Vector3> normals;   
    List<Vector2> uvs; 
    
    Vector3 a, b, c, d, e, f, g, h; 
    Vector3 n;

    int j = 0;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        platte = new GameObject("Plattform"); 

        vertices = new List<Vector3>(); 
        faces = new List<int>();   
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        platte.AddComponent<MeshFilter>();     
        platte.AddComponent<MeshRenderer>();  
        mesh = new Mesh();  
        platte.GetComponent<MeshFilter>().mesh = mesh; 

       
        createPlattform(1);
        platte.AddComponent<AM_charHolder>();
        
    }

    void createPlattform(int plattform)
    {
        Vector3 position;
        position = new Vector3(130, 2, 30);
        createPlatte(position);
    }


    Vector3 getNormal(Vector3 a, Vector3 b, Vector3 c)
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

        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();

        // Material:
        Renderer rend = platte.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", plattentextur);
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

    public int count = 0;
    // Update is called once per frame
    void Update()
    {
      if(Time.time >= time)
        {           
            if (count <= 6){
                time += 0.5f;
                platte.transform.position += platte.transform.localRotation * new Vector3(0.0f, 1.0f, 0.0f);
                count ++;
            } else {
                time += 0.5f;
                platte.transform.position += platte.transform.localRotation * new Vector3(0.0f, -7.0f, 0.0f);
                count = 0;
            }
          
        }   
    }
    
}
