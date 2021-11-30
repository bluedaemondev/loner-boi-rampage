using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyBonusTextUI : TotalPointsDisplayUI
{
    protected override void Start()
    {
        UpdateTextTotals();
    }

    protected override void UpdateTextTotals(params object[] vb)
    {
        this._container.text = "$" + PointsManager.Instance.AccuracyBonus;
    }
}
