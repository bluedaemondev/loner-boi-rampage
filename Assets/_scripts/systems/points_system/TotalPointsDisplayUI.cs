using UnityEngine;
using Text = UnityEngine.UI.Text;

public abstract class TotalPointsDisplayUI : MonoBehaviour
{
    [SerializeField] protected Text _container;

    protected virtual void Awake()
    {
        if(_container == null)
            _container = GetComponent<Text>();
    }

    protected abstract void Start();
    protected abstract void UpdateTextTotals(params object[] vb);


}
