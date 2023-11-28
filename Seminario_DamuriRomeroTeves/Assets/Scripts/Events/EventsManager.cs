using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EventsManager : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;
    [SerializeField] protected GameObject _mafiaBoss;
    [SerializeField] protected GameObject _police;
    [SerializeField] protected GameObject _politic;
    [SerializeField] protected GameObject _surpriseEvent;


    private void Start()
    {
        _mafiaBoss.SetActive(false);
    }


    private void Update()
    {
        if (_timeSys.currentDay == 31) SceneManager.LoadScene("ThanksForPlaying");
        SpawnBoss();
        SpawnPolice();
        SurpriseEvent();
        PoliticDealEv();
    }

    void SpawnBoss()
    {
        if (_timeSys.currentDayOfWeek == "Monday" && _timeSys.currentHour >= 19 && _timeSys.currentHour <= 21)
            _mafiaBoss.SetActive(true);
        else _mafiaBoss.SetActive(false);
    }

    void SpawnPolice()
    {
        if (_timeSys.currentDayOfWeek == "Tuesday" && _timeSys.currentHour >= 14 && _timeSys.currentHour <= 16)
            _police.SetActive(true);
        else _police.SetActive(false);
    }

    void PoliticDealEv()
    {
        if (_timeSys.currentDayOfWeek == "Thursday" && _timeSys.currentHour >= 10 && _timeSys.currentHour <= 13)
            _politic.SetActive(true);
        else _politic.SetActive(false);
    }

    void SurpriseEvent()
    {
        if (_timeSys.currentDayOfWeek == "Wednesday" && _timeSys.currentHour == 12 && _timeSys.CurrentMinutes == 0)
            _surpriseEvent.SetActive(true);
    }
}


