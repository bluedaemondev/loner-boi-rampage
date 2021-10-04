using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActivableAnalogStickInput : AnalogStickInput
{
    [SerializeField] private Image backgroundImage;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        //transform.position = eventData.position;

        //startPos = eventData.position;
        //backgroundImage.enabled = true;
        stickGraphic.enabled = true;
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        //stickGraphic.enabled = false;
        //backgroundImage.enabled = false;
    }
}
