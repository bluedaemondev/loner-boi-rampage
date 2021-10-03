using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnalogStickInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    #region PROPERTIES
    [SerializeField] protected Image stickGraphic;
    protected Vector2 startPos;
    protected Vector2 currentPosDelta;
    protected Vector2 normPosDelta;
    [SerializeField] float maxStickDelta;
    protected float sqrMaxStickDelta;

    protected Action onPress;
    protected Action onRelease;
    #endregion
    
    #region GETTERS_SETTERS
    public Vector2 Value { get { return normPosDelta; } }
    #endregion

    #region METHODS

    // Start is called before the first frame update
    void Start()
    {
        startPos = stickGraphic.transform.position;
        sqrMaxStickDelta = maxStickDelta * maxStickDelta;
    }
    
    public void SubscribeToOnPress(Action method)
    {
        this.onPress += method;
    }
    public void SubscribeToOnRelease(Action method)
    {
        this.onRelease += method;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("began drag");
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        currentPosDelta += eventData.delta;
        if(currentPosDelta.sqrMagnitude > sqrMaxStickDelta)
        {
            currentPosDelta = currentPosDelta.normalized * maxStickDelta;
        }
        normPosDelta = currentPosDelta / maxStickDelta;
        stickGraphic.transform.position = startPos + currentPosDelta;

    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        // reset
        stickGraphic.transform.position = startPos;
        currentPosDelta.x = currentPosDelta.y = 0f;
        normPosDelta.x = normPosDelta.y = 0f;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (onPress != null)
            onPress();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (onRelease != null)
            onRelease();
    }
    #endregion
}
