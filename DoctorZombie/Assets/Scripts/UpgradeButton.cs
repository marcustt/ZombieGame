using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer;

    string upgradeName;
    [HideInInspector]
    public int goldByUpgrade; //업그레이드 되는 양
    public int startGoldByUpgrade;
    [HideInInspector]
    public int level;

    public int currentCost; // 지금현재의 아이템 가격
    public int startCurrentCost;

    public float upgradePow = 2.14f;
    public float costPow = 4.54f;

    private void Start()
    {
        currentCost = startCurrentCost;
        level = 1;
        goldByUpgrade = startGoldByUpgrade;
        UpdataUI();

    }

    public void PurChaseUpgrade()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();  //업그레이드 할때마다 금액을 업데이트 해준다. 
            UpdataUI();
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level); //기준 pow에 level 만큼 제곱해준다
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdataUI()
    {
        upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext New GoldPerClick:" + goldByUpgrade; 

    }
}
