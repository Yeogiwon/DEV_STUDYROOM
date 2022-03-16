using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    [SerializeField] bool istypeOrder;
    int a = 0;
    int b = 0;

    private void OnMouseDown()
    {
        if (!istypeOrder)
        {
            TurnManager.Inst.SetSTATUS(a);
            a++;
            if (a == 6)
            {
                a = 0;
            }
        }
        else
        {
            TurnManager.Inst.SetOrder(b);
            b++;
            if (b == 4)
            {
                b = 0;
            }
        }
    }
}
