using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text goldDisplayer;

    public Text goldPerClickDisplayer;

    public DataController datacontroller;

    void Update()
    {
        goldDisplayer.text = "Gold: " + datacontroller.GetGold();
        goldPerClickDisplayer.text = "Gold Per Click :" + datacontroller.GetGoldPerClick();
    }

}
