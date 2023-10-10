using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia3Event : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;

    [Header("Mafia Events")]
    [SerializeField] GameObject _mafiaBoss;
    [SerializeField] GameObject _tortureSpawnPoint;
    [SerializeField] GameObject initialSpawnPoint;
    public bool tortureEvent3;

    private void Start()
    {
        _mafiaBoss.gameObject.SetActive(false);
    }

    void Update()
    {
        MafiaEvent3();
    }


    public void MafiaEvent3()
    {
        if (_timeSys.currentDayOfWeek == "Saturday" && _timeSys.currentHour >= 18 && _timeSys.currentHour <= 20)
            _mafiaBoss.gameObject.SetActive(true);
        else if (_timeSys.currentHour >= 22 && tortureEvent3 == true)
        {
            _mafiaBoss.transform.position = _tortureSpawnPoint.transform.position;
            _mafiaBoss.gameObject.SetActive(true);
        }
        else if (/*_timeSys.currentHour == 0*/ _timeSys.currentDayOfWeek != "Saturday")
        {
            _mafiaBoss.transform.position = initialSpawnPoint.transform.position;
            tortureEvent3 = false;
            _mafiaBoss.gameObject.SetActive(false);
        }
        else
            _mafiaBoss.gameObject.SetActive(false);
    }
}
