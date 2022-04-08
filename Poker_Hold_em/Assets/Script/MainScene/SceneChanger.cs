using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneChanger : MonoBehaviour
{
    [SerializeField] public string SceneName;


    private void OnMouseDown()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        LoadingSceneController.LoadScene(SceneName);
    }

}
