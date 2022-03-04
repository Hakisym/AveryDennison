using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightElectrostaticRodsFirst : RightElectrostaticRods
{
    internal override void ClickedRightElectrostaticRods()
    {
        InventoryList.instance.UICanvas.Find("04_ElectrostaticRodsSecond").gameObject.SetActive(true);
    }
}
