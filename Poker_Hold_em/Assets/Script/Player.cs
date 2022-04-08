using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] public int m_coin { get; set; }

    static public Player Inst;
    private void Awake()
    {
        Inst = this;
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
