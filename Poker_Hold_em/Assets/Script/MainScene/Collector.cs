using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] int debt;
    [SerializeField] bool is_Paid_Back = false;

    private void OnMouseDown()
    {
        UIManager.instance.SetONOFF();
        isPaidBack();
    }


    public void IncreaseDebt()
    {
        debt = (int)(debt * 1.2);
    }

    public bool isPaidBack()
    {
        if(Player.Inst.m_coin >= debt)
        {
            is_Paid_Back = true;
            Debug.Log("��ȯ �Ϸ�");
            return true;
        }
        else
        {
            Debug.Log("���� ������");
            return false;
        }
    }

}
