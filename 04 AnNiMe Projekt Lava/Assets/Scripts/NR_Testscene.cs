using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NR_Testscene : MonoBehaviour
{
    // für Springen Testspielfigur:
    public GameObject testspielfigur;
   

    public GameObject herz;
    public Mesh herzMesh;
    private int herzX;
    private int herzZ;
    public Rigidbody heartRigidbody;
   
    static Vector3 a, b, c, d;
    List<Vector3> herzVerticies;
    List<Vector3> herzNormals;
    List<GameObject> herzlist;
    List<int> herzFaces; 

    public List<Vector2> uv; 

    // über GUI zugewiesen:
    public Material rot;
    public Texture herzchen;
    
    // Anzeige
    public GUIStyle style;
    //public int collectedHearts = 0;
    //public int leben = 10;
    //public int score = 0;
   
    // Lavaplane:
    public GameObject lava;

    // über Gui zugewiesen:
    public Texture lavatextur;




    // Start is called before the first frame update
    void Start()
    {
        // Testspielfigur:
        testspielfigur = GameObject.CreatePrimitive(PrimitiveType.Cube);


        herzlist = new List<GameObject>();
        //createherz(x, y(höhe), z);
        createherz(0, 10, 0);
        createherz(2, 10, 5);
        createherz(8, 10, 10);
        createherz(15, 10, 20);
        createherz(-30, 10, -10);

        // Lavaplatte:
        lava = new GameObject("Lava");
        lava = GameObject.CreatePrimitive(PrimitiveType.Plane);
        lava.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        lava.transform.localScale += new Vector3(5.0f, 0.0f, 5.0f);

        // Material Lava:
        Renderer lavamaterial = lava.GetComponent<Renderer>();
        lavamaterial.material = new Material(Shader.Find("Diffuse"));
        lavamaterial.material.SetTexture("_MainTex", lavatextur);

        // // Text: Größe und Farbe verändern
        // style = new GUIStyle();
        // style.fontSize = 24;
        // style.normal.textColor = Color.red;

        // // Score:
        // score = GameObject.Find("Herz").GetComponent<GameObject>();

        // Herz Rigidbody hinzufügen:
        heartRigidbody = herz.AddComponent<Rigidbody>();
        //heartRigidbody.isKinematic = true;
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

  /*
    void OnGui(){
        GUI.Label(new Rect(10, 0, 0, 0), "Collected Hearts:" + collectedHearts, style);
        GUI.Label(new Rect(10, 30, 0, 0), "Leben: " + leben, style);
    }
    
    // Bei Berührung Triggern
    private void OnTriggerEnter(Collider other)
    {
        // Bei Berührung eines Herzens soll dieses zerstört werden
        if (other.gameObject.name == "Herz")
        {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            Destroy(other);
            score.leben++;
        }

        // Bei Kollision mit der Lava: Leben--
        if (other.gameObject.name == "Lava")
        {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            score.leben--;
            score.collectedItems = 0;
        }
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        // for-Schleife für alle Herzen in der Liste
        for(int i = 0; i < herzlist.Count; i++ ){
            herzlist[i].transform.LookAt(new Vector3(0, 0, -10));

        // herzX = Random.Range(-20, 20);
        // herzZ = Random.Range(-20, 20);
        }



        //Steuerung Testspielfigur:
        testspielfigur.transform.position += testspielfigur.transform.localRotation * new Vector3(0.01f, 0, 0);
        if(Input.GetKeyDown(KeyCode.A)) {
            testspielfigur.transform.position += testspielfigur.transform.localRotation * new Vector3(0.001f, 0, 0);
            testspielfigur.transform.rotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            testspielfigur.transform.rotation *= Quaternion.AngleAxis(90, Vector3.up);
        }

    }
}
