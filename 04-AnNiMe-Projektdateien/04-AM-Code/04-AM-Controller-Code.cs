
//AM_CharHolcer.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_charHolder : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        // Dem GameObject wird das gesuchte GameObject "RabbitWarrior01" übergeben
        Player = GameObject.Find("RabbitWarrior01");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Bei Collision wird der Player das Child von diesem GameObject
        Player.transform.parent = transform;
        Debug.Log(this.name + " ist nun Parent von " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        // Bei ende der Collision ist das Parent/Child verhältnis aufgelöst
        Player.transform.parent = null;
    }
}




//AM_Checkpoint.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_Checkpoint : MonoBehaviour
{
    public GameObject Player;
    public GameObject Knopf;
    public GameObject mark0;
    public GameObject mark1;
    public GameObject mark2;
    public GameObject mark3;
    public GameObject mark4;
    public GameObject mark5;
    public GameObject mark6;
    public GameObject mark7;


    AM_respawnPoint checkpointList;

    public Vector3 aktPos;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RabbitWarrior01");

        checkpointList = Player.GetComponent<AM_respawnPoint>();

        //GameObjecte Suchen und Zuweisen
        mark0 = GameObject.Find("AM_Checkpoint_0").transform.Find("Checkpoint_Mark_0").gameObject;
        mark1 = GameObject.Find("AM_Checkpoint_1").transform.Find("Checkpoint_Mark_1").gameObject;
        mark2 = GameObject.Find("AM_Checkpoint_2").transform.Find("Checkpoint_Mark_2").gameObject;
        mark3 = GameObject.Find("AM_Checkpoint_3").transform.Find("Checkpoint_Mark_3").gameObject;
        mark4 = GameObject.Find("AM_Checkpoint_4").transform.Find("Checkpoint_Mark_4").gameObject;
        mark5 = GameObject.Find("AM_Checkpoint_5").transform.Find("Checkpoint_Mark_5").gameObject;
        mark6 = GameObject.Find("AM_Checkpoint_6").transform.Find("Checkpoint_Mark_6").gameObject;
        mark7 = GameObject.Find("AM_Checkpoint_7").transform.Find("Checkpoint_Mark_7").gameObject;

    }

    // Diesen Button (this.) nach Unten bewegen
    void floatingdown()
    {
        this.transform.position = this.transform.position - new Vector3(0, 0.1f, 0);
    }

    /*
     * Alle Checkpoints werden gecheckt und alles was true ist wird auf false gestellt und der passende Button wird nach oben Transformiert
     * und die Markierung wird Uncheckt
     */
    void floatingUp()
    {
        //Check 0
        if (checkpointList.check0 == true)
        {
            checkpointList.check0 = false;
            mark0.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_0").transform.position = GameObject.Find("Checkpoint_Knopf_0").transform.position + new Vector3(0, 0.1f, 0);

        }

        //Check 1
        if (checkpointList.check1 == true)
        {
            checkpointList.check1 = false;
            mark1.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_1").transform.position = GameObject.Find("Checkpoint_Knopf_1").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 2
        if (checkpointList.check2 == true)
        {
            checkpointList.check2 = false;
            mark2.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_2").transform.position = GameObject.Find("Checkpoint_Knopf_2").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 3
        if (checkpointList.check3 == true)
        {
            checkpointList.check3 = false;
            mark3.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_3").transform.position = GameObject.Find("Checkpoint_Knopf_3").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 4
        if (checkpointList.check4 == true)
        {
            checkpointList.check4 = false;
            mark4.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_4").transform.position = GameObject.Find("Checkpoint_Knopf_4").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 5
        if (checkpointList.check5 == true)
        {
            checkpointList.check5 = false;
            mark5.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_5").transform.position = GameObject.Find("Checkpoint_Knopf_5").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 6
        if (checkpointList.check6 == true)
        {
            checkpointList.check6 = false;
            mark6.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_6").transform.position = GameObject.Find("Checkpoint_Knopf_6").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 7
        if (checkpointList.check7 == true)
        {
            checkpointList.check7 = false;
            mark7.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_7").transform.position = GameObject.Find("Checkpoint_Knopf_7").transform.position + new Vector3(0, 0.1f, 0);
        }

    }

    /* 
     * Es wird nach dem Checkpoint_Knopf Namen unterschieden.
     * Wenn dieser true ist dann wird bei Collision eine reihe von Funktionen ausgeführt.
     */
    void OnTriggerEnter(Collider other)
    {
        aktPos = this.transform.position;
        Knopf = this.gameObject;

        //Checkpoint 0
        if (Knopf == GameObject.Find("Checkpoint_Knopf_0") && checkpointList.check0 == false)
        {
            floatingUp();

            checkpointList.check0 = true;

            floatingdown();
            mark0.SetActive(true);
        }

        //Checkpoint 1
        if (Knopf == GameObject.Find("Checkpoint_Knopf_1") && checkpointList.check1 == false)
        {
            floatingUp();

            checkpointList.check1 = true;

            floatingdown();
            mark1.SetActive(true);
        }

        //Checkpoint 2
        if (Knopf == GameObject.Find("Checkpoint_Knopf_2") && checkpointList.check2 == false)
        {
            floatingUp();

            checkpointList.check2 = true;

            floatingdown();
            mark2.SetActive(true);
        }

        //Checkpoint 3
        if (Knopf == GameObject.Find("Checkpoint_Knopf_3") && checkpointList.check3 == false)
        {
            floatingUp();

            checkpointList.check3 = true;

            floatingdown();
            mark3.SetActive(true);
        }

        //Checkpoint 4
        if (Knopf == GameObject.Find("Checkpoint_Knopf_4") && checkpointList.check4 == false)
        {
            floatingUp();

            checkpointList.check4 = true;

            floatingdown();
            mark4.SetActive(true);
        }

        //Checkpoint 5
        if (Knopf == GameObject.Find("Checkpoint_Knopf_5") && checkpointList.check5 == false)
        {
            floatingUp();

            checkpointList.check5 = true;

            floatingdown();
            mark5.SetActive(true);
        }

        //Checkpoint 6
        if (Knopf == GameObject.Find("Checkpoint_Knopf_6") && checkpointList.check6 == false)
        {
            floatingUp();

            checkpointList.check6 = true;

            floatingdown();
            mark6.SetActive(true);
        }

        //Checkpoint 7
        if (Knopf == GameObject.Find("Checkpoint_Knopf_7") && checkpointList.check7 == false)
        {
            floatingUp();

            checkpointList.check7 = true;

            floatingdown();
            mark7.SetActive(true);
        }

    }

    private void Update()
    {
        /*
         * Wenn der bool true ist dann wird das Gameobject rotiert
         */
        if (checkpointList.check0)
        {
            mark0.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check1)
        {
            mark1.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check2)
        {
            mark2.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check3)
        {
            mark3.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check4)
        {
            mark4.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check5)
        {
            mark5.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check6)
        {
            mark6.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check6)
        {
            mark7.transform.Rotate(0, 0, 0.1f);
        }

    }

}




// AM_end.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AM_end : MonoBehaviour
{
    public int carrots = 0;
    public int hearts = 5;
    public bool end = false;

    public NR_gui guiLink;
    public GameObject jumpSound;
    public GameObject backgroundMusic;
    //public GameObject goldenCarrot;

    public InputField NameInputField;
    public Button BtnSave;
    public Button DeleteSave;
    public Button BtnNewGame;

    public Text countCarrots;
    public Text countHearts;

    public Text ScoreName;
    public Text ScoreCarrots;
    public Text ScoreLife;

    // Start is called before the first frame update
    void Start()
    {
        guiLink = GameObject.Find("NR_GuiEmpty").GetComponent<NR_gui>();

        //Dem Button die Funktion SaveAll() zuweisen
        BtnSave.onClick.AddListener(delegate
        {
            SaveAll();
        });

        //Dem Button die Funktion DeleteAll() zuweisen
        DeleteSave.onClick.AddListener(delegate
        {
            DeleteAll();
        });

        //Dem Text ScoreName das Gespeicherte zuweisen mit Hilfe von Schlüsselwörtern (z.B. "SaveName")
        ScoreName.text = PlayerPrefs.GetString("SaveName");
        ScoreCarrots.text = PlayerPrefs.GetString("SaveCarrots");
        ScoreLife.text = PlayerPrefs.GetString("SaveLife");

    }

    public void SaveAll()
    {
        //Als erstes dem Score die einzelnen Daten übergeben
        ScoreName.text = NameInputField.text;
        ScoreCarrots.text = countCarrots.text;
        ScoreLife.text = countHearts.text;

        //Einzelnen Schlüsselwörtern (z.B. "SaveName") die Werte zuweisen die vorher übergeben wurden
        PlayerPrefs.SetString("SaveName", ScoreName.text);
        PlayerPrefs.SetString("SaveCarrots", ScoreCarrots.text);
        PlayerPrefs.SetString("SaveLife", ScoreLife.text);
        PlayerPrefs.Save();

        //Debug.Log(PlayerPrefs.GetString("SaveName" + " Gespeichert!"));
        //Debug.Log(PlayerPrefs.GetString("SaveCarrots" + " Gespeichert!"));
        //Debug.Log(PlayerPrefs.GetString("SaveLife" + " Gespeichert!"));
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.Save();

        ScoreName.text = "";
        ScoreCarrots.text = "";
        ScoreLife.text = "";
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.name + " berührt " + other.gameObject.name);

        //if (other.gameObject == goldenCarrot)
        //{
        //Beim Triggern die int Werte in Strings umwandeln und übergeben
        countCarrots.text = carrots.ToString();
        countHearts.text = hearts.ToString();
        Debug.Log(this.name + " berührt " + other.gameObject.name);
        end = true;
        //}
    }

    private void Update()
    {
        jumpSound = GameObject.Find("JumpSound");
        backgroundMusic = GameObject.Find("Hintergrundmusik");

        if (hearts == 0 || end)
        {

            jumpSound.SetActive(false);
            backgroundMusic.SetActive(false);
        }
    }

}




// AM_levitatingPlate.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_levitatingPlate : MonoBehaviour
{
    public GameObject player;
    public GameObject plattform1;

    public bool upTrigger = false;
    public bool downTrigger = false;
    public bool forwardTrigger = false;
    public bool backTrigger = false;

    public float speed;

    public Vector3 aktPos1;
    public Vector3 startPos1;
    public Vector3 endPos1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("RabbitWarrior01");
        plattform1 = GameObject.Find("AM_Trampolin");
        startPos1 = plattform1.transform.position;
        endPos1 = plattform1.transform.position + new Vector3(26.13f, 2, 16.266f);
    }

    public void OnTriggerEnter(Collider other)
    {
        upTrigger = true;

    }

    public void OnTriggerExit(Collider other)
    {
        upTrigger = false;
    }

    void floatingUp()
    {
        aktPos1 = plattform1.transform.position;
        plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(0, 2, 0), Time.deltaTime * speed);
    }

    void floatingForward()
    {
        if (backTrigger)
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 - new Vector3(26.13f, 0, 16.266f), Time.deltaTime * speed);
        }
        else
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(26.13f, 0, 16.266f), Time.deltaTime * speed);
        }
    }

    void floatingDown()
    {
        if (backTrigger)
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(0, -2f, 0), Time.deltaTime * speed);
        }
        else
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(0, -1.8f, 0), Time.deltaTime * speed);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (upTrigger)
        {
            speed = 0.7f;
            floatingUp();
            if (aktPos1.y >= endPos1.y)
            {
                upTrigger = false;
                forwardTrigger = true;
            }
        }

        if (forwardTrigger)
        {
            speed = 0.2f;
            if (backTrigger)
            {
                floatingForward();
                if (aktPos1.x <= startPos1.x && aktPos1.z <= startPos1.z)
                {
                    forwardTrigger = false;
                    downTrigger = true;
                }
            }
            else
            {
                floatingForward();
                if (aktPos1.x >= endPos1.x && aktPos1.z >= endPos1.z)
                {
                    forwardTrigger = false;
                    downTrigger = true;
                }
            }
        }

        if (downTrigger)
        {
            speed = 0.7f;
            if (backTrigger)
            {
                floatingDown();
                if (aktPos1.y <= endPos1.y - 1.8f)
                {
                    downTrigger = false;
                    backTrigger = false;
                }
            }
            else
            {
                floatingDown();
                if (aktPos1.y <= endPos1.y - 1.8f)
                {
                    downTrigger = false;
                    backTrigger = true;
                }
            }
        }
    }
}




