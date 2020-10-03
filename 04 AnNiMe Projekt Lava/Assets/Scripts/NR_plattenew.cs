using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_plattenew : MonoBehaviour
{
    public GameObject platte;
    public GameObject platte2;
    public GameObject platte3;
    public GameObject platte4;
    public BoxCollider cplatte;

    public BoxCollider zweicplatte;
    public Texture steintextur;
    Mesh mesh;

    List<Vector3> vertices;  
    List<int> faces;    
    List<Vector3> normals;   
    List<Vector2> uvs; 

    Vector3 a, b, c, d, e, f, g, h;     
    Vector3 n;

    private float timer = 0.0f;
    private float waitTime = 2.5f;
    private bool moving = true;

    private bool plattenbewegung = false;

    // Start is called before the first frame update
    void Start()
    {
        vertices = new List<Vector3>(); 
        faces = new List<int>();   
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        platte = new GameObject("NR_Platte1_neu"); 
        // platte.transform.position = new Vector3(125, 7, 39);
        platte.transform.position = new Vector3(125, 0, 39);

        platte.AddComponent<MeshFilter>();
        platte.AddComponent<MeshRenderer>();

        mesh = new Mesh();
        platte.GetComponent<MeshFilter>().mesh = mesh;

        cplatte = platte.AddComponent<BoxCollider>();

        zweicplatte = platte.AddComponent<BoxCollider>();
        zweicplatte.isTrigger = true;

        createPlattform();
      
        // weitere Platten erstellen:
        platte2 = Instantiate(platte, new Vector3(105, 0, 32), platte.transform.rotation);
        platte2.name = "NR_Platte2_neu";

        platte3 = Instantiate(platte, new Vector3(105, 0, 62), platte.transform.rotation);
        platte3.name = "NR_Platte3_neu";

        platte4 = Instantiate(platte, new Vector3(130, 0, 57), platte.transform.rotation);
        platte4.name = "NR_Platte4_neu";
        // Option weiter links:
        // platte4 = Instantiate(platte, new Vector3(120, 30, 58), platte.transform.rotation);
        // platte4.name = "NR_Platte4_neu"; 
    }


      void createPlattform()    
    {
        Vector3 position;
        position = new Vector3(0, 0, 0); 
        createPlatte(position);    
    }


    private Vector3 getNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ba = new Vector3(b.x, b.y, b.z);
            Vector3 ca = new Vector3(b.x, b.y, b.z); 
            ba = b - a;
            ca = c - a;
            return (Vector3.Cross(ba, ca));
        }


    void createPlatte(Vector3 position)
    {
        a = new Vector3(4.0f, 0.0f, 2.5f) + position;
        b = new Vector3(0.0f, 0.0f, 2.5f) + position;
        c = new Vector3(0.0f, 0.0f, 0.0f) + position;
        d = new Vector3(4.0f, 0.0f, 0.0f) + position;

        e = new Vector3(4.0f, 0.2f, 2.5f) + position;
        f = new Vector3(0.0f, 0.2f, 2.5f) + position;
        g = new Vector3(0.0f, 0.2f, 0.0f) + position;
        h = new Vector3(4.0f, 0.2f, 0.0f) + position;

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
        Renderer rend = platte.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", steintextur);
   
        // platte.transform.position = new Vector3(125, 7, 39);

        // BoxCollider:
        cplatte.size = new Vector3(4.25f, 0.2f, 2.75f);
        cplatte.center = new Vector3(2, 0.11f, 1.25f);

        zweicplatte.size = new Vector3(4.25f, 0.1f, 2.75f);
        zweicplatte.center = new Vector3(2, 0.4f, 1.25f);
       
        // Verbinden mit Script:
        platte.AddComponent<AM_charHolder>();
    }

    int j = 0;                                                          
    void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        vertices.Add(a); 
        vertices.Add(b); 
        vertices.Add(c); 
        vertices.Add(d);  

        n = getNormal(c, b, a);
        normals.Add(n);
        normals.Add(n);
        normals.Add(n);
        normals.Add(n);

        uvs.Add(new Vector2(0, 0)); 
        uvs.Add(new Vector2(1, 0)); 
        uvs.Add(new Vector2(0, 1)); 
        uvs.Add(new Vector2(1, 1)); 

        faces.Add(j);
        faces.Add(2 + j);
        faces.Add(1 + j);
        faces.Add(2 + j);
        faces.Add(0 + j);
        faces.Add(3 + j);
        j += 4;   
    }


    void floatingup()
    {   
            // Platte unten, vorne:
            platte.transform.position = Vector3.Lerp(platte.transform.position, 
            new Vector3(125, 15, 45), Time.deltaTime * 0.6f);

            // Platte unten, hinten:
            platte2.transform.position = Vector3.Lerp(platte2.transform.position, 
            new Vector3(105, 18, 51), Time.deltaTime * 0.6f);

            // Platte oben, hinten:
            platte3.transform.position = Vector3.Lerp(platte3.transform.position, 
            new Vector3(105, 32, 62), Time.deltaTime * 0.6f);

            // Platte oben, vorne:
            platte4.transform.position = Vector3.Lerp(platte4.transform.position, 
            new Vector3(130, 30, 57), Time.deltaTime * 0.6f);
            // Option weiter links:
            // platte4.transform.position = Vector3.Lerp(platte4.transform.position, 
            // new Vector3(120, 30, 58), Time.deltaTime * 0.6f);
        
    }

    void floatingdown()
    {   
            // Platte unten, vorne:
            platte.transform.position = Vector3.Lerp(platte.transform.position, 
            new Vector3(125, 7, 39), Time.deltaTime * 0.6f);

            // Platte unten, hinten:
            platte2.transform.position = Vector3.Lerp(platte2.transform.position, 
            new Vector3(105, 4, 32), Time.deltaTime * 0.6f);

            // Platte oben, hinten:
            platte3.transform.position = Vector3.Lerp(platte3.transform.position, 
            new Vector3(105, 17, 51), Time.deltaTime * 0.6f);

            // Platte oben, vorne:
            platte4.transform.position = Vector3.Lerp(platte4.transform.position, 
            new Vector3(130, 15, 48), Time.deltaTime * 0.6f);
            // Option weiter links:
            // platte4.transform.position = Vector3.Lerp(platte4.transform.position, 
            // new Vector3(120, 14, 48), Time.deltaTime * 0.6f);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (plattenbewegung == true){

             timer += Time.deltaTime;

            if (timer > waitTime && moving == false) {

                floatingdown();

                if (timer > 10) {
                    timer = 0;
                    moving = true;
                }

            } else {

                floatingup();

                if (timer > 5) {
                    moving = false;
                }
            }

        }
       
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "NR_Cylinder")
        {
            plattenbewegung = true;
            Debug.Log("Platten bewegen sich jetzt!");
        }

    }
}
