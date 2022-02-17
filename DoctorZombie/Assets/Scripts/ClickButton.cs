using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public DataController datacontroller;
    public void OnClick()
    {
        int goldPerClick = datacontroller.GetGoldPerClick();
        datacontroller.AddGold(goldPerClick);

    }
}
