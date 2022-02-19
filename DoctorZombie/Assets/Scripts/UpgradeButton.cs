using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    static public UpgradeButton instance;
    public static UpgradeButton GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<UpgradeButton>();
            if (instance == null)
            {
                GameObject container = new GameObject("UpgradeButton");
                instance = container.AddComponent<UpgradeButton>();
            }
        }
        return instance;
    }

    public Text upgradeDisplayer;

    public string upgradeName;
    [HideInInspector]
    public int goldByUpgrade; //업그레이드 되는 양
    public int startGoldByUpgrade =1;
    [HideInInspector]
    public int level;

    public int currentCost; // 지금현재의 아이템 가격
    public int startCurrentCost =1;

    public float upgradePow = 2.14f;
    public float costPow = 4.54f;

    private void Start()
    {
        instance = this; //

        DataController.GetInstance().LoadUpgradeButton(this);
        
        UpdateUI();

    }

    public void PurChaseUpgrade()
    {
        if (DataController.GetInstance().gold >= currentCost)
        {
            DataController.GetInstance().gold -= currentCost;
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);
            UpdateUpgrade();  //업그레이드 할때마다 금액을 업데이트 해준다. 
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this);
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level); //기준 pow에 level 만큼 제곱해준다
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
        UpdateUI();
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost +  "\nLevel: " + level + "\nNext New GoldPerClick:" + goldByUpgrade; 

    }
}
