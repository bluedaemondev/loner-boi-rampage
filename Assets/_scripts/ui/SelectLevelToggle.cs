using UnityEngine;
using Toggle = UnityEngine.UI.Toggle;


public class SelectLevelToggle : MonoBehaviour
{
    Toggle _btn;
    [SerializeField] int idLevel;
    [SerializeField] string description;


    // Start is called before the first frame update
    void Start()
    {
        if (!_btn)
            _btn = GetComponent<Toggle>();

        _btn.onValueChanged.AddListener(ToggleSelf);
    }
    void ToggleSelf(bool newValue)
    {
        //Debug.Log(this.name + " Got " + newValue);
        if (newValue)
            LevelStatsDisplayUI.Instance.UpdateLevelStats(idLevel, description);
    }
}
