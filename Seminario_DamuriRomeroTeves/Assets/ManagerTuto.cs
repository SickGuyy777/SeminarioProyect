using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTuto : MonoBehaviour
{
    public GameObject objetoParaMover,ButtonBackTuto;
    private int indiceActual = 15;
    public bool IniTuto=false;
    public List<GameObject> Texto;
    void Start()
    {
        ActualizarIndiceEnJerarquia();
    }

    void Update()
    {
        if(IniTuto)
        {
            if (Input.GetMouseButtonDown(0))
            {
                indiceActual--;
                //indiceActual %= transformsExplTuto.Count;
                ActualizarIndiceEnJerarquia();
                ActualizarTexto();
            }
            if (indiceActual == 0)
            {
                ButtonBackTuto.SetActive(true);
            }
            else
            {
                ButtonBackTuto.SetActive(false);
            }
        }

    }
    void ActualizarTexto()
    {
        // Desactivar todos los elementos en la lista
        foreach (GameObject texto in Texto)
        {
            texto.SetActive(false);
        }

        // Activar el elemento correspondiente al índice actual
        if (indiceActual >= 0 && indiceActual < Texto.Count)
        {
            Texto[indiceActual].SetActive(true);
        }
    }
    public void IniciarTuto()
    {
        IniTuto = true;
    }
    void ActualizarIndiceEnJerarquia()
    {
        if (objetoParaMover != null)
        {
            indiceActual = Mathf.Max(indiceActual, 0);
            objetoParaMover.transform.SetSiblingIndex(indiceActual);
        }
    }
    public void FinalTuto()
    {
        objetoParaMover.SetActive(false);
        IniTuto = false;
        indiceActual = 15;
        ActualizarIndiceEnJerarquia();
    }
}
