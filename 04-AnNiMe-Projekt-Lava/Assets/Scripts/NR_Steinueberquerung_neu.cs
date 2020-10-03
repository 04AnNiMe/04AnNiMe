using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_Steinueberquerung_neu : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cube;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public GameObject Cube5;
    public GameObject Cube6;
    public GameObject Cube7;

    // // zweiter Übergang:
    // public GameObject Cube8;
    // public GameObject Cube9;
    
    public BoxCollider ccube;
    public BoxCollider colcube;
    public Texture steintextur;
    Mesh mesh;
    MeshCollider aCube;
    
    Vector3 a, b, c, d, e, f, g, h; 
    List<Vector3> vertices;  
    List<int> faces;    
    List<Vector3> normals;
    Vector3 normal;   
    List<Vector2> uvs; 

    // Start is called before the first frame update
    void Start()
    {
        vertices = new List<Vector3>(); 
        faces = new List<int>();   
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        Cube = new GameObject("Steine"); 
        mesh = new Mesh();  
        Cube.AddComponent<MeshFilter>();     
        Cube.AddComponent<MeshRenderer>();  
        Cube.GetComponent<MeshFilter>().mesh = mesh; 

        ccube = Cube.AddComponent<BoxCollider>();
        colcube = Cube.AddComponent<BoxCollider>();
        colcube.isTrigger = true;

        aCube = Cube.AddComponent<MeshCollider>();
        aCube.GetComponent<MeshFilter>().mesh = mesh;

        // Steine:
        createCubes();

        // weitere Steine erstellen:
        Cube2 = Instantiate(Cube, new Vector3(75, 2, 141), Cube.transform.rotation);
        Cube2.name = "NR_Stein2";

        Cube3 = Instantiate(Cube, new Vector3(76, 2, 146.5f),Cube.transform.rotation);
        Cube3.name = "NR_Stein3";

        Cube4 = Instantiate(Cube, new Vector3(70, 2, 150), Cube.transform.rotation);
        Cube4.name = "NR_Stein4";

        Cube5 = Instantiate(Cube, new Vector3(65, 2, 155), Cube.transform.rotation);
        Cube5.name = "NR_Stein5";

        Cube6 = Instantiate(Cube, new Vector3(70, 2, 157), Cube.transform.rotation);
        Cube6.name = "NR_Stein6";

        Cube7 = Instantiate(Cube, new Vector3(65.5f, 2, 162), Cube.transform.rotation);
        Cube7.name = "NR_Stein7";


        // // zweiter Übergang:
        // Cube8 = Instantiate(Cube, new Vector3(158.5f, 3, 182.5f), Cube.transform.rotation);
        // Cube8.name = "NR_Stein8";

        // Cube9 = Instantiate(Cube, new Vector3(170.0f, 3, 187.5f), Cube.transform.rotation);
        // Cube9.name = "NR_Stein8";
    }

    void createCubes()
    {
        Vector3 position;
        // Verschiebung nach vorne/hinten, hoehe, Verschiebung links/rechts
        position = new Vector3(0, 0, 0);
        createCube(position);
    }

     private Vector3 getNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ba = new Vector3(b.x, b.y, b.z);
            Vector3 ca = new Vector3(b.x, b.y, b.z); 
            ba = b - a;
            ca = c - a;
            return (Vector3.Cross(ba, ca));
        }


    void createCube(Vector3 position)
    {
        a = new Vector3(4.0f, 0.0f, 4.0f) + position;
        b = new Vector3(0.0f, 0.0f, 4.0f) + position;
        c = new Vector3(0.0f, 0.0f, 0.0f) + position;
        d = new Vector3(4.0f, 0.0f, 0.0f) + position;

        e = new Vector3(4.0f, 2.0f, 4.0f) + position;
        f = new Vector3(0.0f, 2.0f, 4.0f) + position;
        g = new Vector3(0.0f, 2.0f, 0.0f) + position;
        h = new Vector3(4.0f, 2.0f, 0.0f) + position;

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
        Renderer rendCube = Cube.GetComponent<Renderer>();   
        rendCube.material = new Material(Shader.Find("Diffuse"));
        rendCube.material.SetTexture("_MainTex", steintextur);

        Cube.transform.position = new Vector3(70, 2, 140);

        // BoxCollider:
        ccube.size = new Vector3(4.25f, 4.0f, 4.5f);
        ccube.center = new Vector3(2, 0.11f, 1.9f);

        colcube.size = new Vector3(4.25f, 0.1f, 4.5f);
        colcube.center = new Vector3(2, 2.4f, 1.9f);

        // Verbinden mit Script:
        Cube.AddComponent<AM_charHolder>();
    }

    int i = 0;
    void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        vertices.Add(a); 
        vertices.Add(b); 
        vertices.Add(c); 
        vertices.Add(d);  

        normal = getNormal(c, b, a);
        normals.Add(normal);
        normals.Add(normal);
        normals.Add(normal);
        normals.Add(normal);

        uvs.Add(new Vector2(0, 0)); 
        uvs.Add(new Vector2(1, 0)); 
        uvs.Add(new Vector2(0, 1)); 
        uvs.Add(new Vector2(1, 1)); 

        faces.Add(i);
        faces.Add(2 + i);
        faces.Add(1 + i);
        faces.Add(2 + i);
        faces.Add(0 + i);
        faces.Add(3 + i);
        i += 4;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
