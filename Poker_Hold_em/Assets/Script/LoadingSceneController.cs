using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image ProgressBar;

    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }


    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;
            if (op.progress < 0.9f)
            {
                ProgressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                ProgressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (ProgressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }

        }

    }
}

