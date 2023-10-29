using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police1Event : MonoBehaviour
{
     public TimeSystem timeSys;

     public delegate void PoliceEvent();
     public Dictionary<string, PoliceEvent> events;


    private void Awake()
    {
        Debug.Log("Evento policia");
    }

    //Comente esto para testar y ver si funcionan algunas cosas mas facil
    /*void StartEvent()
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
    }*/
}
