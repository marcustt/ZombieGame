using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer;

    string upgradeName;
    [HideInInspector]
    public int goldByUpgrade; //���׷��̵� �Ǵ� ��
    public int startGoldByUpgrade;
    [HideInInspector]
    public int level;

    public int currentCost; // ���������� ������ ����
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

            UpdateUpgrade();  //���׷��̵� �Ҷ����� �ݾ��� ������Ʈ ���ش�. 
            UpdataUI();
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level); //���� pow�� level ��ŭ �������ش�
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdataUI()
    {
        upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext New GoldPerClick:" + goldByUpgrade; 

    }
}
