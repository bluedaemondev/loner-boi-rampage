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
        //var value = int.Parse(manager.GetTranslate(ID)); Si quisieran hacer cosas con enteros

        myView.text = LangManager.Instance.GetTranslate(ID);
    }
}