// AM_respawnPoint.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_respawnPoint : MonoBehaviour
{
    public bool check0 = false;
    public bool check1 = false;
    public bool check2 = false;
    public bool check3 = false;
    public bool check4 = false;
    public bool check5 = false;
    public bool check6 = false;
    public bool check7 = false;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("RabbitWarrior01");
        Player = gameObject;
    }

    //Diese Funktion teleportiert den Spieler an den letzten Checkpoint der mit den check bools gecheckt wird
    public void teleport()
    {
        if (check0)
        {
            Debug.Log("Teleport nach 0");

            Player.transform.position = GameObject.Find("Checkpoint_Knopf_0").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check1)
        {
            Debug.Log("Teleport nach 1");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_1").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check2)
        {
            Debug.Log("Teleport nach 2");

            Player.transform.position = GameObject.Find("Checkpoint_Knopf_2").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check3)
        {
            Debug.Log("Teleport nach 3");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_3").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check4)
        {
            Debug.Log("Teleport nach 4");

            Player.transform.position = GameObject.Find("Checkpoint_Knopf_4").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check5)
        {
            Debug.Log("Teleport nach 5");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_5").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check6)
        {
            Debug.Log("Teleport nach 6");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_6").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check7)
        {
            Debug.Log("Teleport nach 7");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_7").transform.position + new Vector3(0, 0.1f, 0);
        }
    }

}




// AM_timeStop.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_timeStop : MonoBehaviour
{
    AM_plattformen platten;
    public float timer;
    public Material standardMat;
    public Material stopMat;
    AudioSource tickSound;

    // Start is called before the first frame update
    void Start()
    {
        platten = GameObject.Find("AM_Empty Plattformen").GetComponent<AM_plattformen>();
        GetComponent<Renderer>().material = standardMat;

        tickSound = GetComponent<AudioSource>();
        tickSound.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        platten.timestop = true;
        tickSound.Play();
    }

    void stoptime()
    {
        timer += Time.deltaTime;

        if (timer >= 6)
        {
            platten.timestop = false;
            GetComponent<Renderer>().material = standardMat;
            tickSound.Stop();
            timer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (platten.timestop == true)
        {
            GetComponent<Renderer>().material = stopMat;
            stoptime();
        }
    }
}




// AMcameraMovement.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Die Scripts AMcameraMovement.cs und AMcharacterMovement.cs wurden mit hilfe der unten stehenden YouTube-Tutorials erstellt.
// AMcharacterMovement.cs wurde etwas mehr abgewandelt als AMcameraMovement.cs
// https://www.youtube.com/watch?v=txug_X8hlI0&list=PLvGUSoqe-UtZm_EAvsPNrKqh1_5rGcXRx&index=46&t=552s
// https://www.youtube.com/watch?v=BBS2nIKzmbw&list=PLvGUSoqe-UtZm_EAvsPNrKqh1_5rGcXRx&index=47&t=10s
// https://www.youtube.com/watch?v=1Po3E0nZOpM&list=PLvGUSoqe-UtZm_EAvsPNrKqh1_5rGcXRx&index=48&t=1s
// https://www.youtube.com/watch?v=MkbovxhwM4I&list=PL4CCSwmU04MjDqjY_gdroxHe85Ex5Q6Dy&index=4
// https://www.youtube.com/watch?v=Uqi2jEgvVsI&list=PL4CCSwmU04MjDqjY_gdroxHe85Ex5Q6Dy&index=5
// https://www.youtube.com/watch?v=7BcxyHi4Jwo&list=PL4CCSwmU04MjDqjY_gdroxHe85Ex5Q6Dy&index=6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcameraMovement : MonoBehaviour
{
    public Transform target;

    public Vector3 targetPosOffset = new Vector3(0, 3.4f, 0);
    public float lookSmooth = 100f;
    public float distanceFromTarget = -8;
    public float zoomSmooth = 100;
    public float maxZoom = -2;
    public float minZoom = -15;
    public bool smoothFollow = true;
    public float smooth = 0.05f;

    [HideInInspector]
    public float newDistance = -8; //set by zoom input
    [HideInInspector]
    public float adujstmentDistance = -8;

    public float xRotation = -20;
    public float yRotation = -180;
    public float maxXRotation = 25;
    public float minXRotation = -85;
    public float vOrbitSmooth = 150;
    public float hOrbitSmooth = 150;

    private string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
    private string ORBIT_HORIZONTAL = "OrbitHorizontal";                        // Kann auch auf Mouse X umgestellt werden oder OrbitHorizontal
    private string ORBIT_VERTICAL = "OrbitVertical";                            // Kann auch auf Mouse Y umgestellt werden oder OrbitVertical
    private string ZOOM = "Mouse ScrollWheel";

    [System.Serializable]
    public class DebugSettings
    {
        public bool drawDesiredCollisionLines = true;
        public bool drawAdjustedCollisionLines = true;
    }

    public DebugSettings debug = new DebugSettings();
    public CollisionHandlder collision = new CollisionHandlder();

    Vector3 targetPos = Vector3.zero;
    Vector3 destination = Vector3.zero;
    Vector3 adjustedDestionation = Vector3.zero;    //NEW
    Vector3 camVel = Vector3.zero;                  //NEW
    //AMcharacterMovement charController;
    float vOrbitInput;
    float hOrbitInput;
    float zoomInput;
    float hOrbitSnapInput;
    //float rotateVel = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraTarget(target);

        targetPos = target.position + targetPosOffset;
        destination = Quaternion.Euler(xRotation, yRotation, 0) * -Vector3.forward * distanceFromTarget;
        destination += targetPos;
        transform.position = destination;

        MoveToTarget();

        collision.Initialize(Camera.main);
        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);

    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        //if (target != null)
        //{
        //    if (target.GetComponent<AMcharacterMovement>())
        //    {
        //        charController = target.GetComponent<AMcharacterMovement>();
        //    } else
        //    {
        //        Debug.LogError("The camera's target needs a character controller");
        //    }
        //} else
        //{
        //    Debug.LogError("Your camera needs a target.");
        //}
    }

    void GetInput()
    {
        vOrbitInput = Input.GetAxisRaw(ORBIT_VERTICAL);
        hOrbitInput = Input.GetAxisRaw(ORBIT_HORIZONTAL);
        hOrbitSnapInput = Input.GetAxisRaw(ORBIT_HORIZONTAL_SNAP);
        zoomInput = Input.GetAxisRaw(ZOOM);
    }

    void Update()
    {
        GetInput();
        OrbitTarget();
        ZoomInOnTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movint
        MoveToTarget();
        //rotating
        LookAtTarget();

        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);

        //draw debug lines
        for (int i = 0; i < 5; i++)
        {
            if (debug.drawDesiredCollisionLines)
            {
                Debug.DrawLine(targetPos, collision.desiredCameraClipPoints[i], Color.white);
            }
            if (debug.drawAdjustedCollisionLines)
            {
                Debug.DrawLine(targetPos, collision.adjustedCameraClipPoints[i], Color.green);
            }
        }

        collision.CheckColliding(targetPos); //using raycasts here
        adujstmentDistance = collision.GetAdjustedDistanceWithRayFrom(targetPos);
    }

    void MoveToTarget()
    {
        targetPos = target.position + targetPosOffset;
        destination = Quaternion.Euler(xRotation, yRotation + target.eulerAngles.y, 0) * -Vector3.forward * distanceFromTarget;
        destination += targetPos;
        //transform.position = destination;

        if (collision.colliding)
        {
            adjustedDestionation = Quaternion.Euler(xRotation, yRotation + target.eulerAngles.y, 0) * Vector3.forward * adujstmentDistance;
            adjustedDestionation += targetPos;

            if (smoothFollow)
            {
                //use smooth damp function
                transform.position = Vector3.SmoothDamp(transform.position, adjustedDestionation, ref camVel, smooth);
            }
            else
            {
                transform.position = adjustedDestionation;
            }
        }
        else
        {
            if (smoothFollow)
            {
                //use smooth damp function
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVel, smooth);
            }
            else
            {
                transform.position = destination;
            }
        }
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, lookSmooth * Time.deltaTime);

    }

    void OrbitTarget()
    {
        if (hOrbitSnapInput > 0)
        {
            yRotation = -180;
        }

        xRotation += -vOrbitInput * vOrbitSmooth * Time.deltaTime;
        yRotation += -hOrbitInput * hOrbitSmooth * Time.deltaTime;

        if (xRotation > maxXRotation)
        {
            xRotation = maxXRotation;
        }
        if (xRotation < minXRotation)
        {
            xRotation = minXRotation;
        }
    }

    void ZoomInOnTarget()
    {
        distanceFromTarget += zoomInput * zoomSmooth * Time.deltaTime;

        if (distanceFromTarget > maxZoom)
        {
            distanceFromTarget = maxZoom;
        }
        if (distanceFromTarget < minZoom)
        {
            distanceFromTarget = minZoom;
        }
    }

    [System.Serializable]
    public class CollisionHandlder
    {
        public LayerMask collisionLayer;

        [HideInInspector]
        public bool colliding = false;
        [HideInInspector]
        public Vector3[] adjustedCameraClipPoints;
        [HideInInspector]
        public Vector3[] desiredCameraClipPoints;

        Camera camera;

        public void Initialize(Camera cam)
        {
            camera = cam;
            adjustedCameraClipPoints = new Vector3[5];
            desiredCameraClipPoints = new Vector3[5];
        }

        public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
        {
            if (!camera)
                return;

            //clear the contents of intoArray
            intoArray = new Vector3[5];

            float z = camera.nearClipPlane;
            float x = Mathf.Tan(camera.fieldOfView / 3.41f);        //kann man etwas verändern
            float y = x / camera.aspect;

            //top left
            intoArray[0] = (atRotation * new Vector3(-x, y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //top right
            intoArray[1] = (atRotation * new Vector3(x, y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //bottom left
            intoArray[2] = (atRotation * new Vector3(-x, -y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //bottom right
            intoArray[3] = (atRotation * new Vector3(x, -y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //cameras position
            intoArray[4] = cameraPosition - camera.transform.forward;
        }

        bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
        {
            for (int i = 0; i < clipPoints.Length; i++)
            {
                Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
                float distance = Vector3.Distance(clipPoints[i], fromPosition);
                if (Physics.Raycast(ray, distance, collisionLayer))
                {
                    return true;
                }
            }

            return false;
        }

        public float GetAdjustedDistanceWithRayFrom(Vector3 from)
        {
            float distance = -1;

            for (int i = 0; i < desiredCameraClipPoints.Length; i++)
            {
                Ray ray = new Ray(from, desiredCameraClipPoints[i] - from);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (distance == -1)
                        distance = hit.distance;
                    else
                        if (hit.distance < distance)
                        distance = hit.distance;
                }
            }

            if (distance == -1)
                return 0;
            else
                return distance;
        }

        public void CheckColliding(Vector3 targetPosition)
        {
            if (CollisionDetectedAtClipPoints(desiredCameraClipPoints, targetPosition))
            {
                colliding = true;
            }
            else
            {
                colliding = false;
            }
        }
    }
}




// AMcharacterMovement.cs //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcharacterMovement : MonoBehaviour
{
    public Animator animController;
    public float forwardVel = 7;                        // die Vorwärtsgeschwindigkeit vom Spieler
    public float standardVel = 7;
    public float speedVel = 12;
    public float sideVel = 4;
    public float rotateVel = 100;                       // die Rotationsgeschwindigkeit vom Spieler
    public float JumpVel = 30;                          // die Sprungkraft vom Spieler
    public float distanceGround = 0.2f;                 // die Entfernung zum Boden vom Spieler
    private float mouseRot;
    private float mouseRotSmooth = 0.3f;

    public LayerMask ground;
    public bool isGrounded = false;                     // Check ob der Spieler den Boden berührt

    public float downAccel = 2.5f;                      // die Geschwindigkeit mit der der Spieler Richtung Boden fällt

    public float inputDelay = 0.01f;                    //für einen kleinen Delay beim Drücken einer Taste

    public Vector3 velocity = Vector3.zero;             // Bewegung
    public Quaternion playerRotation;                   // für die aktuelle Rotation des Spielers
    Rigidbody rBody;                                    // Rigidbody
    public float forwardInput = 0;
    public float sideInput = 0;
    public float turnInput = 0;
    public float jumpInput = 0;                         // normale werte sind dann 1 und 0
    public float speedInput = 0;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        playerRotation = transform.rotation;            // der playerRotation die aktuelle Rotation übergeben

        //Check ob ein Rigidbody vorhanden ist
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The charactor needs a rigidbody!!");                // Falls kein Rigidbody vorhanden ist
        }

    }

    //Abstand vom GameObject bis zum Boden
    void Grounded()
    {
        // Es wird mit einem Raycast überprüft ob der Spieler vom Boden entfernt ist oder nicht
        if (!Physics.Raycast(transform.position, -Vector3.up, distanceGround + 0.1f))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    void GetInput()
    {
        //Input festlegen
        forwardInput = Input.GetAxis("Vertical");       //interpolated
        sideInput = Input.GetAxis("SideWalk");
        turnInput = Input.GetAxis("Horizontal");        //interpolated
        jumpInput = Input.GetAxisRaw("Jump");           //non-interpolated
        speedInput = Input.GetAxisRaw("SpeedUp");
    }

    void Run()
    {
        // Wenn der forwardInput größer als der inputDelay dann wird der Spieler bewegt
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            /* 
             * Bewegung des GameObjects indem beim Vector3 velocity die z Achse verändert wird
             * In der höhe von der forwardVel mal dem forwardInput
             */
            velocity.z = forwardVel * forwardInput;
        }
        else
        {
            //Bewegung in Z-Achse = 0 wenn kein forwardInput
            velocity.z = 0;
        }

        if (speedInput > 0)
        {
            forwardVel = speedVel;
            animController.speed = 1.3f;
        }
        else
        {
            forwardVel = standardVel;
            animController.speed = 1;
        }

    }

    void Turn()
    {
        // Wenn der turnInput größer als der inputDelay dann wird Rotiert
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            playerRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }

        // Zusätzlich noch ein Seitwärtsgang mit Q und E
        if (Mathf.Abs(sideInput) < 0)
        {
            velocity.x = sideInput * sideVel;
        }
        else
        {
            velocity.x = 0;
        }

        if (Mathf.Abs(sideInput) > 0)
        {
            velocity.x = sideInput * sideVel;
        }
        else
        {
            velocity.x = 0;
        }

        transform.rotation = playerRotation;            // den neuen Wert von playerRotation an den Spieler übergeben
    }

    void Jump()
    {
        if (jumpInput > 0 && isGrounded)
        {
            //Wenn Grounded true dann Jump möglich in höhe von der JumpVel in Richtung Y-Achse
            velocity.y = JumpVel;
        }
        else if (jumpInput == 0 && isGrounded)
        {
            //Bewegung in Y-Achse = 0 wenn kein jumpInput
            velocity.y = 0;
        }
        else
        {
            // Den Spieler in der Y-Achse nach Unten bewegen wenn er in der Luft ist
            velocity.y -= downAccel;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Lava")
    //    {
    //        Debug.Log(this.name + " 28.August " + other.gameObject.name);
    //        animController.SetInteger("Walking", 3);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        GetInput();

        // Bewegung ausführen
        if (forwardInput != 0 || sideInput != 0)
        {
            animController.SetInteger("Walking", 1);
        }
        else
        {
            animController.SetInteger("Walking", 0);
        }


        // Sprung ausführen
        if (jumpInput != 0)
        {
            animController.SetInteger("Walking", 2);
        }
        else if (forwardInput != 0 || sideInput != 0)
        {
            animController.SetInteger("Walking", 1);
        }
        else
        {
            animController.SetInteger("Walking", 0);
        }
    }

    private void FixedUpdate()
    {
        Run();
        Turn();
        Jump();
        Grounded();

        rBody.velocity = transform.TransformDirection(velocity);
    }
}
