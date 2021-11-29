using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTranslate : MonoBehaviour
{
    public string ID;

    public Text myView;


    void Start()
    {
        LangManager.Instance.onUpdate += ChangeLang;
    }

    void ChangeLang()
    {
        print("Translating " + this.name);

        if (LangManager.Instance)
        {
            string trns = LangManager.Instance.GetTranslate(ID);
            this.myView.text = trns != string.Empty ? trns : myView.text;
        }

        //if (LangManager.Instance != null)
        //    myView.text = LangManager.Instance.GetTranslate(ID);
    }
    IEnumerator AwaitCodexTranslate()
    {
        bool translated = false;
        while( !translated || LangManager.Instance == null)
        {
            yield return null;
        }

    }
}
