using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = UnityEngine.UI.Text;

/// <summary>
///  pendiente de completar, quiero que sea una clase base
///  para los textos que tienen que interpolar numeros
/// </summary>
public class TextUtils : MonoBehaviour
{
    [SerializeField] private Text pointsDisplay;

    public string id;

    private int currentDisplay;
    private int maxDisplayTarget;

    [SerializeField]
    private float timeTweener = 0.02f;

    private YieldInstruction awaiter;
    private Coroutine crTweener;

    //public static void StartCoTween()

    public virtual IEnumerator MaxUpTween()
    {
        while (currentDisplay < maxDisplayTarget)
        {
            currentDisplay += 1;
            pointsDisplay.text =
                string.Format(LangManager.Instance != null ?
                LangManager.Instance.GetTranslate(id) + ":\n$ {0}" : "$ {0}", currentDisplay);
            yield return awaiter;
        }

        this.crTweener = null;
    }
}
