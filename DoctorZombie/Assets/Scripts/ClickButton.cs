using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    //콜라이더가 붙었있는 오브젝트를 클릭했을때 자동 실행 
    public void OnMouseDown()
    {
        int goldPerClick = DataController.Instance.goldPerClick;
        DataController.Instance.gold += goldPerClick;
    }
}
 