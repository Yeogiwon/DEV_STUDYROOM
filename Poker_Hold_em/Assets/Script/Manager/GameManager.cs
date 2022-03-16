using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] public int m_coin { get; set; }
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

    

    private void Start()
    {
        
    }
    private void Update()
    {
        //TurnManager.Inst.UpdateOrder();
        TurnManager.Inst.UpdateStatus();
        //StartCoroutine(TurnManager.CountDelay());
        
    }
}
