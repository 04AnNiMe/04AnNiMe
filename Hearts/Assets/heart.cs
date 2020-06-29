using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    GameObject herz;
    Mesh herzMesh;
   
    static Vector3 a, b, c, d;
    List<Vector3> herzVerticies;
    List<Vector3> herzNormals;
    List<GameObject> herzlist;
    List<int> herzFaces; 

    public List<Vector2> uv; 

    // über GUI zugewiesen:
    public Material rot;
    public Texture herzchen;

   
    // Lavaplane:
    GameObject lava;

    // über Gui zugewiesen:
    public Texture lavatextur;
    

    // Start is called before the first frame update
    void Start()
    {
        herzlist = new List<GameObject>();
        //createherz(x, y(höhe), z);
        createherz(0, 4, 0);
        createherz(2, 4, 5);
        createherz(8, 4, 10);
        createherz(15, 4, 20);
        createherz(-30, 4, -10);

        // Lavaplatte:
        lava = GameObject.CreatePrimitive(PrimitiveType.Plane);
        lava.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        lava.transform.localScale += new Vector3(5.0f, 0.0f, 5.0f);

        // Material:
        Renderer lavamaterial = lava.GetComponent<Renderer>();
        lavamaterial.material = new Material(Shader.Find("Diffuse"));
        lavamaterial.material.SetTexture("_MainTex", lavatextur);
    }
    

    private Vector3 getNormal(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 ba = new Vector3(b.x, b.y, b.z);
        Vector3 ca = new Vector3(b.x, b.y, b.z); 
        ba = b - a;
        ca = c - a;
        return (Vector3.Cross(ba, ca));
    }


    void createFace(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        herzVerticies.Add(a);
        herzVerticies.Add(b);
        herzVerticies.Add(c);
        herzVerticies.Add(d);

        Vector3 n = getNormal(c, b, a);

        herzNormals.Add(n);
        herzNormals.Add(n);
        herzNormals.Add(n);
        herzNormals.Add(n);

        herzFaces.Add(2);
        herzFaces.Add(1);
        herzFaces.Add(0);
        herzFaces.Add(0);
        herzFaces.Add(3);
        herzFaces.Add(2);
       
        uv.Add(new Vector2(1.0f, 1.0f));
        uv.Add(new Vector2(0.0f, 1.0f));
        uv.Add(new Vector2(0.0f, 0.0f));
        uv.Add(new Vector2(1.0f, 0.0f)); 
    }

    // Position von Spieler hier hin und in Update lookat auf Spieler machen

    void createCube(Vector3 position)
    {
        float hoehe = 2;
        Vector3 a = new Vector3(1.0f, 1.0f, 0.0f) + position;
        Vector3 b = new Vector3(-1.0f, 1.0f, 0.0f) + position;
        Vector3 c = new Vector3(-1.0f, -1.0f, 0.0f) + position;
        Vector3 d = new Vector3(1.0f, -1.0f, 0.0f) + position;

        createFace(a, b, c, d);       
    }


    void createherz(float x, float y, float z)
    { 
        Vector3 position = new Vector3(x, y, z);
        Debug.Log(position);
        herz = new GameObject();
        herz.name = "herz";     
        herz.AddComponent<MeshFilter>();
        herz.AddComponent<MeshRenderer>();

        herzMesh = new Mesh();
        herzMesh.Clear();
        herzMesh = herz.GetComponent<MeshFilter>().mesh;

        // Material:
        Renderer herzRenderer = herz.GetComponent<MeshRenderer>();
        herzRenderer.material = rot;

        herzVerticies = new List<Vector3>();
        herzNormals = new List<Vector3>();
        herzFaces = new List<int>();
        uv = new List<Vector2>();

        createCube(position); // Herz erzeugen

        herzMesh.vertices = herzVerticies.ToArray();
        herzMesh.triangles = herzFaces.ToArray(); 
        herzMesh.normals = herzNormals.ToArray();
        herzMesh.uv = uv.ToArray();

        herz.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        herzlist.Add(herz);
        Debug.Log(herzlist.Count);
    }

    // Update is called once per frame
    void Update()
    {
        // for-Schleife für alle Herzen in der liste
        for(int i = 0; i < herzlist.Count; i++ ){
        //herz.transform.rotation *= Quaternion.AngleAxis(-90.0f, Vector3.up);
        herzlist[i].transform.LookAt(new Vector3(0, 0, -10));
        }

        //lookat ausgehend von jedem Herzen auf den Spieler 
        //position von jedem Herzen über Liste übergeben

    }
}
