using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    //static�� �� �ϳ��� �����ϰ� Ŭ���� �̸����� �ٷ� ���� �����ϴ� 
    private static DataController instance;

    //get�� ���� �����ü��� ������ set�� �����Ƿ� ������ �Ҽ� ����
    public static DataController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataController>();
                if (instance == null)
                {
                    GameObject container = new GameObject("Datacontroller");
                    instance = container.AddComponent<DataController>();
                }
            }
            return instance;
        }
    }

    private HeroButton[] herobuttons;

    public int gold
    {
        get
        {
            return PlayerPrefs.GetInt("Gold");
        }
        set
        {
            PlayerPrefs.SetInt("Gold", value);
        }
    }

    public int m_goldPerClick;

    private void Awake()
    {
       
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);

        herobuttons =FindObjectsOfType<HeroButton>(); //�迭�� ������Ʈ�� �����ͼ� ��ģ��
    }

  

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level",1);  // key_level ���� ������ �����Ѵ�
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);

    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);  // key_level ���� ������ �����Ѵ�
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);

    }

    public void LoadUpgradeItem(HeroButton herobutton)
    {
        string key = herobutton.itemName;

        herobutton.level = PlayerPrefs.GetInt(key + "_level");
        herobutton.currentCost = PlayerPrefs.GetInt(key + "_cost", herobutton.startCurrent);
        herobutton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec"); //�������� �����ؾ� �þ�� �ϱ⶧���� 0�� ������ �Ѵ�. 

        if (PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            herobutton.isPurchased = true;
        }
        else
        {
            herobutton.isPurchased = false;
        }
    }

    public void SaveUpgradeItem(HeroButton herobutton)
    {
        string key = herobutton.itemName;

         PlayerPrefs.SetInt(key + "_level", herobutton.level);
         PlayerPrefs.SetInt(key + "_cost", herobutton.currentCost);
         PlayerPrefs.SetInt(key + "_goldPerSec", herobutton.goldPerSec); 
        if (herobutton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);  //���Ÿ� ������ ���� 1�� ����־��ش�.
            
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }

    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for(int i = 0; i < herobuttons.Length;i++)
        {
            goldPerSec += herobuttons[i].goldPerSec;
        }
        return goldPerSec;
    }

}
