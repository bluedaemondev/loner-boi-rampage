using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCashLevelTextUI : TotalPointsDisplayUI
{
    protected override void Start()
    {
        UpdateTextTotals();
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, UpdateTextTotals);
    }

    protected override void UpdateTextTotals(params object[] vb)
    {
        this._container.text = "$" + PointsManager.Instance.GetTotal();
    }



}
