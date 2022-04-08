using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Inst { get; private set; }
    private void Awake() => Inst = this;

    public enum E_TURNSTATUS { SPREAD_CARD, OPEN_CARD, BETTING, SETCHIP, BATTLE, RETURN_CARD, READY};
    [SerializeField] E_TURNSTATUS m_e_TURNSTATUS;
    public enum E_TURNPLAYER { PLAYER, ENEMY1, ENEMY2, ENEMY3 };
    [SerializeField] E_TURNPLAYER m_e_TURNPLAYER;
    public enum E_TURNORDER { FREEFLIP, FLIP, TURN, RIVER, READY };
    [SerializeField] E_TURNORDER m_e_TURNORDER;

    public void PlayerAction(int idx)
    {
        switch (idx)
        {
            case 0: // 콜
                break;
            case 1: // 레이즈
                break;
            case 2: // 폴드
                break;
            default:
                break;
        }
    }

    public void SetSTATUS(int idx)
    {
        switch (idx)
        {
            case 0: m_e_TURNSTATUS = E_TURNSTATUS.SPREAD_CARD;
                
                break;
            case 1:
                m_e_TURNSTATUS = E_TURNSTATUS.OPEN_CARD;
                
                break;
            case 2:
                m_e_TURNSTATUS = E_TURNSTATUS.BETTING;
                
                break;
            case 3:
                m_e_TURNSTATUS = E_TURNSTATUS.SETCHIP;
                break;
            case 4:
                m_e_TURNSTATUS = E_TURNSTATUS.BATTLE;
                
                break;
            case 5:
                m_e_TURNSTATUS = E_TURNSTATUS.RETURN_CARD;
                break;
            default:
                break;
        }
    }

    public void UpdateStatus()
    {
        //StartCoroutine(GameManager.Inst.Delay());
        switch (m_e_TURNSTATUS)
        {
            case E_TURNSTATUS.SPREAD_CARD:
                if (m_e_TURNORDER == E_TURNORDER.FREEFLIP)
                {
                    PokerCardManager.Inst.CreateAllCard();
                }
                TurnManager.Inst.SetSTATUS(1);
                break;
            case E_TURNSTATUS.OPEN_CARD:
                if (m_e_TURNORDER == E_TURNORDER.FLIP)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        PokerCardManager.Inst.neutralCards[i].OpenCard();
                    }
                }
                else if (m_e_TURNORDER == E_TURNORDER.TURN)
                {
                    PokerCardManager.Inst.neutralCards[3].OpenCard();
                }
                else if (m_e_TURNORDER == E_TURNORDER.RIVER)
                {
                    PokerCardManager.Inst.neutralCards[4].OpenCard();
                }
                TurnManager.Inst.SetSTATUS(2);
                break;
            case E_TURNSTATUS.BETTING:
                if (m_e_TURNORDER == E_TURNORDER.FREEFLIP)
                {
                    Debug.Log(m_e_TURNORDER);
                }
                else if (m_e_TURNORDER == E_TURNORDER.FLIP)
                {
                    Debug.Log(m_e_TURNORDER);
                }
                else if (m_e_TURNORDER == E_TURNORDER.TURN)
                {
                    Debug.Log(m_e_TURNORDER);
                }
                else if (m_e_TURNORDER == E_TURNORDER.RIVER)
                {
                    Debug.Log(m_e_TURNORDER);
                }
                TurnManager.Inst.SetSTATUS(3);
                break;
            case E_TURNSTATUS.SETCHIP:
                TurnManager.Inst.SetSTATUS(4);

                break;
            case E_TURNSTATUS.BATTLE:
                if (m_e_TURNORDER != E_TURNORDER.RIVER)
                {

                }
                TurnManager.Inst.SetSTATUS(5);
                break;
            case E_TURNSTATUS.RETURN_CARD:
                if (m_e_TURNORDER == E_TURNORDER.RIVER)
                {
                    for (int i = 0; i < 4; i++) 
                    {
                        PokerCardManager.Inst.PedigreeCalculater(i);
                    }
                    
                }
                int order = (int)m_e_TURNORDER;
                order++;
                TurnManager.Inst.SetOrder(order);
                TurnManager.Inst.SetSTATUS(0);
                if(order == 3)
                {
                    SetSTATUS(6);
                }
                break;
            default:
                break;
        }
    }

    public void SetOrder(int idx)
    {
        switch (idx)
        {
            case 0: 
                m_e_TURNORDER = E_TURNORDER.FREEFLIP;
                break;
            case 1:
                m_e_TURNORDER = E_TURNORDER.FLIP;
                break;
            case 2:
                m_e_TURNORDER = E_TURNORDER.TURN;
                break;
            case 3:
                m_e_TURNORDER = E_TURNORDER.RIVER;
                break;
            default:
                break;
        }
    }

    public void UpdateOrder()
    {
        switch (m_e_TURNORDER)
        {
            case E_TURNORDER.FREEFLIP:
                break;
            case E_TURNORDER.FLIP:
                break;
            case E_TURNORDER.TURN:
                break;
            case E_TURNORDER.RIVER:
                break;
            default:
                break;
        }
    }


    public IEnumerator CountDelay()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(2.0f);
    }



    


}
