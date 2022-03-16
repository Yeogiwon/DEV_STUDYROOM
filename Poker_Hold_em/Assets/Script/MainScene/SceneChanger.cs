using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("GambleScene");
    }
}
