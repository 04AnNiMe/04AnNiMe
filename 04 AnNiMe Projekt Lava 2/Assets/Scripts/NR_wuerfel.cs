using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_wuerfel : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cube;
    public Texture steintextur;
    Mesh mesh;
    MeshCollider aCube;
    
    Vector3 a, b, c, d, e, f, g, h; 
    List<Vector3> vertices;  
    List<int> faces;    
    List<Vector3> normals;
    Vector3 normal;   
    List<Vector2> uvs; 


    // Start is called before the first frame update
    void Start()
    {
        Cube = new GameObject("Steine"); 
        //Cube.transform.localScale = new Vector3(5, 2, 5);

        vertices = new List<Vector3>(); 
        faces = new List<int>();   
        normals = new List<Vector3>();
        uvs = new List<Vector2>();

        mesh = new Mesh();  
        Cube.AddComponent<MeshFilter>();     
        Cube.AddComponent<MeshRenderer>();  
        Cube.GetComponent<MeshFilter>().mesh = mesh; 

        // Material:
        Renderer rendCube = Cube.GetComponent<Renderer>();   
        rendCube.material = new Material(Shader.Find("Diffuse"));
        rendCube.material.SetTexture("_MainTex", steintextur);

        aCube = Cube.AddComponent<MeshCollider>();
        aCube.GetComponent<MeshFilter>().mesh = mesh;

        // Steine:
        createCubeOne();
        createCubeTwo();
        createCubeThree();
        createCubeFour();
        createCubeFive();
        createCubeSix();
        createCubeSeven();

        mesh.vertices = vertices.ToArray();         
        mesh.normals = normals.ToArray();
        mesh.triangles = faces.ToArray();
        mesh.uv = uvs.ToArray();

        // Verbinden mit Script:
        Cube.AddComponent<AM_charHolder>();
    }

    // Steine erstellen:
    void createCubeOne()
    {
        Vector3 position;
        // (Verschiebung nach vorne/hinten, hoehe, Verschiebung links/rechts);
        position = new Vector3(70.0f, 2.0f, 140.0f);
        createCube(position);
    }

    void createCubeTwo()
    {
        Vector3 position;
        position = new Vector3(75.0f, 2.0f, 141.0f);
        createCube(position);    
    }

    void createCubeThree()
    {
        Vector3 position;
        position = new Vector3(76.0f, 2.0f, 146.5f);
        createCube(position);    
    }

    void createCubeFour()
    {
        Vector3 position;
        position = new Vector3(70.0f, 2.0f, 150.0f);
        createCube(position);    
    }

    void createCubeFive()
    {
        Vector3 position;
        position = new Vector3(65.0f, 2.0f, 155.0f);
        createCube(position);    
    }

      void createCubeSix()
    {
        Vector3 position;
        position = new Vector3(70.0f, 2.0f, 157.0f);
        createCube(position);    
    }

      void createCubeSeven()
    {
        Vector3 position;
        position = new Vector3(65.5f, 2.0f, 162.0f);
        //position.transform.Rotate(0, 0, -1);
        createCube(position);    
    }



    private Vector3 getNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ba = new Vector3(b.x, b.y, b.z);
            Vector3 ca = new Vector3(b.x, b.y, b.z); 
            ba = b - a;
            ca = c - a;
            return (Vector3.Cross(ba, ca));
        }


    void createCube(Vector3 position)
    {
        a = new Vector3(4.0f, 0.0f, 4.0f) + position;
        b = new Vector3(0.0f, 0.0f, 4.0f) + position;
        c = new Vector3(0.0f, 0.0f, 0.0f) + position;
        d = new Vector3(4.0f, 0.0f, 0.0f) + position;

        e = new Vector3(4.0f, 2.0f, 4.0f) + position;
        f = new Vector3(0.0f, 2.0f, 4.0f) + position;
        g = new Vector3(0.0f, 2.0f, 0.0f) + position;
        h = new Vector3(4.0f, 2.0f, 0.0f) + position;

        createFaces(a, b, c, d);
        createFaces(d, c, b, a);
        createFaces(e, f, g, h);
        createFaces(c, d, h, g);
        createFaces(a, b, f, e);
        createFaces(d, a, e, h);
        createFaces(b, c, g, f);
    }

    int i = 0;
    void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        vertices.Add(a); 
        vertices.Add(b); 
        vertices.Add(c); 
        vertices.Add(d);  

        normal = getNormal(c, b, a);
        normals.Add(normal);
        normals.Add(normal);
        normals.Add(normal);
        normals.Add(normal);

        uvs.Add(new Vector2(0, 0)); 
        uvs.Add(new Vector2(1, 0)); 
        uvs.Add(new Vector2(0, 1)); 
        uvs.Add(new Vector2(1, 1)); 

        faces.Add(i);
        faces.Add(2 + i);
        faces.Add(1 + i);
        faces.Add(2 + i);
        faces.Add(0 + i);
        faces.Add(3 + i);
        i += 4;   
    }


    // Update is called once per frame
    void Update()
    {

    }
}
