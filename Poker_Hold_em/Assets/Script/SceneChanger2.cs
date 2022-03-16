using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainScene");
    }
}
