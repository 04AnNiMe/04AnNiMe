using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schlange : MonoBehaviour
{
    //Gebäude Skript verlinken
    //im Unity GUI dann das GameObject verlinken!
    
    haus score;  //?????

    //Kopf
    public Rigidbody kopfRigid;
    private int spurZahl = 0;

    //Schwanz
    public GameObject tail;             //GameObject
    public Mesh meshT;                  //ein Mesh dem später faceTail, tailV, tailUV angefügt wird
    public List<int> faceTail;          //Schwanzfaces Liste
    public List<Vector3> tailV;         //Schwanzvertices Liste
    public List<Vector2> tailUV;        //Schanz UVliste
    public Rigidbody tailRigid;         //Schwanzrigidbody
    public MeshCollider tailCollider;   //Schwanzcollider

    //Geschwindigkeit
    private float timer = 0.0f;
    private float frequenz = 0.1f;
    private float speed = 1.0f;

    //Jump
    private float jumpVelocity = 5.0f;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2.0f;

    //Rotation
    Quaternion aktRotation;
    Quaternion gesRotation;
    private float rotSpeed = 1.0f;


    void Start()
    {
        //score die Komponenten von Haus verlinken
        score = GameObject.Find("GebäudekomplexEmpty").GetComponent<haus>();

        //dem Kopf ein Rigidbody hinzufügen
        kopfRigid = gameObject.AddComponent<Rigidbody>();

        //Schwanz GameObject erstellen: MeshFilter und MeshRenderer hinzufügen
        tail = new GameObject("Schwanz");
        tail.AddComponent<MeshFilter>();
        tail.AddComponent<MeshRenderer>();

        //dem Schwanz ein Rigidbody hinzufügen und daraus ein Kinematic machen
        tailRigid = tail.AddComponent<Rigidbody>();
        tailRigid.isKinematic = true;

        //Schwanz Collision hinzufügen
        tailCollider = tail.AddComponent<MeshCollider>();

    }

    void spurErstellen()
    {
        transform.Translate(0, -0.5f, -2.0f);
        Vector3 a = transform.position - transform.right * 0.5f;     //0        
        Vector3 b = transform.position + transform.right * 0.5f;     //1
        
        transform.Translate(0, 0, 1.0f);
        Vector3 c = transform.position + transform.right * 0.5f;     //2
        Vector3 d = transform.position - transform.right * 0.5f;     //3

        //mittlere Vectoren
        transform.Translate(0, 0.5f, -1.0f);
        Vector3 e = transform.position;                              //4
        transform.Translate(0, 0, 1.0f);
        Vector3 f = transform.position;                              //5
        transform.Translate(0, 0, 1.0f);
     
        meshT = tail.GetComponent<MeshFilter>().mesh;
        meshT.Clear();

        tailV.Add(a);   tailUV.Add(new Vector2(1.0f, 0.0f));    //0
        tailV.Add(b);   tailUV.Add(new Vector2(0.0f, 0.0f));    //1
        tailV.Add(c);   tailUV.Add(new Vector2(0.0f, 0.0f));    //2
        tailV.Add(d);   tailUV.Add(new Vector2(0.0f, 1.0f));    //3
        tailV.Add(e);   tailUV.Add(new Vector2(1.0f, 1.0f));    //4
        tailV.Add(f);   tailUV.Add(new Vector2(0.0f, 0.0f));    //5

        faceTail.Add(0 + spurZahl);
        faceTail.Add(3 + spurZahl);
        faceTail.Add(5 + spurZahl);
        
        faceTail.Add(0 + spurZahl);
        faceTail.Add(5 + spurZahl);
        faceTail.Add(4 + spurZahl);
        
        faceTail.Add(4 + spurZahl);
        faceTail.Add(5 + spurZahl);
        faceTail.Add(2 + spurZahl);

        faceTail.Add(4 + spurZahl);
        faceTail.Add(2 + spurZahl);
        faceTail.Add(1 + spurZahl);
        
        meshT.vertices = tailV.ToArray();
        meshT.triangles = faceTail.ToArray();
        meshT.uv = tailUV.ToArray();

        meshT.RecalculateNormals();
        meshT.RecalculateBounds();

        Renderer rendT = tail.GetComponent<Renderer>();
        rendT.material = new Material(Shader.Find("Diffuse"));

        //Collider anfügen
        tailCollider.sharedMesh = meshT;

    }
    
    //Bei Berührung Triggern
    private void OnTriggerEnter(Collider other)
    {
        //Bei Berührung einer Kugel soll diese Zerstört werden
        if (other.gameObject.name == "SpherePrefab(Clone)")
        {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            Destroy(other);
            score.collectedItems++;
        }

        //Bei Kollision mit Gebäude oder Schwanz: Leben-- und collectedItems auf 0
        if (other.gameObject.name == "Gebäude" || other.gameObject.name == "Schwanz")
        {
            Debug.Log(this.name + " has a OnTriggerEnter with " + other.gameObject.name);
            score.leben--;
            score.collectedItems = 0;
        }
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        //GetKey für durchgehende Bewegung
        if (Input.GetKey(KeyCode.A))
        {
            //aktuelle Rotation und die gewünschte Rotation speichern
            aktRotation = transform.rotation;
            gesRotation = Quaternion.AngleAxis(0.6f, Vector3.down);

            //Lerp Anwenden
            transform.rotation *= Quaternion.Lerp(aktRotation, gesRotation, (Time.time - frequenz) / rotSpeed * 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            aktRotation = transform.rotation;
            gesRotation = Quaternion.AngleAxis(0.6f, Vector3.up);

            transform.rotation *= Quaternion.Lerp(aktRotation, gesRotation, (Time.time - frequenz) / rotSpeed * 2);
        }
        
        //Sprung Berechnung
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }

        if (kopfRigid.velocity.y < 0)
        {
            kopfRigid.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (kopfRigid.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            kopfRigid.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        //Fortbewegung nach Vorne
        timer += Time.deltaTime;
        if (timer > frequenz)
        {
            timer -= frequenz;
            transform.position += transform.localRotation * new Vector3(0, 0, speed);
            spurErstellen();
            spurZahl += 6;
            Debug.Log("Schritt");
        }
        
        
    }
    
}
