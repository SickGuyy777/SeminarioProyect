using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadLvl : MonoBehaviour
{
    public GameObject loadscenebackground,snake;
    public float tiempoEspera = 1.0f;
    public void PlayallLevels(string Name)
    {
        loadscenebackground.SetActive(true);
        snake.SetActive(true);
        StartCoroutine(CargarAsync(Name));
    }
    IEnumerator CargarAsync(string name)
    {
        AsyncOperation operacionCarga = SceneManager.LoadSceneAsync(name);
        while (!operacionCarga.isDone)
        {
            // Puedes mostrar una barra de progreso o realizar otras tareas mientras se carga la escena
            float progreso = Mathf.Clamp01(operacionCarga.progress / 0.9f);
            Debug.Log("Progreso de carga: " + (progreso * 100) + "%");

            yield return null; // Espera hasta el siguiente frame
        }
        yield return new WaitForSeconds(tiempoEspera);

    }
}
