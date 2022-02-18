using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButton : MonoBehaviour
{
    public string itemName;

    public Text itemDisplayer;
    public int level;
    [HideInInspector]
    public int currentCost;

    public int startCurrent = 1;
    [HideInInspector]
    public int goldPerSec;

    public int startGoldPerSec =1;

    public float costPow = 3.14f;

    public float upgradePow = 4.56f;
    [HideInInspector]
    public bool isPurchased = false;

    private void Start()
    {
        DataController.GetInstance().LoadUpgradeItem(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
    }
    public void PurchasedItem()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            isPurchased = true;
            DataController.GetInstance().SubGold(currentCost);
            level++;
            UpdateItem();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeItem(this);
            

        }
    }

    IEnumerator AddGoldLoop()
    {
        while(true)
        {
            if(isPurchased)
            {
                DataController.GetInstance().AddGold(goldPerSec);
                
            }
            yield return new WaitForSeconds(1.0f);
        }
       
    }

    public void UpdateItem()
    {
        goldPerSec = startGoldPerSec * (int)Mathf.Pow(upgradePow,level);
        currentCost = startCurrent * (int)Mathf.Pow(costPow,level);


    }

    public void UpdateUI()
    {
        itemDisplayer.text = itemName + "\nLevel" + level + "\n Cost" + currentCost + "\nGold Per Sec: " + goldPerSec + "\nIs Purchased? " + isPurchased;
    }

}
