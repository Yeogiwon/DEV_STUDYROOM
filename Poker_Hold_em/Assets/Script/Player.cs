using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int m_coin;

    public void GetCoin(int coins)
    {
        m_coin += coins;
    }

    public void LoseCoin(int coins)
    {
        m_coin -= coins;
    }
}
