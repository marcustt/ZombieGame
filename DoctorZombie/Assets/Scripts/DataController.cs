using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    private static DataController instance;
    public static DataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();
            if(instance == null)
            {
                GameObject container = new GameObject("Datacontroller");
                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }
    public int m_gold;

    public int m_goldPerClick;

    public int GetGold()
    {
        m_gold = PlayerPrefs.GetInt("Gold", 0);
        return m_gold; 
    }

    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void AddGold(int newGold)
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGoldPerClick()
    {
       m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }


}
