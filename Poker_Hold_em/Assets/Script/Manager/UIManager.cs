using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[System.Serializable]
public class UIManager : MonoBehaviour
{
    static public UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject ChatUI;
    [SerializeField] TMP_Text TextUI;
    [SerializeField] bool isOpen = true;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SetONOFF();
    }

    public void SetONOFF()
    {
        if(isOpen)
        {
            ChatUI.SetActive(false);
            isOpen = false;
        }
        else
        {
            ChatUI.SetActive(true);
            isOpen = true;
        }
    }

    public void SetText(string text)
    {
        TextUI.text = text;
    }
}
