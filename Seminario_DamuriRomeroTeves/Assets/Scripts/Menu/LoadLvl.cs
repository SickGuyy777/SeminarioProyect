using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadLvl : MonoBehaviour
{
    public GameObject loadscenebackground;
    public Slider LoadSlider;
    public void PlayallLevels(string Name)
    {
      loadscenebackground.SetActive(true);
      StartCoroutine(CargarAsync(Name));
    }
    IEnumerator CargarAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone)
        {
            float Progreso = Mathf.Clamp01(operation.progress / .9f);
            LoadSlider.value = Progreso;
            yield return null;
        }
    }
}
