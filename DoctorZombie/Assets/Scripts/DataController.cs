using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    //static는 단 하나만 존재하고 클래스 이름에서 바로 접근 가능하다 
    private static DataController instance;

    //get만 만들어서 가져올수는 있지만 set이 없으므로 저장은 할수 없다
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

    public long gold
    {
        get
        {
            //처음에는 빈 문장이 오므로 만약 비어있다면 숫자 0을 반환해준다. 
            if(!PlayerPrefs.HasKey("Gold"))
            { return 0;
            }

            string tmpGold = PlayerPrefs.GetString("Gold");
            return long.Parse(tmpGold); //스트링을 숫자로 변경해준다.
        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }

    public int goldPerClick
    {
        get
        {
            return PlayerPrefs.GetInt("GoldPerClick",1);
        }
        set
        {
            PlayerPrefs.SetInt("GoldPerClick",value);
        }
    }

    private void Awake()
    {

      //  PlayerPrefs.DeleteAll();
        herobuttons =FindObjectsOfType<HeroButton>(); //배열로 오브젝트를 가져와서 합친다
    }

  

   

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level",1);  // key_level 값을 가져와 저장한다
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);

    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);  // key_level 값을 가져와 저장한다
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);

    }

    public void LoadUpgradeItem(HeroButton herobutton)
    {
        string key = herobutton.itemName;

        herobutton.level = PlayerPrefs.GetInt(key + "_level");
        herobutton.currentCost = PlayerPrefs.GetInt(key + "_cost", herobutton.startCurrent);
        herobutton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec"); //아이템이 구매해야 늘어나야 하기때문에 0이 오도록 한다. 

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
            PlayerPrefs.SetInt(key + "_isPurchased", 1);  //구매를 했으면 숫자 1을 집어넣어준다.
            
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
