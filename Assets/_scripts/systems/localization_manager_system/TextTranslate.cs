using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTranslate : MonoBehaviour
{
    public string ID;

    [SerializeField] Text myView;


    void Start()
    {
        myView = GetComponent<Text>();
        LangManager.Instance.onUpdate += ChangeLang;
    }

    private IEnumerator OnLevelWasLoaded(int level)
    {
        while (!myView)
            yield return null;

        ChangeLang();
    }

    void ChangeLang()
    {
        //print("Translating " + this.name);

        if (!myView)
            return;

        if (LangManager.Instance)
        {
            string trns = LangManager.Instance.GetTranslate(ID);

            this.myView.text = trns != string.Empty ? trns : myView.text;
        }

        //if (LangManager.Instance != null)
        //    myView.text = LangManager.Instance.GetTranslate(ID);
    }
    
}
