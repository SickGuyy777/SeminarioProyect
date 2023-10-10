using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police3Event : MonoBehaviour
{
    [SerializeField] protected TimeSystem _timeSys;

    [Header("Police Events")]
    [SerializeField] GameObject police;
    [SerializeField] GameObject initialSPPolice;
    [SerializeField] GameObject policeEventSP3;
    public bool policeEvent3;


    private void Start()
    {
        police.gameObject.SetActive(false);
    }

    void Update()
    {
        PoliceEvent3();
    }

    public void PoliceEvent3()
    {
        if (_timeSys.currentDayOfWeek == "Thursday" && _timeSys.currentHour >= 17 && _timeSys.currentHour <= 19)
            police.gameObject.SetActive(true);
        else if (_timeSys.currentHour >= 20 && policeEvent3 == true)
        {
            police.transform.position = policeEventSP3.transform.position;
            police.gameObject.SetActive(true);
        }
        else if (/*_timeSys.currentHour == 0*/ _timeSys.currentDayOfWeek != "Thursday")
        {
            police.transform.position = initialSPPolice.transform.position;
            policeEvent3 = false;
            police.gameObject.SetActive(false);
        }
        else
            police.gameObject.SetActive(false);
    }
}
