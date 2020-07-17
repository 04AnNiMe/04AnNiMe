using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_plattformen : MonoBehaviour
{
    Mesh mPlattform;
    GameObject goPlattform;
    GameObject Plattform2;
    GameObject Plattform3;
    GameObject Plattform4;
    GameObject Plattform5;
    BoxCollider colPlattform;
    BoxCollider colMovingChar;
    AM_charHolder charHalter;

    private List<Vector3> vPlattform;
    private List<int> fPlattform;
    private List<Vector3> nPlattform;
    private List<Vector2> uvPlattform;

    public Texture pTexture;
    public Vector3 position;
    private Vector3 norPlattform;

    private Vector3 b1;
    private Vector3 b2;
    private Vector3 b3;
    private Vector3 b4;

    private Vector3 t1;
    private Vector3 t2;
    private Vector3 t3;
    private Vector3 t4;

    private float hoehe;
    private float breite;
    private float tiefe;

    private float timer = 0.0f;
    private float waitTime = 2.0f;
    private bool moving = true;
    private float randDelta;
    private float randY1;
    private float randY2;
    private float randY3;
    private float randY4;
    private float randY5;
    private float randZ1;
    private float randZ2;
    private float randZ3;
    private float randZ4;
    private float randZ5;

    int z = 0;

    // Start is called before the first frame update
    void Start()
    {
        vPlattform = new List<Vector3>();
        fPlattform = new List<int>();
        nPlattform = new List<Vector3>();
        uvPlattform = new List<Vector2>();

        goPlattform = new GameObject("Plattform1");
        goPlattform.AddComponent<MeshFilter>();
        goPlattform.AddComponent<MeshRenderer>();
        goPlattform.layer = 9;

        mPlattform = new Mesh();
        colPlattform = goPlattform.AddComponent<BoxCollider>();
        colMovingChar = goPlattform.AddComponent<BoxCollider>();
        colMovingChar.isTrigger = true;

        goPlattform.GetComponent<MeshFilter>().mesh = mPlattform;

        createPlattform(2, 1, 4);
        //322, 3, 18

        Plattform2 = Instantiate(goPlattform, new Vector3(314, 3.8f, 21), goPlattform.transform.rotation);
        Plattform2.name = "Plattform2";
        Plattform3 = Instantiate(goPlattform, new Vector3(307, 4.3f, 17), goPlattform.transform.rotation);
        Plattform3.name = "Plattform3";
        Plattform4 = Instantiate(goPlattform, new Vector3(297, 5.8f, 20), goPlattform.transform.rotation);
        Plattform4.name = "Plattform4";
        Plattform5 = Instantiate(goPlattform, new Vector3(292, 6.9f, 23), goPlattform.transform.rotation);
        Plattform5.name = "Plattform5";

        randDelta = Random.Range(0.4f, 0.9f);
        randY1 = Random.Range(0.3f, 0.7f);
        randY2 = Random.Range(0.3f, 0.7f);
        randY3 = Random.Range(0.3f, 0.7f);
        randY4 = Random.Range(0.3f, 0.7f);
        randY5 = Random.Range(0.3f, 0.7f);
        randZ1 = Random.Range(2.1f, 6.7f);
        randZ2 = Random.Range(2.1f, 3.1f);
        randZ3 = Random.Range(2.1f, 4.4f);
        randZ4 = Random.Range(2.1f, 2.7f);
        randZ5 = Random.Range(2.1f, 4f);

        
    }

    Vector3 createNormale(Vector3 na, Vector3 nb, Vector3 nc)
    {
        Vector3 nab = nb - na;
        Vector3 nac = nc - na;
        return Vector3.Cross(nab, nac).normalized;
    }

    void createFacePlattform(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        vPlattform.Add(a);     //0
        vPlattform.Add(b);     //1
        vPlattform.Add(c);     //2
        vPlattform.Add(d);     //3

        norPlattform = createNormale(c, b, a);
        nPlattform.Add(norPlattform);
        nPlattform.Add(norPlattform);
        nPlattform.Add(norPlattform);
        nPlattform.Add(norPlattform);

        uvPlattform.Add(new Vector2(0, 0));
        uvPlattform.Add(new Vector2(1, 0));
        uvPlattform.Add(new Vector2(0, 1));
        uvPlattform.Add(new Vector2(1, 1));

        fPlattform.Add(z);     
        fPlattform.Add(z + 2);
        fPlattform.Add(z + 1);
        fPlattform.Add(z + 3);
        fPlattform.Add(z + 1);
        fPlattform.Add(z + 2);

        z += 4;
       
    }

    void createPlattform(float a, float b, float c)
    {
        breite = a;
        hoehe = b;
        tiefe = c;
        mPlattform.Clear();

        //Bottom
        b1 = new Vector3(-breite, -hoehe, -tiefe);
        b2 = new Vector3(-breite, -hoehe, tiefe);  
        b3 = new Vector3(breite, -hoehe, -tiefe);
        b4 = new Vector3(breite, -hoehe, tiefe);

        //Top
        t1 = new Vector3(-breite, hoehe, -tiefe);
        t2 = new Vector3(-breite, hoehe, tiefe);
        t3 = new Vector3(breite, hoehe, -tiefe);
        t4 = new Vector3(breite, hoehe, tiefe);

        createFacePlattform(b1, b2, b3, b4);
        createFacePlattform(t1, t2, b1, b2);
        createFacePlattform(t2, t4, b2, b4);
        createFacePlattform(t3, t1, b3, b1);
        createFacePlattform(t4, t3, b4, b3);
        createFacePlattform(t3, t4, t1, t2);

        mPlattform.vertices = vPlattform.ToArray();
        mPlattform.normals = nPlattform.ToArray();
        mPlattform.triangles = fPlattform.ToArray();
        mPlattform.uv = uvPlattform.ToArray();

        mPlattform.RecalculateNormals();
        mPlattform.RecalculateBounds();

        //colPlattform.sharedMesh = mPlattform;

        Renderer rendPlattform = goPlattform.GetComponent<Renderer>();
        rendPlattform.material = new Material(Shader.Find("Diffuse"));
        rendPlattform.material.mainTexture = pTexture;

        goPlattform.transform.position = new Vector3(322, 3, 18);
        colPlattform.size = new Vector3(breite * 2, hoehe * 2, tiefe * 2);
        colMovingChar.size = new Vector3(breite * 2, hoehe / 2, tiefe * 2);
        colMovingChar.center = new Vector3(0, 1.25f, 0);

        goPlattform.AddComponent<AM_charHolder>();
    }

    

    void floatingup()
    {
        goPlattform.transform.position = Vector3.Lerp(goPlattform.transform.position, new Vector3(322, 3 + randY1, 18 + randZ1), Time.deltaTime * randDelta);
        Plattform2.transform.position = Vector3.Lerp(Plattform2.transform.position, new Vector3(314, 3.8f + randY2, 21 + randZ2), Time.deltaTime * randDelta);
        Plattform3.transform.position = Vector3.Lerp(Plattform3.transform.position, new Vector3(307, 4.3f + randY3, 17 + randZ3), Time.deltaTime * randDelta);
        Plattform4.transform.position = Vector3.Lerp(Plattform4.transform.position, new Vector3(297, 4.4f + randY4, 20 + randZ4), Time.deltaTime * randDelta);
        Plattform5.transform.position = Vector3.Lerp(Plattform5.transform.position, new Vector3(292, 4.8f + randY5, 23 + randZ5), Time.deltaTime * randDelta);
    }

    void floatingdown()
    {
        goPlattform.transform.position = Vector3.Lerp(goPlattform.transform.position, new Vector3(322, 3, 18), Time.deltaTime * .7f);
        Plattform2.transform.position = Vector3.Lerp(Plattform2.transform.position, new Vector3(314, 3.8f, 21), Time.deltaTime * .7f);
        Plattform3.transform.position = Vector3.Lerp(Plattform3.transform.position, new Vector3(307, 4.3f, 17), Time.deltaTime * .7f);
        Plattform4.transform.position = Vector3.Lerp(Plattform4.transform.position, new Vector3(297, 4.4f, 20), Time.deltaTime * .7f);
        Plattform5.transform.position = Vector3.Lerp(Plattform5.transform.position, new Vector3(292, 4.8f, 23), Time.deltaTime * .7f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime && moving == false)
        {
            floatingdown();
            if (timer > 10)
            {
                timer = 0;
                moving = true;
            }

        } else 
        {
            
            floatingup();

            if (timer > 5)
            {
                randDelta = Random.Range(0.4f, 0.9f);
                randY1 = Random.Range(1.4f, 5.7f);
                randY2 = Random.Range(0.7f, 4.7f);
                randY3 = Random.Range(1.3f, 6.7f);
                randY4 = Random.Range(1.6f, 9.7f);
                randY5 = Random.Range(1.9f, 7.7f);

                randZ1 = Random.Range(-2.1f, 6.7f);
                randZ2 = Random.Range(-2.1f, 3.1f);
                randZ3 = Random.Range(-2.1f, 4.4f);
                randZ4 = Random.Range(-2.1f, 2.7f);
                randZ5 = Random.Range(-2.1f, 4f);
                moving = false;
            }
        }

    }
}
