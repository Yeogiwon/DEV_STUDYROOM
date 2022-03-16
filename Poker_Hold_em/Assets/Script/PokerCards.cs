using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokerCards : MonoBehaviour
{
    List<PokerObject> pokerObjects;

    List<PokerObject> Neutral;

    public void Setup()
    {
        Neutral = PokerCardManager.Inst.neutralCards;
    }

    public void SetUp(List<PokerObject> pokerObjects)
    {
        this.pokerObjects = pokerObjects;
    }

    public bool isFlush()
    {
        bool result = false;
        int number = (int)pokerObjects[0].pokerCard.e_CARDTYPE;
        if((int)pokerObjects[1].pokerCard.e_CARDTYPE == number)
        {
            int a = 0;
            for (int i = 0; i < 5; i++) 
            {
                if((int)Neutral[i].pokerCard.e_CARDTYPE == number)
                {
                    a++;
                }
            }
            if(a>=3)
            {
                result = true;
            }
        }
        return result;
    }

    public bool isStraight()
    {
        bool result = false;
        int[] number = { 0,0,0,0,0,0,0};
        number[0] = (pokerObjects[0].pokerCard.m_Card_Number);
        number[1] = (pokerObjects[1].pokerCard.m_Card_Number);
        for (int i = 0; i < 5; i++)
        {
            number[i+2] = (Neutral[i].pokerCard.m_Card_Number);
        }
        var list = new List<int>();
        list.AddRange(number);
        list.Sort();
        list.Add(0);
        list.Add(0);
        int a = 0;
        for (int i = 0; i < 7; i++)
        {
            if (list[i] + 1 == list[i + 1])
            {
                a++;
            }
        }
        if (a >= 4) 
        {
            result = true;
        }
        return result;
    }

    public bool isOnePair()
    {
        bool result = false;
        int[] number = { 0, 0, 0, 0, 0, 0, 0 };
        number[0] = (pokerObjects[0].pokerCard.m_Card_Number);
        number[1] = (pokerObjects[1].pokerCard.m_Card_Number);
        for (int i = 0; i < 5; i++)
        {
            number[i + 2] = (Neutral[i].pokerCard.m_Card_Number);
        }
        var list = new List<int>();
        list.AddRange(number);
        list.Sort();
        list.Add(0);
        list.Add(0);
        int a = 0;
        for (int i = 0; i < 7; i++)
        {
            if (list[i] == list[i + 1])
            {
                a++;
            }
        }
        if (a >= 1)
        {
            result = true;
        }
        return result;
    }
    public bool isTwoPair()
    {
        bool result = false;
        int[] number = { 0, 0, 0, 0, 0, 0, 0 };
        number[0] = (pokerObjects[0].pokerCard.m_Card_Number);
        number[1] = (pokerObjects[1].pokerCard.m_Card_Number);
        for (int i = 0; i < 5; i++)
        {
            number[i + 2] = (Neutral[i].pokerCard.m_Card_Number);
        }
        var list = new List<int>();
        list.AddRange(number);
        list.Sort();
        int a = 0;
        list.Add(0);
        list.Add(0);
        for (int i = 0; i < 7; i++)
        {
            if (list[i] == list[i + 1])
            {
                if(list[i] != list[i+2])
                {
                    a++;
                }
            }
        }
        if (a >= 2)
        {
            result = true;
        }
        return result;
    }
    public bool isTRIPLE()
    {
        bool result = false;
        int[] number = { 0, 0, 0, 0, 0, 0, 0 };
        number[0] = (pokerObjects[0].pokerCard.m_Card_Number);
        number[1] = (pokerObjects[1].pokerCard.m_Card_Number);
        for (int i = 0; i < 5; i++)
        {
            number[i + 2] = (Neutral[i].pokerCard.m_Card_Number);
        }
        var list = new List<int>();
        list.AddRange(number);
        list.Sort();
        int a = 0;
        list.Add(0);
        list.Add(0);
        for (int i = 0; i < 7; i++)
        {
            if (list[i] == list[i + 1])
            {
                if (list[i] == list[i + 2])
                {
                    a++;
                }
            }
        }
        if (a >= 1)
        {
            result = true;
        }
        return result;
    }

    public bool isFourCard()
    {
        bool result = false;
        int[] number = { 0, 0, 0, 0, 0, 0, 0 };
        number[0] = (pokerObjects[0].pokerCard.m_Card_Number);
        number[1] = (pokerObjects[1].pokerCard.m_Card_Number);
        for (int i = 0; i < 5; i++)
        {
            number[i + 2] = (Neutral[i].pokerCard.m_Card_Number);
        }
        var list = new List<int>();
        list.AddRange(number);
        list.Sort();
        int a = 0;
        list.Add(0);
        list.Add(0);
        list.Add(0);
        for (int i = 0; i < 7; i++)
        {
            if (list[i] == list[i + 1])
            {
                if (list[i] == list[i + 2])
                {
                    if (list[i] == list[i + 3])
                    {
                        a++;
                    }
                }
            }
        }
        if (a >= 1)
        {
            result = true;
        }
        return result;
    }
    public bool isFullHouse() // °í¹ÎÇØº¸±â
    {
        bool result = false;
        int[] number = { 0, 0, 0, 0, 0, 0, 0 };
        number[0] = (pokerObjects[0].pokerCard.m_Card_Number);
        number[1] = (pokerObjects[1].pokerCard.m_Card_Number);
        for (int i = 0; i < 5; i++)
        {
            number[i + 2] = (Neutral[i].pokerCard.m_Card_Number);
        }
        var list = new List<int>();
        list.AddRange(number);
        list.Sort();
        int a = 0;
        int b = 0;
        list.Add(0);
        list.Add(0);
        list.Add(0);
        for (int i = 0; i < 7; i++)
        {
            if (list[i] == list[i + 1])
            {
                b++;
                if (list[i] == list[i + 2])
                {
                    a++;
                }
            }
        }
        if (a >= 1 && b>=3)
        {
            result = true;
        }
        return result;
    }
}
