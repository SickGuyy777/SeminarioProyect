using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;

    [Header("Mafia Events")]
    [SerializeField] GameObject _mafiaBoss;
    [SerializeField] GameObject _tortureSpawnPoint;
    [SerializeField] GameObject initialSpawnPoint;
    public bool tortureEvent;

    [Header("Police Events")]
    [SerializeField] GameObject _police;
    [SerializeField] GameObject initialSPPolice;
    [SerializeField] GameObject policeEventSP1;
    [SerializeField] GameObject policeEventSP2;
    [SerializeField] GameObject policeEventSP3;
    public bool policeEvent;


    private void Start()
    {
        _mafiaBoss.gameObject.SetActive(false);
        _police.gameObject.SetActive(false);

    }

    void Update()
    {
        MafiaEvent1();
        PoliceEvent1();
        PoliceEvent2();
        PoliceEvent3();
    }


    public void MafiaEvent1()
    {
        if (_timeSys.currentDayOfWeek == "Friday" && _timeSys.currentHour >= 15 && _timeSys.currentHour <= 19)
            _mafiaBoss.SetActive(true);
        else if (_timeSys.currentHour >= 22 && tortureEvent == true)
        {
            _mafiaBoss.transform.position = _tortureSpawnPoint.transform.position;
            _mafiaBoss.SetActive(true);
        }
        else if (_timeSys.currentHour == 0)
        {
            _mafiaBoss.transform.position = initialSpawnPoint.transform.position;
            tortureEvent = false;
            _mafiaBoss.SetActive(false);
        }
        else
            _mafiaBoss.SetActive(false);
    }

    public void PoliceEvent1()
    {
        _police.SetActive(true);
        if (_timeSys.currentHour >= 21 && policeEvent == true)
        {
            _police.transform.position = policeEventSP1.transform.position;
            _police.SetActive(true);
        }
        else if (_timeSys.currentHour == 0)
        {
            _police.transform.position = initialSPPolice.transform.position;
            policeEvent = false;
            _police.SetActive(false);
        }
        else
            _police.SetActive(false);
    }

    public void PoliceEvent2()
    {
        if (_timeSys.currentDayOfWeek == "Tuesday" && _timeSys.currentHour >= 15 && _timeSys.currentHour <= 18)
            _police.SetActive(true);
        else if (_timeSys.currentHour >= 19 && policeEvent == true)
        {
            _police.transform.position = policeEventSP2.transform.position;
            _police.SetActive(true);
        }
        else if (_timeSys.currentHour == 0)
        {
            _police.transform.position = initialSPPolice.transform.position;
            policeEvent = false;
            _police.SetActive(false);
        }
        else
            _police.SetActive(false);
    }

    public void PoliceEvent3()
    {
        if (_timeSys.currentDayOfWeek == "Thursday" && _timeSys.currentHour >= 17 && _timeSys.currentHour <= 19)
            _police.SetActive(true);
        else if (_timeSys.currentHour >= 20 && policeEvent == true)
        {
            _police.transform.position = policeEventSP2.transform.position;
            _police.SetActive(true);
        }
        else if (_timeSys.currentHour == 0)
        {
            _police.transform.position = initialSPPolice.transform.position;
            policeEvent = false;
            _police.SetActive(false);
        }
        else
            _police.SetActive(false);
    }
}


