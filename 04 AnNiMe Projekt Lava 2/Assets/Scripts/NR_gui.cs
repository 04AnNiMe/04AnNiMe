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
        style.fontSize = 40;
        style.normal.textColor = Color.red;
    }


    public void OnGUI()
    {
        GUI.Label(new Rect(10, 0, 0, 0), "Gesammelte Herzchen: " + collectedItems, style);
        GUI.Label(new Rect(10, 40, 0, 0), "Gesammelte Karotten: " + collectedItems, style);
        GUI.Label(new Rect(10, 80, 0, 0), "Leben: " + leben, style);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
