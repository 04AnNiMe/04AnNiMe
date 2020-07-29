using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code Gui:
public class NR_gui : MonoBehaviour
{
    public GUIStyle style;
    public GUIStyle styleA;
    public int collectedItems = 0;
    public int leben = 5;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 25;
        style.normal.textColor = Color.red;

        styleA = new GUIStyle();
        styleA.fontSize = 35;
        styleA.normal.textColor = Color.red;
    }


    public void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(15, 0, 15, 0), "Carotts: " + collectedItems, style);
        // Herzchen sind Leben++
        GUI.Label(new Rect(15, 25, 15, 0), "Lives: " + leben, style);
        GUI.Label(new Rect(555, 0, 15, 0), "Level: 1", style);

    }

    // Update is called once per frame
    void Update()
    {
        // if (leben = 0)
        // {
        //    // GUI.Label(new Rect(150, 120, 0, 0), "Versuch es nocheinmal!", styleA);
        //     Debug.Log("Leider gestorben!");
        // }
        
    }
}
