using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    
    public void OnClick()
    {
        int goldPerClick = DataController.Instance.GetGoldPerClick();
        DataController.Instance.gold += goldPerClick;
    }
}
 