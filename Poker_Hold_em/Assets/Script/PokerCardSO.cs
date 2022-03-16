using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PokerCard
{
    public int m_Card_Number;
    public enum E_CARDTYPE { SPADE, HEART, DIAMOND, CLOVER, NONE };
    public E_CARDTYPE e_CARDTYPE;
    public Sprite FrontImage;
    public Sprite BackImage;
}

[CreateAssetMenu(fileName = "PokerCardSO", menuName = "Scriptable Object/PokerCardSO")]
public class PokerCardSO : ScriptableObject
{
    public PokerCard[] pokerCards;
}