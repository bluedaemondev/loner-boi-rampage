using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTranslate : MonoBehaviour
{
    public string ID;

    public LangManager manager;

    public Text myView;


    void Awake()
    {
        manager.onUpdate += ChangeLang;
    }

    void ChangeLang()
    {
        //var value = int.Parse(manager.GetTranslate(ID)); Si quisieran hacer cosas con enteros

        myView.text = manager.GetTranslate(ID);
    }
}
