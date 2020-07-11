using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class haus : MonoBehaviour
{
    //Gebäude
    public GameObject skyscrap;
    public Mesh skyMesh;
    public List<Vector3> skyV;
    public List<int> facesGeb;
    public List<Vector2> uvGeb;

    public Rigidbody skyscrapRig;
    public MeshCollider towerCollider;
    private float hoehe;
    private float breite;
    private float tiefe;
    private int zaehler;

    //Boden
    public GameObject boden;
    public Mesh bodenMesh;
    public List<Vector3> bodenV;
    public List<int> faceBod;
    public List<Vector3> normalBod;
    public List<Vector2> uvBod;

    public Rigidbody bodenRig;
    public MeshCollider bodenCollider;

    //Späre
    public GameObject sphereOriginal;       //hier wird im GUI das Originalobjekt Manuell eingesetzt
    public Rigidbody sphereRigid;
    private int sphereX;
    private int sphereZ;

    //Anzeige
    public GUIStyle style;
    public int collectedItems = 0;
    public int leben = 10;
    

    void Start()
    {
        //Gebäude GameObject erstellen und MeshFilter und MeshRenderer hinzufügen
        skyscrap = new GameObject("Gebäude");
        skyscrap.AddComponent<MeshFilter>();
        skyscrap.AddComponent<MeshRenderer>();

        //Gebäude (skyscrap) ein MeshCollider hinzufügen und dem MeshCollider (towerCollider) zugewiesen
        towerCollider = skyscrap.AddComponent<MeshCollider>();

        //Boden GameObject erstellen und MeshFilter ung MeshRenderer hinzufügen
        boden = new GameObject("Boden");
        boden.AddComponent<MeshFilter>();
        boden.AddComponent<MeshRenderer>();

        //Boden ein MeshCllider hinzufügen
        bodenCollider = boden.AddComponent<MeshCollider>();

        //Boden erstellen
        createBoden();

        //alle Gebäude erstellen
        for (int i = -150; i <= 50; i += 10)
        {
            for (int j = -150; j <= 50; j += 10)
            {
                createSkycraper(i, j);
            }
        }

        //50 Sphären erstellen
        createSphere(50);

        //Font: Größe und Farbe verändern
        style = new GUIStyle();
        style.fontSize = 24;
        style.normal.textColor = Color.red;

    }

    
    void createSphere(int anzahl)
    {
        for (int i = 0; i < anzahl; i++)
        {
            sphereX = Random.Range(-80, 80);
            sphereZ = Random.Range(-80, 80);
            //ein neues GameObject erstellen das eine Instanz (Clone) vom prefab (sphereOriginal) ist
            GameObject cloneObject = Instantiate(sphereOriginal, new Vector3(sphereX, 5.0f, sphereZ), sphereOriginal.transform.rotation);
            //dem geklonten GameObject ein Rigidbody hinzufügen
            sphereRigid = cloneObject.AddComponent<Rigidbody>();
        }
    }

    void createSkycraper(int xAchse, int zAchse)
    {
        int x = xAchse;
        int z = zAchse;
        //Breite, Tiefe und Höhe der Gebäude definieren
        breite = Random.Range(1.0f, 3.0f);
        tiefe = Random.Range(1.0f, 2.0f);
        hoehe = Random.Range(3.0f, 20.0f);
        
        skyMesh = skyscrap.GetComponent<MeshFilter>().mesh;
        skyMesh.Clear();

        Vector3 a = new Vector3(breite + x, hoehe, tiefe + z);       //0
        Vector3 b = new Vector3(-breite + x, hoehe, tiefe + z);      //1
        Vector3 c = new Vector3(-breite + x, -1, tiefe + z);         //2
        Vector3 d = new Vector3(breite + x, -1, tiefe + z);          //3
        Vector3 e = new Vector3(-breite + x, hoehe, -tiefe + z);     //4
        Vector3 f = new Vector3(breite + x, hoehe, -tiefe + z);      //5
        Vector3 g = new Vector3(breite + x, -1, -tiefe + z);         //6
        Vector3 h = new Vector3(-breite + x, -1, -tiefe + z);        //7

        skyV.Add(a);        //0
        skyV.Add(b);        //1
        skyV.Add(c);        //2
        skyV.Add(d);        //3
        skyV.Add(e);        //4
        skyV.Add(f);        //5
        skyV.Add(g);        //6
        skyV.Add(h);        //7
        
        uvGeb.Add(new Vector2(0.0f, 0.0f));
        uvGeb.Add(new Vector2(0.0f, 1.0f));
        uvGeb.Add(new Vector2(1.0f, 1.0f));
        uvGeb.Add(new Vector2(1.0f, 0.0f));
        uvGeb.Add(new Vector2(0.0f, 0.0f));
        uvGeb.Add(new Vector2(0.0f, 1.0f));
        uvGeb.Add(new Vector2(1.0f, 1.0f));
        uvGeb.Add(new Vector2(1.0f, 0.0f));

        //North 6
        facesGeb.Add(0 + zaehler);
        facesGeb.Add(1 + zaehler);
        facesGeb.Add(2 + zaehler);
        facesGeb.Add(0 + zaehler);
        facesGeb.Add(2 + zaehler);
        facesGeb.Add(3 + zaehler);

        //East 12
        facesGeb.Add(0 + zaehler);
        facesGeb.Add(6 + zaehler);
        facesGeb.Add(5 + zaehler);
        facesGeb.Add(0 + zaehler);
        facesGeb.Add(3 + zaehler);
        facesGeb.Add(6 + zaehler);

        //South 18
        facesGeb.Add(4 + zaehler);
        facesGeb.Add(5 + zaehler);
        facesGeb.Add(6 + zaehler);
        facesGeb.Add(4 + zaehler);
        facesGeb.Add(6 + zaehler);
        facesGeb.Add(7 + zaehler);

        //West 24
        facesGeb.Add(1 + zaehler);
        facesGeb.Add(4 + zaehler);
        facesGeb.Add(7 + zaehler);
        facesGeb.Add(1 + zaehler);
        facesGeb.Add(7 + zaehler);
        facesGeb.Add(2 + zaehler);

        //Up 30
        facesGeb.Add(1 + zaehler);
        facesGeb.Add(0 + zaehler);
        facesGeb.Add(5 + zaehler);
        facesGeb.Add(1 + zaehler);
        facesGeb.Add(5 + zaehler);
        facesGeb.Add(4 + zaehler);

        //einzelne Gebäude positionieren
        skyscrap.transform.position = new Vector3(x, 0, z);

        //dem Mesh vertices, triangles und uvs hinzufügen
        skyMesh.vertices = skyV.ToArray();
        skyMesh.triangles = facesGeb.ToArray();
        skyMesh.uv = uvGeb.ToArray();

        skyMesh.RecalculateNormals();
        Renderer skyRend = skyscrap.GetComponent<Renderer>();
        skyRend.material = new Material(Shader.Find("Specular"));
        Texture texture = Resources.Load("1") as Texture;
        skyRend.material.mainTexture = texture;

        //dem Mesh (skyMesh) einen Collider (towerCollider) hinzufügen
        towerCollider.sharedMesh = skyMesh;
        
        zaehler += 8;
    }
    
    
    void createBoden()
    {
        bodenMesh = boden.GetComponent<MeshFilter>().mesh;
        bodenMesh.Clear();

        bodenV.Add(new Vector3(-100, 0, -100));
        bodenV.Add(new Vector3(-100, 0, 100));
        bodenV.Add(new Vector3(100, 0, -100));
        bodenV.Add(new Vector3(100, 0, 100));

        faceBod.Add(0);
        faceBod.Add(1);
        faceBod.Add(2);
        faceBod.Add(1);
        faceBod.Add(3);
        faceBod.Add(2);

        bodenMesh.vertices = bodenV.ToArray();
        bodenMesh.triangles = faceBod.ToArray();

        bodenMesh.RecalculateNormals();

        Renderer bodenRend = boden.GetComponent<Renderer>();
        bodenRend.material = new Material(Shader.Find("Diffuse"));

        //Collision hinzufügen  
        bodenCollider.sharedMesh = bodenMesh;

    }
    

    
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 0, 0, 0), "Collected Items: " + collectedItems, style);
        GUI.Label(new Rect(10, 30, 0, 0), "Leben: " + leben, style);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (leben == 0)
        {
            Debug.Log("Tot");
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
        
    }
    
}
