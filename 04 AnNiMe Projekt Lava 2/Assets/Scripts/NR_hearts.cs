using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code für Herzchen mit Testspielfigur:
public class NR_hearts : MonoBehaviour
{
    public GameObject character;
    public GameObject herz;
    public Mesh herzMesh;
    MeshCollider collHerz;

    static Vector3 a, b, c, d;
    public List<Vector3> herzVerticies;
    public List<Vector3> herzNormals;
    public List<GameObject> herzlist;
    public List<int> herzFaces; 
    public List<Vector2> uv; 

    // über GUI zugewiesen:
    public Material rot;
    public Texture herzchen;

    // Start is called before the first frame update
    void Start()
    {
        herzlist = new List<GameObject>();
        character = GameObject.Find("RabbitWarrior01");

        // Position der Herzen hier zuweisen:
        // links/rechts, höhe, vorne/hinten von Spielstart

        // beim Start zum testen:
        // createherz(0, 5, -21);

        // bei der Insel in der Ecke:
        createherz(192, 7, 0);

        // bei den AM_Plattformen:
        createherz(0, 5, 0);

        // bei dem Boot:
        createherz(5, 3, 65); 

        // bei der kleinen Insel:
        createherz(2, 6, 100); 

        // neben dem kleinen Hügel:
        createherz(-8, 6, 146); 

        // beim kleinen Hügel:
        createherz(6, 6, 150); 

        // auf großem Hügel:
        createherz(40, 23, 132); 
        createherz(37, 22, 118); 
        
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


    void createCube(Vector3 position)
    {
        Vector3 a = new Vector3(1.0f, 1.0f, 0.0f) + position;
        Vector3 b = new Vector3(-1.0f, 1.0f, 0.0f) + position;
        Vector3 c = new Vector3(-1.0f, -1.0f, 0.0f) + position;
        Vector3 d = new Vector3(1.0f, -1.0f, 0.0f) + position;

        createFace(a, b, c, d);       
    }


    void createherz(float x, float y, float z)
    { 
        Vector3 position = new Vector3(x, y, z);
        herz = new GameObject();
        herz.name = "Herz";     
        herz.AddComponent<MeshFilter>();
        herz.AddComponent<MeshRenderer>();

        herzMesh = new Mesh();
        herzMesh.Clear();
        herzMesh = herz.GetComponent<MeshFilter>().mesh;

        // Material:
        Renderer herzRenderer = herz.GetComponent<MeshRenderer>();
        herzRenderer.material = rot;

        // Herz-Listen:
        herzVerticies = new List<Vector3>();
        herzNormals = new List<Vector3>();
        herzFaces = new List<int>();
        uv = new List<Vector2>();

        // Herz erzeugen:
        createCube(position); 

        herzMesh.vertices = herzVerticies.ToArray();
        herzMesh.triangles = herzFaces.ToArray(); 
        herzMesh.normals = herzNormals.ToArray();
        herzMesh.uv = uv.ToArray();

        herz.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        herz.transform.position = new Vector3(300, 0, 20);
        herz.transform.Rotate(0, -90, 0);
        
        // Collider:
        collHerz = herz.AddComponent<MeshCollider>();
        collHerz.sharedMesh = herz.GetComponent<MeshFilter>().mesh;
        //Destroy(herz.GetComponent<MeshCollider>());
        collHerz.convex = true;
        collHerz.isTrigger = true;
        
        herzlist.Add(herz);
    }
  

    // Update is called once per frame
    void Update()
    {
        // for-Schleife für alle Herzen in der Liste
        // for(int i = 0; i < herzlist.Count; i++ ){
        //     herzlist[i].transform.LookAt(new Vector3(0, 0, -10));
        // }

        transform.LookAt(character.transform.position);
    }
}
