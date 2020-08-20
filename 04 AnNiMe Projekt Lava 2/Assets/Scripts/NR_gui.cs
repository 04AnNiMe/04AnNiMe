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
        //styleA.fontSize = 35;
        //styleA.normal.textColor = Color.black;
        //styleA.normal.background = background;
        //styleA.border.top = -20;
        //styleA.border.bottom = -20;
        //styleA.border.left = -20;
        //styleA.border.right = -20;

        styleB = new GUIStyle();
        styleB.font = (Font)Resources.Load("Lemon");
        styleB.fontSize = 20;
        styleB.normal.textColor = Color.black;

        Button btn = restartBTN.GetComponent<Button>();
        btn.onClick.AddListener(Restard);

    }

    public void OnGUI()
    {
        // Button:

        //if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 10, Screen.height / 10), new GUIContent("Click"), customButton))
        //{
        //    ResumeGame();
        //}


        // Text:
        GUI.Label(new Rect(15, 0, 0, 0), "Carotts: " + collectedItems, style);
        GUI.Label(new Rect(15, 540, 0, 0), "Always remember the floor is LAVA!", styleB);

        // Herzchen sind Leben++
        GUI.Label(new Rect(15, 30, 0, 0), "Lives: " + leben, style);
        GUI.Label(new Rect(810, 0, 0, 0), "Level: 1", style);


        if (leben == 0)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 10, Screen.height / 10), "Try again!", styleA);
            Debug.Log("You died!");

            deathScreen.SetActive(true);
            PauseGame();
        } else
        {
            ResumeGame();
        }

    }

    public void Restard()
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
