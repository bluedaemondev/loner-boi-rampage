using UnityEngine;
using Button = UnityEngine.UI.Button;

public class SavePrefsButtonUI : MonoBehaviour
{
    private Button _btn;
    [SerializeField] bool _deactivate = true;

    void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(SavePrefsTrigger);
    }

    // Update is called once per frame
    void SavePrefsTrigger()
    {
        if (_deactivate)
            _btn.interactable = false;
        
        PlayerPrefsManager.Instance.StartCoroutine(PlayerPrefsManager.Instance.SavePrefs<Prefs>());
    }
}
