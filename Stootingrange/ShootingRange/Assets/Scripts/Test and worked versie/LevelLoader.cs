using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject Loadingscreen;
    public Slider slider;
    public Text progressText;
    public void LoadLevel(int sceneIndex)
    {

        StartCoroutine(LoadAsynchronously(sceneIndex));

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        Loadingscreen.SetActive(true);

        while (!operation.isDone)
        {
            float  progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(slider.value);
            progressText.text = progress *100f + "%";
            yield return null;
        }
    }

}   
