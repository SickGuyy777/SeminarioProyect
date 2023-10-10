using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia1Event : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;

    [Header("Mafia Events")]
    [SerializeField] GameObject _mafiaBoss;
    [SerializeField] GameObject _tortureSpawnPoint;
    [SerializeField] GameObject initialSpawnPoint;
    public bool tortureEvent1;

    private void Start()
    {
        _mafiaBoss.gameObject.SetActive(false);
    }

    void Update()
    {
        MafiaEvent1();
    }


    public void MafiaEvent1()
    {
        if (_timeSys.currentDayOfWeek == "Friday" && _timeSys.currentHour >= 15 && _timeSys.currentHour <= 19)
            _mafiaBoss.gameObject.SetActive(true);
        else if (_timeSys.currentHour >= 22 && tortureEvent1 == true)
        {
            _mafiaBoss.transform.position = _tortureSpawnPoint.transform.position;
            _mafiaBoss.gameObject.SetActive(true);
        }
        else if (/*_timeSys.currentHour == 0*/ _timeSys.currentDayOfWeek != "Friday")
        {
            _mafiaBoss.transform.position = initialSpawnPoint.transform.position;
            tortureEvent1 = false;
            _mafiaBoss.gameObject.SetActive(false);
        }
        else
            _mafiaBoss.gameObject.SetActive(false);
    }
}
