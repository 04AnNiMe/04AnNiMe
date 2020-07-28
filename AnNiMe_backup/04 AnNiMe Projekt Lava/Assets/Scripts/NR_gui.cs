using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code Gui:
public class NR_gui : MonoBehaviour
{
    public GUIStyle style;
    public int collectedItems = 0;
    public int leben = 5;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 25;
        style.normal.textColor = Color.red;
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
        
    }
}
