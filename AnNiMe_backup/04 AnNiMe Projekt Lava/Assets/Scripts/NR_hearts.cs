using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code für Herzchen mit Testspielfigur:
public class NR_hearts : MonoBehaviour
{
    //Camera mainCamera;
    // Testspielfigur:
    GameObject testfigur;
    private float time = 0.0f; // Zeit von 0,5 immer wieder auf null setzen

    // fürs Springen:
    bool huepfen = false; 
    bool runter = false;


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
      
    // Lavaplane:
    public GameObject lava;

    // über Gui zugewiesen:
    public Texture lavatextur;



    // Start is called before the first frame update
    void Start()
    {
        // Testspielfigur:
        testfigur = GameObject.CreatePrimitive(PrimitiveType.Cube); testfigur.name = "Spieler";
        testfigur.transform.localScale = new Vector3(1, 1, 1);

        // // Kamera = Kind von Testfigur
        // mainCamera = Camera.main;
        // mainCamera.enabled = true;
        // mainCamera.transform.position = new Vector3(0.0f, 1.0f, -5.0f);
        // mainCamera.transform.parent = testfigur.transform;

        herzlist = new List<GameObject>();

        // Position der Herzen hier zuweisen:
        //createherz(links/rechts, y(höhe), vorne/hinten);
        createherz(0, 4, 0);
        createherz(2, 4, 5);
        createherz(8, 4, 10);
        createherz(15, 4, 20);
        createherz(-30, 4, -10);

        // Rigidbidy funktioniert nicht weil ich kein objekt angelegt hab
        // Herz Rigidbody hinzufügen:
        // heartRigidbody = herz.AddComponent<Rigidbody>();
        // heartRigidbody.isKinematic = true;

        // Lavaplatte:
        lava = new GameObject("Lava");
        lava = GameObject.CreatePrimitive(PrimitiveType.Plane);
        lava.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        lava.transform.localScale += new Vector3(5.0f, 0.0f, 5.0f);

        // Material Lava:
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

        herz.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        herzlist.Add(herz);
        Debug.Log(herzlist.Count);
    }

  
    // Update is called once per frame
    void Update()
    {
        // Bewegung Testspielfigur:

        testfigur.transform.position += testfigur.transform.localRotation * new Vector3(0.01f, 0, 0);        
        //Taste "a": Drehung der Orientierung um -90 Grad, nach links
        if (Input.GetKeyDown(KeyCode.A))
        {
            testfigur.transform.rotation*=Quaternion.AngleAxis(-90.0f,Vector3.up);
            Debug.Log("A key was pressed. Linksdrehung");
        }

        // Taste "d": Drehung der Orientierung um 90 Grad, nach rechts
        if (Input.GetKeyDown(KeyCode.D))
        {
            testfigur.transform.rotation*=Quaternion.AngleAxis(90.0f,Vector3.up);
            Debug.Log("D key was pressed. Rechtsdrehung");
        }

        // Taste "Space": Sprung nach oben
         if (Input.GetKeyDown(KeyCode.Space))
        {
            huepfen = true;  
            Debug.Log("Space was pressed. Sprung");
        }

        if(Time.time >= time)
        {            
            time += 0.5f;

            if (runter == true){
                testfigur.transform.position += new Vector3(0.0f, -1.0f, 0.0f);     
                runter = false;      
            }

            if (huepfen == true){
                testfigur.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
                huepfen = false;
                runter = true;
            }
        }


        // for-Schleife für alle Herzen in der Liste
        for(int i = 0; i < herzlist.Count; i++ ){
        herzlist[i].transform.LookAt(new Vector3(0, 0, -10));
        }

    }
}
