using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code Gui:
public class NR_gui : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject endScreen;

    public GUIStyle customButton;
    public GUIStyle style;
    public GUIStyle styleA;
    public GUIStyle styleB;
    public GUIStyle styleC;
    public GUIStyle styleD;

    Color transparent = Color.white;

    public AM_end saveItems;     
    public Texture2D background;
    public float timer;

    public bool pluseins = false;


    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.font = (Font)Resources.Load("Lemon");
        style.fontSize = 50;
        style.normal.textColor = Color.red;

        styleA = new GUIStyle();
        styleA.font = (Font)Resources.Load("Lemon");

        styleB = new GUIStyle();
        styleB.font = (Font)Resources.Load("Lemon");
        styleB.fontSize = 35;
        styleB.normal.textColor = Color.white;

        styleC = new GUIStyle();
        styleC.font = (Font)Resources.Load("Lemon");
        styleC.fontSize = 45;
        styleC.normal.textColor = Color.black;

        styleD = new GUIStyle();
        styleD.font = (Font)Resources.Load("Lemon");
        styleD.fontSize = 100;
        styleD.normal.textColor = Color.red;

        saveItems = GameObject.Find("AM_Teleportplatte").GetComponent<AM_end>();
        deathScreen = GameObject.Find("AM_Funktionen").transform.Find("DeathScreen").gameObject;
        endScreen = GameObject.Find("AM_Funktionen").transform.Find("EndScreen").gameObject;

        transparent.a = 0f;

    }


    public void OnGUI()
    {
        // Button:
        //if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 10, Screen.height / 10), new GUIContent("Click"), customButton))
        //{
        //    ResumeGame();
        //}

        
            // Text:
            GUI.Label(new Rect(17, 15, 0, 0), "Carotts: " + saveItems.carrots, style);

            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height - 40, 0, 0), "Always remember the floor is lava!", styleB);

            // für kleiner weiß: GUI.Label(new Rect(Screen.width/2 - 50, 17, 0, 0), "THE LAVA GAME", styleB); 
            GUI.Label(new Rect(Screen.width / 2 - 80, 28, 0, 0), "THE LAVA GAME", styleC);

            // Herzchen sind Leben++
            GUI.Label(new Rect(17, 55, 0, 0), "Lives: " + saveItems.hearts, style);
            GUI.Label(new Rect(Screen.width - 106, 15, 0, 0), "Level: 1", style);


            if (pluseins == true)
            {
                GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 10, 0, 0), "+ 1", styleD);

                timer += Time.deltaTime;

                if (timer >= 0.7f)
                {
                    pluseins = false;
                    timer = 0;
                }
        }
    }
       
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathScreen.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (saveItems.hearts == 0 || saveItems.end)
        {

            style.normal.textColor = transparent;
            styleA.normal.textColor = transparent;
            styleB.normal.textColor = transparent;
            styleC.normal.textColor = transparent;
            styleD.normal.textColor = transparent;

            if (saveItems.end)
            {
                //Debug.Log("You finished the game!");
                endScreen.SetActive(true);
               

                PauseGame();
            }
            else
            {
                //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 10, Screen.height / 10), "Try again!", styleA);
                //Debug.Log("You died!");

                deathScreen.SetActive(true);
                PauseGame();
            }

        }
        else
        {
            ResumeGame();
        }

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Herz" || other.gameObject.name == "Herz" || other.gameObject.name == "Karotte"){
            pluseins = true;
            //Debug.Log("+ 1 ");
        }
    }    
    
}
