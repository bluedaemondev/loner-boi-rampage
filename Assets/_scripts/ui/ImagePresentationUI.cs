using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePresentationUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> pptList;
    [SerializeField] private int currentOnScreen;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    bool hasPrevious;

    // Start is called before the first frame update
    void Start()
    {
        prevButton.interactable = hasPrevious;
    }

    public void PassNext()
    {
        currentOnScreen++;

        if (currentOnScreen <= 1)
        {
            prevButton.interactable = false;
        }
        else
        {
            prevButton.interactable = true;
        }

        if (currentOnScreen == pptList.Count)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        pptList[currentOnScreen - 1].SetActive(true);
        pptList[Mathf.Max(currentOnScreen - 2, 0)].SetActive(false);
    }
    public void PassPrev()
    {
        currentOnScreen--;

        if (currentOnScreen <= 1)
        {
            prevButton.interactable = false;
        }
        else
        {
            prevButton.interactable = true;
        }
        if (currentOnScreen == pptList.Count)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        pptList[Mathf.Max(currentOnScreen - 1, 0)].SetActive(true);
        pptList[Mathf.Min(currentOnScreen, pptList.Count - 1)].SetActive(false);
    }

}
