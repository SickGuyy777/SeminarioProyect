using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia2Event : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;

    [Header("Mafia Events")]
    [SerializeField] GameObject _mafiaBoss;
    [SerializeField] GameObject _tortureSpawnPoint;
    [SerializeField] GameObject initialSpawnPoint;
    public bool tortureEvent2;

    private void Start()
    {
        _mafiaBoss.gameObject.SetActive(false);
    }

    void Update()
    {
        MafiaEvent2();
    }


    public void MafiaEvent2()
    {
        if (_timeSys.currentDayOfWeek == "Monday" && _timeSys.currentHour >= 18 && _timeSys.currentHour <= 19)
            _mafiaBoss.gameObject.SetActive(true);
        else if (_timeSys.currentHour >= 20 && tortureEvent2 == true)
        {
            _mafiaBoss.transform.position = _tortureSpawnPoint.transform.position;
            _mafiaBoss.gameObject.SetActive(true);
        }
        else if (/*_timeSys.currentHour == 0*/ _timeSys.currentDayOfWeek != "Monday")
        {
            _mafiaBoss.transform.position = initialSpawnPoint.transform.position;
            tortureEvent2 = false;
            _mafiaBoss.gameObject.SetActive(false);
        }
        else
            _mafiaBoss.gameObject.SetActive(false);
    }
}
