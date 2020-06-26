using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeLanguage : MonoBehaviour {

    public LangGame pl;
    public LangGame ang;
    public LangGame ger;

    public Text[] texts;
    string language;
    void Start()
    {
      language = PlayerPrefs.GetString("LANG", language);
        Exchange(language);
    }

    void Exchange(string text)
    {
        if (text == "PL")
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].text = pl.textToDisplay[i];
            }
        }

        if (text == "ENG")
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].text = ang.textToDisplay[i];
            }
        }


        if (text == "GER")
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].text = ger.textToDisplay[i];
            }
        }
    }
}

