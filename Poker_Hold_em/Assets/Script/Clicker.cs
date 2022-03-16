using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Clicker : MonoBehaviour
{
    [SerializeField]int idx = 0;
    private void OnMouseDown()
    {
        PokerCardManager.Inst.PedigreeCalculater(idx);
    }
}
