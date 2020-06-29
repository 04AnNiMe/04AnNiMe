using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bruecke : MonoBehaviour
{
    Mesh mesh;
    //Mesh mesh2;
    GameObject bridge;
    //GameObject seile;
    //GameObject empty;

    public Texture texture;
   // public Texture texture2;

    List<Vector3> vertices; 
    List<int> faces;     
    List<Vector3> normals;   
    List<Vector2> uvs; 

    // List<Vector3> vertices2; 
    // List<int> faces2;     
    // List<Vector3> normals2;   
    // List<Vector2> uvs2;    

    Vector3 a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t;  
    int z = 0;

    Vector3 normale;

    float x = 0.0f;
    float y = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        vertices = new List<Vector3>();    
        faces = new List<int>();
        normals = new List<Vector3>();
        uvs = new List<Vector2>();
        // vertices2 = new List<Vector3>();    
        // faces2 = new List<int>();
        // normals2 = new List<Vector3>();
        // uvs2 = new List<Vector2>();

        bridge = new GameObject("bridge");  
        //gruen = new GameObject("grün");  
 
        bridge.AddComponent<MeshFilter>();     
        bridge.AddComponent<MeshRenderer>();  

        // gruen.AddComponent<MeshFilter>();     
        // gruen.AddComponent<MeshRenderer>();  

        mesh = new Mesh();  
        //mesh2 = new Mesh();                           
                         
        bridge.GetComponent<MeshFilter>().mesh = mesh; 
        //gruen.GetComponent<MeshFilter>().mesh = mesh2;  

        Renderer rend = bridge.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.mainTexture = texture;

        // Renderer rend2 = gruen.GetComponent<Renderer>();   
        // rend2.material = new Material(Shader.Find("Diffuse"));
        // rend2.material.mainTexture = texture2;

        createBridge(13);
        // createGreen();

        // empty = new GameObject();
        // gruen.transform.parent = empty.transform;
        // karotte.transform.parent = empty.transform;

        // empty.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        // empty.transform.Rotate(200, 0, 0);

        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();
        // mesh2.vertices = vertices2.ToArray();         
        // mesh2.normals = normals2.ToArray();
        // mesh2.triangles = faces2.ToArray();
        // mesh2.uv = uvs2.ToArray();
    }

    void createBridge(int anzahlBretter)
    {
        Vector3 position;
        for(int i=0; i<anzahlBretter; i++){
            x=x+1.1f;
            if(i<=anzahlBretter/2){
                y-=0.3f;
            } else {
                y+=0.3f;
            } 
            position = new Vector3(0, y, x);
            createBrett(position);
        }
    }
    void createBrett(Vector3 position)
    {
        a = new Vector3(3.0f, 0.0f, 1.0f)+position;
        b = new Vector3(0.0f, 0.0f, 1.0f)+position;
        c = new Vector3(0.0f, 0.0f, 0.0f)+position;
        d = new Vector3(3.0f, 0.0f, 0.0f)+position;

        e = new Vector3(3.0f, 0.2f, 1.0f)+position;
        f = new Vector3(0.0f, 0.2f, 1.0f)+position;
        g = new Vector3(0.0f, 0.2f, 0.0f)+position;
        h = new Vector3(3.0f, 0.2f, 0.0f)+position;

        createFaces(a, b, c, d);
        createFaces(d, c, b, a);
        createFaces(e, f, g, h);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
        createFaces(d, a, e, h);
        createFaces(b, c, g, f);

       // bridge.transform.position = position;
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

    //    void createFaces2( Vector3 a, Vector3 b, Vector3 c, Vector3 d )
    // {
    //     vertices2.Add(a); vertices2.Add(b); vertices2.Add(c); vertices2.Add(d);       
    //     normale = createNormals(c, b, a);
    //     normals2.Add(normale);normals2.Add(normale);normals2.Add(normale); normals2.Add(normale);
    //     uvs2.Add(new Vector2(0,0)); uvs2.Add(new Vector2(1,0)); uvs2.Add(new Vector2(0,1)); uvs2.Add(new Vector2(1,1)); 
    //     faces2.Add(y);
    //     faces2.Add(y+2);
    //     faces2.Add(y+1);
    //     faces2.Add(y+2);
    //     faces2.Add(y+0);
    //     faces2.Add(y+3);
    //     y+=4;  
    // }

    // Update is called once per frame
    void Update()
    {
        //empty.transform.Rotate(0, 1, 0);
    }
}
