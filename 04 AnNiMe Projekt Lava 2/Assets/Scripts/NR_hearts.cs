using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code für Herzchen mit Testspielfigur:
public class NR_hearts : MonoBehaviour
{
    public GameObject herz;
    public Mesh herzMesh;
    // falls sie doch noch Random gesetzt werden sollen:
    // private int herzX;
    // private int herzZ;
    public Rigidbody heartRigidbody;
   
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

        // Position der Herzen hier zuweisen:
        //createherz(links/rechts, y(höhe), vorne/hinten);
        createherz(0, 8, 0);
        createherz(2, 8, 5);
        createherz(8, 8, 10);
        createherz(15, 8, 20);
        createherz(-30, 8, -10);

        // Rigidbidy funktioniert nicht weil ich kein objekt angelegt hab
        // Herz Rigidbody hinzufügen:
        // heartRigidbody = herz.AddComponent<Rigidbody>();
        // heartRigidbody.isKinematic = true;

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

        herz.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        //herz.transform.Rotate = new Vector3(0, 0, -90.0f);
        herzlist.Add(herz);
        Debug.Log(herzlist.Count);
    }

  
    // Update is called once per frame
    void Update()
    {

        // for-Schleife für alle Herzen in der Liste
        for(int i = 0; i < herzlist.Count; i++ ){
        herzlist[i].transform.LookAt(new Vector3(0, 0, -10));
        //herzlist[i].transform.LookAt(ThirdPersonObjekt, new Vector3(0, 0, -10));
        }

    }
}
