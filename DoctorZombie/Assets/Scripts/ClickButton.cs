using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    //�ݶ��̴��� �پ��ִ� ������Ʈ�� Ŭ�������� �ڵ� ���� 
    public void OnMouseDown()
    {
        int goldPerClick = DataController.Instance.goldPerClick;
        DataController.Instance.gold += goldPerClick;
    }
}
 