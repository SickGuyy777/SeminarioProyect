using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicButtons : MonoBehaviour
{
    public GameObject[] objDes;
    public void DesactiveObj()
    {
        for (int i = 0; i < objDes.Length; i++)
        {
            objDes[i].SetActive(false);
        }
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
