using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerCardManager : MonoBehaviour
{
    public static PokerCardManager Inst { get; private set; }
    private void Awake() => Inst = this;

    [SerializeField] PokerCardSO pokerCardSO;
    [SerializeField] GameObject pokercardPrefab;
    [SerializeField] public List<PokerObject> myCards;
    [SerializeField] public List<PokerObject> enemy1Cards;
    [SerializeField] public List<PokerObject> enemy2Cards;
    [SerializeField] public List<PokerObject> enemy3Cards;
    [SerializeField] public List<PokerObject> neutralCards;
    [SerializeField] List<Transform> MyPokerCardPoint; 
    [SerializeField] List<Transform> EnemyPokerCardPoint; 
    [SerializeField] List<Transform> NeutralPokerCardPoint; 

    List<PokerCard> pokerCardBuffer;

    private void Start()
    {
        SetupItemBuffer();
        //CreateAllCard();
    }

    void SetupItemBuffer() // 버퍼(덱) 세팅
    {
        pokerCardBuffer = new List<PokerCard>();
        for (int i = 0; i < pokerCardSO.pokerCards.Length; i++)
        {
            PokerCard card = pokerCardSO.pokerCards[i];
            pokerCardBuffer.Add(card);
        }
        for (int i = 0; i < pokerCardBuffer.Count; i++)
        {
            int rand = Random.Range(i, pokerCardBuffer.Count);
            PokerCard temp = pokerCardBuffer[i];
            pokerCardBuffer[i] = pokerCardBuffer[rand];
            pokerCardBuffer[rand] = temp;
        }
    }

    public PokerCard PopPokerCard() // 포커카드 버퍼(덱)에서 뽑기 
    {
        if (pokerCardBuffer.Count == 0)
        {
            SetupItemBuffer();
        }
        PokerCard pokerCard = pokerCardBuffer[0];
        pokerCardBuffer.RemoveAt(0);
        return pokerCard;
    }



    public void CreatePokerCard(int idx)
    {
        if (idx < 2) // 나 6시
        {
            var pokercardobject = Instantiate(pokercardPrefab, MyPokerCardPoint[idx].position, Utils.QI);
            var pokercard = pokercardobject.GetComponent<PokerObject>();
            pokercard.Setup(PopPokerCard(), true);
            myCards.Add(pokercard);
            
        }
        else if (idx < 4) // 적1 9시
        {
            var pokercardobject = Instantiate(pokercardPrefab, EnemyPokerCardPoint[idx-2].position, Utils.QI);
            var pokercard = pokercardobject.GetComponent<PokerObject>();
            pokercard.Setup(PopPokerCard(), false);
            enemy1Cards.Add(pokercard);
        }
        else if (idx < 6) // 적2 12시
        {
            var pokercardobject = Instantiate(pokercardPrefab, EnemyPokerCardPoint[idx-2].position, Utils.QI);
            var pokercard = pokercardobject.GetComponent<PokerObject>();
            pokercard.Setup(PopPokerCard(), false);
            enemy2Cards.Add(pokercard);
        }
        else if (idx < 8)  // 적3 3시
        {
            var pokercardobject = Instantiate(pokercardPrefab, EnemyPokerCardPoint[idx-2].position, Utils.QI);
            var pokercard = pokercardobject.GetComponent<PokerObject>();
            pokercard.Setup(PopPokerCard(), false);
            enemy3Cards.Add(pokercard);
        }
        else if (idx < 13)  //중간 중립카드
        {
            var pokercardobject = Instantiate(pokercardPrefab, NeutralPokerCardPoint[idx-8].position, Utils.QI);
            var pokercard = pokercardobject.GetComponent<PokerObject>();
            pokercard.Setup(PopPokerCard(), false);
            neutralCards.Add(pokercard);
            
        }
        else
        {

        }
    }

    public void CreateAllCard()
    {
        for(int i = 0; i< 13; i++)
        {
            CreatePokerCard(i);
        }
    }

    enum E_PEDIGREE { TOP, ONE_PAIR, TWO_PAIR, TRIPLE, STRAIGHT, BACK_STRAIGHT, FLUSH, FULLHOUSE, FOUR_CARD, STRAIGHT_FLUSH, BACK_STRAIGHT_FLUSH, ROYAL_STRAIGHT_FLUSH};
    
    [SerializeField] E_PEDIGREE e_Player = E_PEDIGREE.TOP;
    [SerializeField] E_PEDIGREE e_Enemy1 = E_PEDIGREE.TOP;
    [SerializeField] E_PEDIGREE e_Enemy2 = E_PEDIGREE.TOP;
    [SerializeField] E_PEDIGREE e_Enemy3 = E_PEDIGREE.TOP;

    public void PedigreeCalculater(int idx)
    {
        E_PEDIGREE e_result = E_PEDIGREE.TOP;
        PokerCards pokerCards = new();
        if (idx == 0)
        {
            pokerCards.SetUp(myCards);
        }
        else if(idx == 1)
        {
            pokerCards.SetUp(enemy1Cards);
        }
        else if (idx == 2)
        {
            pokerCards.SetUp(enemy2Cards);
        }
        else if (idx == 3)
        {
            pokerCards.SetUp(enemy3Cards);
        }
        pokerCards.Setup();

        if(pokerCards.isFlush())
        {
            if (pokerCards.isStraight())
            {
                e_result = E_PEDIGREE.STRAIGHT_FLUSH;
            }
            e_result = E_PEDIGREE.FLUSH;
        }
        else
        {
            if (pokerCards.isStraight())
            {
                e_result = E_PEDIGREE.STRAIGHT;
            }
            else
            {
                if (pokerCards.isOnePair())
                {
                    if (pokerCards.isTwoPair())
                    {
                        if (pokerCards.isTRIPLE())
                        {
                            if (pokerCards.isFourCard())
                            {
                                e_result = E_PEDIGREE.FOUR_CARD;
                            }
                            else if (pokerCards.isFullHouse())
                            {
                                e_result = E_PEDIGREE.FULLHOUSE;
                            }
                            else
                            {
                                e_result = E_PEDIGREE.TRIPLE;
                            }
                        }
                        else
                        {
                            e_result = E_PEDIGREE.TWO_PAIR;
                        }
                    }
                    else
                    {
                        e_result = E_PEDIGREE.ONE_PAIR;
                    }
                }
                else
                {
                    e_result = E_PEDIGREE.TOP;
                }
            }
        }
        
        if (idx == 0)
        {
            e_Player = e_result;
        }
        else if (idx == 1)
        {
            e_Enemy1 = e_result;
        }
        else if (idx == 2)
        {
            e_Enemy2 = e_result;
        }
        else if (idx == 3)
        {
            e_Enemy3 = e_result;
        }

        Debug.Log(e_result);
    }
}
