using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_bruecke : MonoBehaviour
{
    Mesh mesh;
    GameObject bridge;
    GameObject allBridge;

    public Texture texture;

    List<Vector3> vertices; 
    List<int> faces;     
    List<Vector3> normals;   
    List<Vector2> uvs; 

    Vector3 a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t;  
    int z = 0;

    Vector3 normale;

    float x = 0.0f;
    float y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

//////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Anzahl der Bretter eingeben: (Mind. 5)
        int anzahl = 7;

        //Länge der Brücke eingeben:
        float laenge = 17.5f;

        //Startpunkt eingeben:
        float punktX = 268.26f;
        float punktY = 7.96f;
        float punktZ = 309.25f;

        //Rotation eingeben:
        float rot = -82.68f;
//////////////////////////////////////////////////////////////////////////////////////////////////////////

        vertices = new List<Vector3>();     
        faces = new List<int>();
        normals = new List<Vector3>();
        uvs = new List<Vector2>();
        
        allBridge = new GameObject("GesamteBridge");  

        Vector3 position;
        for(int i=0; i<anzahl; i++){
            x=x+1.5f; //festgelegter abstand zw Brettern
            if(i<=anzahl/2){
                y-=0.3f;
            } else {
                y+=0.3f;
            } 
            position = new Vector3(0, y, x);
            createBrett(position);
        }

        float breite = laenge/anzahl; //dynamische Breite der Platten

        allBridge.transform.Translate(punktX, punktY, punktZ);
        allBridge.transform.Rotate(0, rot, 0);
        allBridge.transform.localScale = new Vector3(1.0f, 2.2f, breite);

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

        bridge = new GameObject("bridge");  
 
        bridge.AddComponent<MeshFilter>();     
        bridge.AddComponent<MeshRenderer>();  

        mesh = new Mesh();  
                         
        bridge.GetComponent<MeshFilter>().mesh = mesh; 

        Renderer rend = bridge.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.mainTexture = texture;

        MeshCollider mc = bridge.AddComponent<MeshCollider>();

        bridge.transform.parent = allBridge.transform;

        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();
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

    }
    
}
