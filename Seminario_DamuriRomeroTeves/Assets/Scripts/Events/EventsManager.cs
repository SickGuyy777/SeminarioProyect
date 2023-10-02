using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;
    [SerializeField] GameObject _mafiaBoss;
    [SerializeField] GameObject _tortureSpawnPoint;
    [SerializeField] GameObject initialSpawnPoint;

    public bool tortureEvent;

    private void Start()
    {
        _mafiaBoss.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_timeSys.currentHour >= 15 && _timeSys.currentHour <= 19)
            _mafiaBoss.SetActive(true);
        else if (_timeSys.currentHour >= 22 && tortureEvent == true)
        {
            _mafiaBoss.transform.position = _tortureSpawnPoint.transform.position;
            _mafiaBoss.SetActive(true);
        }
        else if(_timeSys.currentHour == 0)
        {
            _mafiaBoss.transform.position = initialSpawnPoint.transform.position;
            tortureEvent = false;
            _mafiaBoss.SetActive(false);
        }
        else
            _mafiaBoss.SetActive(false);
    }

}
