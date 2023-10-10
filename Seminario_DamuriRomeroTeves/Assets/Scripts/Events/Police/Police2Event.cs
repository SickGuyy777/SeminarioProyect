using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police2Event : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;

    [Header("Police Events")]
    [SerializeField] GameObject police;
    [SerializeField] GameObject initialSPPolice;
    [SerializeField] GameObject policeEventSP2;
    public bool policeEvent2;


    private void Start()
    {
        police.gameObject.SetActive(false);

    }

    void Update()
    {
        PoliceEvent2();
    }

    public void PoliceEvent2()
    {
        if (_timeSys.currentDayOfWeek == "Tuesday" && _timeSys.currentHour >= 15 && _timeSys.currentHour <= 18)
            police.gameObject.SetActive(true);
        else if (_timeSys.currentHour >= 19 && policeEvent2 == true)
        {
            police.transform.position = policeEventSP2.transform.position;
            police.gameObject.SetActive(true);
        }
        else if (/*_timeSys.currentHour == 0*/ _timeSys.currentDayOfWeek != "Tuesday")
        {
            police.transform.position = initialSPPolice.transform.position;
            policeEvent2 = false;
            police.gameObject.SetActive(false);
        }
        else
            police.gameObject.SetActive(false);
    }
}
