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
    public int goldByUpgrade; //���׷��̵� �Ǵ� ��
    public int startGoldByUpgrade =1;
    [HideInInspector]
    public int level;

    public int currentCost; // ���������� ������ ����
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
            UpdateUpgrade();  //���׷��̵� �Ҷ����� �ݾ��� ������Ʈ ���ش�. 
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this);
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level); //���� pow�� level ��ŭ �������ش�
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
        UpdateUI();
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost +  "\nLevel: " + level + "\nNext New GoldPerClick:" + goldByUpgrade; 

    }
}
