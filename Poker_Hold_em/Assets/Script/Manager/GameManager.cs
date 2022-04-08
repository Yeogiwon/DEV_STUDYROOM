using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    
    public static GameManager Inst { get; private set; }
    private void Awake() => Inst = this;

    [SerializeField] PokerCardManager m_pokercardManager;
    [SerializeField] TurnManager m_turnManager;
    [SerializeField] UIManager m_uiManager;


    public PokerCardManager PokerCardManager
    {
        get { return m_pokercardManager; }
    }
    public TurnManager TurnManager
    {
        get { return m_turnManager; }
    }
    public UIManager UIManager
    {
        get { return m_uiManager; }
    }
    

    private void Start()
    {
        //UIManager.Init();
        //DontDestroyOnLoad(this);
        //StartCoroutine(Delay());
    }
    private void Update()
    {
        //TurnManager.Inst.UpdateOrder();
        //TurnManager.Inst.UpdateStatus();
        //StartCoroutine(TurnManager.CountDelay());
        if(Input.GetKeyUp(KeyCode.A))
        {
            StartCoroutine(Delay());
        }
        
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        TurnManager.Inst.UpdateStatus();
    }

}
