using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_uebergang : MonoBehaviour
{
    public GameObject uebergang;
    public GameObject uebergang1;
    public GameObject uebergang2;
    public GameObject uebergang3;
    public GameObject uebergang4;
    public GameObject uebergang5;
    public GameObject uebergang6;
    public GameObject uebergang7;
    public GameObject uebergang8;
    public GameObject uebergang9;
   
    public BoxCollider buebergang;
    public BoxCollider uc;
    public Texture steintextur;
    Mesh mesh;

    List<Vector3> vertices;  
    List<int> faces;    
    List<Vector3> normals;   
    List<Vector2> uvs; 

    Vector3 a, b, c, d, e, f, g, h;     
    Vector3 n;

    int j = 0; 
    private float timer = 0.0f;
    private float waitTime = 0.2f;
    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        vertices = new List<Vector3>(); 
        faces = new List<int>();   
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        uebergang = new GameObject("NR_Übergang"); 
        uebergang.AddComponent<MeshFilter>();
        uebergang.AddComponent<MeshRenderer>();

        mesh = new Mesh();
        uebergang.GetComponent<MeshFilter>().mesh = mesh;

        buebergang = uebergang.AddComponent<BoxCollider>();
        uc = uebergang.AddComponent<BoxCollider>();
        uc.isTrigger = true;

        createPlattform();

        uebergang1 = Instantiate(uebergang, new Vector3(248.5f, 5, 225.25f), uebergang.transform.rotation);
        uebergang1.name = "NR_Übergang1";

        uebergang2 = Instantiate(uebergang, new Vector3(248.5f, 4.5f, 228), uebergang.transform.rotation);
        uebergang2.name = "NR_Übergang2";

        uebergang3 = Instantiate(uebergang, new Vector3(248.5f, 3.5f, 230.75f), uebergang.transform.rotation);
        uebergang3.name = "NR_Übergang3";

        uebergang4 = Instantiate(uebergang, new Vector3(248.5f, 3.5f, 233.5f), uebergang.transform.rotation);
        uebergang4.name = "NR_Übergang4";

        uebergang5 = Instantiate(uebergang, new Vector3(248.5f, 3.5f, 236.25f), uebergang.transform.rotation);
        uebergang5.name = "NR_Übergang5";

        uebergang6 = Instantiate(uebergang, new Vector3(248.5f, 3.5f, 239), uebergang.transform.rotation);
        uebergang6.name = "NR_Übergang6";

        uebergang7 = Instantiate(uebergang, new Vector3(248.5f, 3.5f, 241.75f), uebergang.transform.rotation);
        uebergang7.name = "NR_Übergang7";

        uebergang8 = Instantiate(uebergang, new Vector3(248.5f, 3.5f, 244.5f), uebergang.transform.rotation);
        uebergang8.name = "NR_Übergang8";

        uebergang9 = Instantiate(uebergang, new Vector3(248.5f, 3.5f, 247.25f), uebergang.transform.rotation);
        uebergang9.name = "NR_Übergang9";
    }


      void createPlattform()    
    {
        Vector3 position;
        position = new Vector3(0, 0, 0); 
        createuebergang(position);    
    }


    private Vector3 getNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ba = new Vector3(b.x, b.y, b.z);
            Vector3 ca = new Vector3(b.x, b.y, b.z); 
            ba = b - a;
            ca = c - a;
            return (Vector3.Cross(ba, ca));
        }


    void createuebergang(Vector3 position)
    {
        a = new Vector3(3.0f, 0.0f, 2.5f) + position;
        b = new Vector3(0.0f, 0.0f, 2.5f) + position;
        c = new Vector3(0.0f, 0.0f, 0.0f) + position;
        d = new Vector3(3.0f, 0.0f, 0.0f) + position;

        e = new Vector3(3.0f, 0.2f, 2.5f) + position;
        f = new Vector3(0.0f, 0.2f, 2.5f) + position;
        g = new Vector3(0.0f, 0.2f, 0.0f) + position;
        h = new Vector3(3.0f, 0.2f, 0.0f) + position;

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
        Renderer rend = uebergang.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.SetTexture("_MainTex", steintextur);
   
        uebergang.transform.position = new Vector3(248.5f, 3.5f, 250);

        // BoxCollider:
        buebergang.size = new Vector3(3.25f, 0.2f, 2.75f);
        buebergang.center = new Vector3(1.5f, 0.11f, 1.25f);
        uc.size = new Vector3(3.25f, 0.1f, 2.75f);
        uc.center = new Vector3(1.5f, 0.4f, 1.25f);
       
        // Verbinden mit Script:
        uebergang.AddComponent<AM_charHolder>();
    }
                                                         
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
        uebergang.transform.position = Vector3.Lerp(uebergang.transform.position, 
        new Vector3(248.5f, 3.5f, 250), Time.deltaTime * 2.8f);

        uebergang3.transform.position = Vector3.Lerp(uebergang3.transform.position, 
        new Vector3(248.5f, 3.5f, 230.75f), Time.deltaTime * 2.8f);

        uebergang4.transform.position = Vector3.Lerp(uebergang4.transform.position, 
        new Vector3(248.5f, 3.5f, 233.5f), Time.deltaTime * 2.8f);

        uebergang6.transform.position = Vector3.Lerp(uebergang6.transform.position, 
        new Vector3(248.5f, 3.5f, 239), Time.deltaTime * 2.8f);
    }

    void floatingdown()
    {
        uebergang.transform.position = Vector3.Lerp(uebergang.transform.position, 
        new Vector3(248.5f, 2.25f, 250), Time.deltaTime * 1.8f);

        uebergang3.transform.position = Vector3.Lerp(uebergang3.transform.position, 
        new Vector3(248.5f, 2.25f, 230.75f), Time.deltaTime * 1.8f);

        uebergang4.transform.position = Vector3.Lerp(uebergang4.transform.position, 
        new Vector3(248.5f, 2.25f, 233.5f), Time.deltaTime * 1.8f);

        uebergang6.transform.position = Vector3.Lerp(uebergang6.transform.position, 
        new Vector3(248.5f, 2.25f, 239), Time.deltaTime * 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;

        if (timer > waitTime && moving == false) {

            floatingdown();
            if (timer > 7) {
                timer = 0;
                moving = true;
            }

        } else {

            floatingup();
            if (timer > 4) {
                moving = false;
            }
        }
    }
}
