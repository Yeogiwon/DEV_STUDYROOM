using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer cardsprite;

    public PokerCard pokerCard;
    public bool isOpen = false;
    public bool isMine = false;

    public void Setup(PokerCard Card, bool ismine)
    {
        this.pokerCard = Card;
        this.cardsprite.sprite = Card.BackImage;
        this.isMine = ismine;

    }

    public void OpenCard()
    {
        if (isOpen == false)
        {
            this.cardsprite.sprite = pokerCard.FrontImage;
            this.isOpen = true;
        }
        else
        {
            this.cardsprite.sprite = pokerCard.BackImage;
            this.isOpen = false;
        }
    }
    private void OnMouseDown()
    {
        if (isMine)
        {
            OpenCard();
        }
    }
}
