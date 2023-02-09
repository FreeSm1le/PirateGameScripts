using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loaderUI;
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private AK.Wwise.Event _loading;
    [SerializeField] private gameObject _loadd;

    public void LoadScene(int index)
    {
        AkSoundEngine.SetSwitch(AudioGlobalTextVariables.MusicContainer, AudioGlobalTextVariables.MusicStateQuite, _loadd);
        StartCoroutine(ShowRoutine(index));
    }

    private IEnumerator ShowRoutine(int index)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);
        yield return new WaitForSeconds(5);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                yield return new WaitForSeconds(5);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
