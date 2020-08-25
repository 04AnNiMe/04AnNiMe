using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AM_end : MonoBehaviour
{
    public GameObject endScreen;

    public Button newGame;

    // Start is called before the first frame update
    void Start()
    {
        endScreen = GameObject.Find("AM_Funktionen").transform.Find("EndScreen").gameObject;

        //Button endbtn = endScreen.GetComponent<Button>();
        //endbtn.onClick.AddListener(restart);
    }

    public void OnTriggerEnter(Collider other)
    {
        endScreen.SetActive(true);
        PauseGame();
        Debug.Log(this.name + " berührt " + other.gameObject.name);
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        endScreen.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
