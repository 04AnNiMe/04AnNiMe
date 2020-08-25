using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code Gui:
public class NR_gui : MonoBehaviour
{
    public GameObject deathScreen;
    public Button restartBTN;

    public GUIStyle customButton;
    public GUIStyle style;
    public GUIStyle styleA;
    public GUIStyle styleB;
    public GUIStyle styleC;
    public GUIStyle styleD;
    public int collectedItems = 0;
    public int leben = 5;
    

    public Texture2D background;

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
        styleB.fontSize = 30;
        styleB.normal.textColor = Color.white;

        styleC = new GUIStyle();
        styleC.font = (Font)Resources.Load("Lemon");
        styleC.fontSize = 45;
        styleC.normal.textColor = Color.red;

        styleD = new GUIStyle();
        styleD.font = (Font)Resources.Load("Lemon");
        styleD.fontSize = 100;
        styleD.normal.textColor = Color.red;


        Button btn = restartBTN.GetComponent<Button>();
        btn.onClick.AddListener(Restart);

    }

    public void OnGUI()
    {
        // Button:

        //if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 10, Screen.height / 10), new GUIContent("Click"), customButton))
        //{
        //    ResumeGame();
        //}


        // Text:
        GUI.Label(new Rect(17, 15, 0, 0), "Carotts: " + collectedItems, style);

        GUI.Label(new Rect(Screen.width / 2 - 125, Screen.height - 40, 0, 0), "Always remember the floor is lava!", styleB);

        // für kleiner weiß: GUI.Label(new Rect(Screen.width/2 - 50, 17, 0, 0), "THE LAVA GAME", styleB); 
        GUI.Label(new Rect(Screen.width / 2 - 80, 28, 0, 0), "THE LAVA GAME", styleC);              

        // Herzchen sind Leben++
        GUI.Label(new Rect(17, 55, 0, 0), "Lives: " + leben, style);
        GUI.Label(new Rect(Screen.width - 106, 15, 0, 0), "Level: 1", style);



        // geht noch nicht ...
        // wenn man ein Herz oder eine Karotte einsammelt soll kurz +1 erscheinen:
        // if (collectedItems++)
        // {
        //     GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 10, 0, 0), "+ 1", styleD);
        //     Debug.Log("+ 1 Carott");
        // }



        if (leben == 0)
        {
            //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 10, Screen.height / 10), "Try again!", styleA);
            Debug.Log("You died!");

            deathScreen.SetActive(true);
            PauseGame();
        } else {
            ResumeGame();
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
        
    }
}
