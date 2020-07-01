using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gui_script : MonoBehaviour
{
    public GUIStyle style;
    public int collectedItems = 0;
    public int leben = 10;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 46;
        style.normal.textColor = Color.red;
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(10, 0, 0, 0), "Gesammelte Härzchen: " + collectedItems, style);
        GUI.Label(new Rect(10, 50, 0, 0), "Leben: " + leben, style);
    }

    // Update is called once per frame
    void Update()
    {
        if (leben == 0)
        {
            Debug.Log("Tot");
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
    }
}
