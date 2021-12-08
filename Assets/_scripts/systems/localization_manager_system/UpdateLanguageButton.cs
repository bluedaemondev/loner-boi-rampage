using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class UpdateLanguageButton : MonoBehaviour
{
    Button _btn;
    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(LangManager.Instance.TranslateUpdate);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(!_btn)
            _btn = GetComponent<Button>();

    }
}
