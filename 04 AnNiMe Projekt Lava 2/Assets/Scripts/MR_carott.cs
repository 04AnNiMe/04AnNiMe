using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_carott : MonoBehaviour
{
    Mesh mesh;
    Mesh mesh2;
    GameObject karotte;
    GameObject gruen;
    GameObject empty;

    MeshCollider mc;
    CapsuleCollider cc;

    public Texture texture;
    public Texture texture2;

    List<Vector3> vertices; 
    List<int> faces;     
    List<Vector3> normals;   
    List<Vector2> uvs; 
    List<Vector3> vertices2; 
    List<int> faces2;     
    List<Vector3> normals2;   
    List<Vector2> uvs2;      
    Vector3 a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t;  
    int z = 0;
    int y = 0;
    Vector3 normale;


    // Start is called before the first frame update
    void Start()
    {
        vertices = new List<Vector3>();    
        faces = new List<int>();
        normals = new List<Vector3>();
        uvs = new List<Vector2>();
        vertices2 = new List<Vector3>();    
        faces2 = new List<int>();
        normals2 = new List<Vector3>();
        uvs2 = new List<Vector2>();

        //Stage1 start und höhle
        createCarott(331, 6, 16);
        createCarott(281, 10, 28);
        createCarott(266, 10, 27);
        createCarott(259, 10, 26);

        //Stage2 erste Insel incl zusatzinsel
        createCarott(166, 7, 25);
        createCarott(205, 7, 58);
        createCarott(211, 7, 61);
        createCarott(158, 7, 26);
        createCarott(141, 7, 25);
        createCarott(135, 9, 36);

        //Stage3 oben
        createCarott(127, 20, 54);
        createCarott(112, 19, 56);
        createCarott(101, 16, 56);

        //Stage4 insel kurve
        createCarott(96, 7, 30);
        createCarott(84, 7, 29);
        createCarott(60, 7, 34);
        createCarott(51, 7, 49);
        createCarott(53, 7, 74);
        createCarott(51, 7, 95);
        createCarott(59, 7, 119);
        createCarott(67, 7, 138);

        //Stage5 rollende steine 1
        createCarott(67, 6, 157);
        createCarott(78, 6, 149);

    }

    void createOrange()
    {
        a = new Vector3(1.0f, 0.0f, 1.0f);
        b = new Vector3(-1.0f, 0.0f, 1.0f);
        c = new Vector3(-1.0f, 0.0f, -1.0f);
        d = new Vector3(1.0f, 0.0f, -1.0f);

        e = new Vector3(1.0f, 2.0f, 1.0f);
        f = new Vector3(-1.0f, 2.0f, 1.0f);
        g = new Vector3(-1.0f, 2.0f, -1.0f);
        h = new Vector3(1.0f, 2.0f, -1.0f);

        i = new Vector3(0.5f, 8.0f, 0.5f);
        j = new Vector3(-0.5f, 8.0f, 0.5f);
        k = new Vector3(-0.5f, 8.0f, -0.5f);
        l = new Vector3(0.5f, 8.0f, -0.5f);

        m = new Vector3(0.5f, 0.0f, 0.5f);
        n = new Vector3(-0.5f, 0.0f, 0.5f);
        o = new Vector3(-0.5f, 0.0f, -0.5f);
        p = new Vector3(0.5f, 0.0f, -0.5f);

        q = new Vector3(1.0f, -3.0f, 1.0f);
        r = new Vector3(-1.0f, -3.0f, 1.0f);
        s = new Vector3(-1.0f, -3.0f, -1.0f);
        t = new Vector3(1.0f, -3.0f, -1.0f);

        //stamm
        createFaces(a, b, c, d);
        createFaces(d, c, b, a);
        createFaces(e, f, g, h);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
        createFaces(d, a, e, h);
        createFaces(b, c, g, f);

        //spitze
        createFaces(i, j, k, l);
        createFaces(i, l, h, e);
        createFaces(l, k, g, h);
        createFaces(j, i, e, f);
        createFaces(k, j, f, g);
    }

    void createGreen()
    {
        //Stängel
        createFaces2(t, s, r, q);
        createFaces2(p, o, s, t);
        createFaces2(m, p, t, q);
        createFaces2(n, m, q, r);
        createFaces2(o, n, r, s);
    }

    Vector3 createNormals(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 ab = b-a;
        Vector3 ac = c-a;
        return Vector3.Cross(ab, ac).normalized;
    }

    void createFaces( Vector3 a, Vector3 b, Vector3 c, Vector3 d )
    {
        vertices.Add(a); vertices.Add(b); vertices.Add(c); vertices.Add(d);       
        normale = createNormals(c, b, a);
        normals.Add(normale);normals.Add(normale);normals.Add(normale); normals.Add(normale);
        uvs.Add(new Vector2(0,0)); uvs.Add(new Vector2(1,0)); uvs.Add(new Vector2(0,1)); uvs.Add(new Vector2(1,1)); 
        faces.Add(z);
        faces.Add(z+2);
        faces.Add(z+1);
        faces.Add(z+2);
        faces.Add(z+0);
        faces.Add(z+3);
        z+=4;  
    }

       void createFaces2( Vector3 a, Vector3 b, Vector3 c, Vector3 d )
    {
        vertices2.Add(a); vertices2.Add(b); vertices2.Add(c); vertices2.Add(d);       
        normale = createNormals(c, b, a);
        normals2.Add(normale);normals2.Add(normale);normals2.Add(normale); normals2.Add(normale);
        uvs2.Add(new Vector2(0,0)); uvs2.Add(new Vector2(1,0)); uvs2.Add(new Vector2(0,1)); uvs2.Add(new Vector2(1,1)); 
        faces2.Add(y);
        faces2.Add(y+2);
        faces2.Add(y+1);
        faces2.Add(y+2);
        faces2.Add(y+0);
        faces2.Add(y+3);
        y+=4;  
    }

    void createCarott(int x, int y, int z){

        karotte = new GameObject("carott");  
        gruen = new GameObject("grün");  
 
        karotte.AddComponent<MeshFilter>();     
        karotte.AddComponent<MeshRenderer>();  

        gruen.AddComponent<MeshFilter>();     
        gruen.AddComponent<MeshRenderer>();  

        mesh = new Mesh();  
        mesh2 = new Mesh();                           
                         
        karotte.GetComponent<MeshFilter>().mesh = mesh; 
        gruen.GetComponent<MeshFilter>().mesh = mesh2;  

        Renderer rend = karotte.GetComponent<Renderer>();   
        rend.material = new Material(Shader.Find("Diffuse"));
        rend.material.mainTexture = texture;

        Renderer rend2 = gruen.GetComponent<Renderer>();   
        rend2.material = new Material(Shader.Find("Diffuse"));
        rend2.material.mainTexture = texture2;

        createOrange();
        createGreen();

        empty = new GameObject("KarottenEmpty");
        gruen.transform.parent = empty.transform;
        karotte.transform.parent = empty.transform;

        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();
        mesh2.vertices = vertices2.ToArray();         
        mesh2.normals = normals2.ToArray();
        mesh2.triangles = faces2.ToArray();
        mesh2.uv = uvs2.ToArray();

        empty.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
        empty.transform.Rotate(200, 0, 0);
        empty.transform.position = new Vector3(x, y, z);
        Quaternion rotation = Quaternion.Euler(200f, 0f, 0f);

        mc = empty.AddComponent<MeshCollider>();
        cc = empty.AddComponent<CapsuleCollider>();
        cc.isTrigger = true;

        cc.center = new Vector3(-0.26f, 2.6f, -0.09f);
        cc.height = 11.59f;
        cc.radius = 1.35f;
    }

    // Update is called once per frame
    void Update()
    {
        empty.transform.Rotate(0, 1, 0);
    }
}
