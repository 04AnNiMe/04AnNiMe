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
