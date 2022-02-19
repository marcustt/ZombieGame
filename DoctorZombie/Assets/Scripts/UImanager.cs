using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text goldDisplayer;

    public Text goldPerClickDisplayer;

    public Text goldPerSecDisplayer;

    

    void Update()
    {
        
        goldDisplayer.text = "Gold: " + DataController.Instance.gold;
        goldPerClickDisplayer.text = "Gold Per Click :" + DataController.Instance.goldPerClick;
        goldPerSecDisplayer.text = "Gold Per Sec :" + DataController.Instance.GetGoldPerSec();
    }

}
