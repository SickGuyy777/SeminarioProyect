using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Torture : MonoBehaviour
{
    [SerializeField] TimeSystem _timeSys;
    [SerializeField] GameObject _mafiaBoss;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Event();
    }

    void Event()
    {
        if (_timeSys.currentHour >= 15 && _timeSys.currentHour <= 19)
            _mafiaBoss.SetActive(true);
        else
            _mafiaBoss.SetActive(false);
    }
}
