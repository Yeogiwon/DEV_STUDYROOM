using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }
    private void Awake() => Inst = this;

    [SerializeField] PokerCardManager m_pokercardManager;
    [SerializeField] TurnManager m_turnManager;
    public PokerCardManager PokerCardManager
    {
        get { return m_pokercardManager; }
    }
    public TurnManager TurnManager
    {
        get { return m_turnManager; }
    }


    private void Update()
    {
        //TurnManager.Inst.UpdateOrder();
        TurnManager.Inst.UpdateStatus();
    }
}
