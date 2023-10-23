using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;
    [SerializeField] protected GameObject _mafiaBoss;
    [SerializeField] protected GameObject _police;


    private void Start()
    {
        _mafiaBoss.SetActive(false);
    }


    private void Update()
    {
        SpawnBoss();
        SpawnPolice();
    }

    void SpawnBoss()
    {
        if (_timeSys.currentDayOfWeek == "Friday" && _timeSys.currentHour >= 17 && _timeSys.currentHour <= 19)
            _mafiaBoss.SetActive(true);
        else if (_timeSys.currentDayOfWeek == "Monday" && _timeSys.currentHour >= 19 && _timeSys.currentHour <= 21)
            _mafiaBoss.SetActive(true);
        else if (_timeSys.currentDayOfWeek == "Wednesday" && _timeSys.currentHour >= 21 && _timeSys.currentHour <= 23)
            _mafiaBoss.SetActive(true);
        else _mafiaBoss.SetActive(false);
    }

    void SpawnPolice()
    {
        if (_timeSys.currentDayOfWeek == "Tuesday" && _timeSys.currentHour >= 14 && _timeSys.currentHour <= 16)
            _police.SetActive(true);
        else if (_timeSys.currentDayOfWeek == "Saturday" && _timeSys.currentHour >= 19 && _timeSys.currentHour <= 21)
            _police.SetActive(true);
        else if (_timeSys.currentDayOfWeek == "Thursday" && _timeSys.currentHour >= 17 && _timeSys.currentHour <= 19)
            _police.SetActive(true);
        else _police.SetActive(false);
    }
}


