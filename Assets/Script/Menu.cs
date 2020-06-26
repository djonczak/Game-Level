using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Menu : MonoBehaviour
{
    public Language pl;
    public Language ang;
    public Language ger;

    public GameObject menu;
    public GameObject settings;
    public GameObject loadButton;

    public Text[] menuText;

    string language;
    string langUpdate;
    string SaveStatus;

    public void Start()
    {
        settings.SetActive(false);
        Cursor.visible = true;
        langUpdate = PlayerPrefs.GetString("LANG", langUpdate);
        ExchangeLanguage(langUpdate);
        if (System.IO.File.Exists(Application.dataPath + "/save.json"))
        {
            loadButton.SetActive(true);
        }
        else
        {
            loadButton.SetActive(false);
        }
    }

    public void NewGame()
    {
        SaveStatus = "0";
        PlayerPrefs.SetString("Saves", SaveStatus);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        SaveStatus = "1";
        PlayerPrefs.SetString("Saves",SaveStatus);
        SceneManager.LoadScene("Test");
    }

    public void Settings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }

    public void SetPolish()
    {
        language = "PL";
        PlayerPrefs.SetString("LANG", language);
        ExchangeLanguage("PL");
    }

    public void SetEnglish()
    {
        language = "ENG";
        PlayerPrefs.SetString("LANG", language);
        ExchangeLanguage("ENG");
    }


    public void SetGerman()
    {
        language = "GER";
        PlayerPrefs.SetString("LANG", language);
        ExchangeLanguage("GER");
    }

    void ExchangeLanguage(string texts)
    {
        if(texts == "PL"){
            for (int i = 0; i < menuText.Length; i++)
            {
                menuText[i].text = pl.menusText[i];
            }
        }

        if (texts == "ENG")
        {
            for (int i = 0; i < menuText.Length; i++)
            {
                menuText[i].text = ang.menusText[i];
            }
        }

        if (texts == "GER")
        {
            for (int i = 0; i < menuText.Length; i++)
            {
                menuText[i].text = ger.menusText[i];
            }
        }
    }
}
    

