using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police1Event : MonoBehaviour
{
    //[SerializeField] protected TimeSystem _timeSys;

    //[Header("Police Events")]
    //[SerializeField] GameObject police;
    //[SerializeField] GameObject initialSPPolice;
    //[SerializeField] GameObject policeEventSP1;
    //public bool policeEvent1;


    //private void Start()
    //{
    //    police.SetActive(false);
    //}

    //void Update()
    //{
    //    PoliceEvent1();
    //}
    //public void PoliceEvent1()
    //{
    //    if (_timeSys.currentDayOfWeek == "Sunday" && _timeSys.currentHour >= 18 && _timeSys.currentHour <= 20)
    //    {
    //        police.SetActive(true);
    //    }
    //    else if (_timeSys.currentHour >= 21 && policeEvent1 == true)
    //    {
    //        police.transform.position = policeEventSP1.transform.position;
    //        police.SetActive(true);
    //    }
    //    else if (/*_timeSys.currentHour == 0*/ _timeSys.currentDayOfWeek != "Sunday")
    //    {
    //        police.transform.position = initialSPPolice.transform.position;
    //        policeEvent1 = false;
    //        police.SetActive(false);
    //    }
    //    else
    //        police.SetActive(false);
    //}


    public TimeSystem timeSys;

    public delegate void PoliceEvent();
    public Dictionary<string, PoliceEvent> events;


    void StartEvent()
    {
        if (events.TryGetValue(timeSys.currentDayOfWeek, out PoliceEvent policeEvent))
        {
            policeEvent?.Invoke();
        }
    }
    private void Start()
    {
        events = new Dictionary<string, PoliceEvent>
        {
            {"Tuesday", TuesdayEvent },
            {"Saturday", SaturdayEvent },
            {"Thursday", ThursdayEvent }
        };
    }


    void TuesdayEvent()
    {
        Debug.Log("Hago el evento del martes");
    }

    void SaturdayEvent()
    {
        Debug.Log("Hago el evento del sabado");
    }

    void ThursdayEvent()
    {
        Debug.Log("Hago el evento del jueves");
    }


    private void OnEnable()
    {
        DecisionDialogue.OnDecisionMade += StartEvent;
    }

    private void OnDisable()
    {
        DecisionDialogue.OnDecisionMade -= StartEvent;
    }
}
