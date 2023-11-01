using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia1Event : MonoBehaviour
{
    public TimeSystem timeSys;
    public Transform eventPosition;
    public GameObject dialogue;
    public InteractionSystem interactSys;

    public delegate void MafiaEvent();
    public Dictionary<string, MafiaEvent> events;


    void StartEvent()
    {
        if (events.TryGetValue(timeSys.currentDayOfWeek, out MafiaEvent mafiaEvent))
        {
            mafiaEvent?.Invoke();
        }
    }
    private void Start()
    {
        events = new Dictionary<string, MafiaEvent>
        {
            {"Friday", FridayEvent },
            {"Monday", MondayEvent },
            {"Wednesday", WednesdayEvent }
        };
    }


    void FridayEvent()
    {
        Debug.Log("Hago el evento del viernes");
    }

    void MondayEvent()
    {
        Debug.Log("Hago el evento del lunes");

        transform.position = eventPosition.position;
        dialogue.SetActive(true);
        interactSys.enabled = false;

    }

    void WednesdayEvent()
    {
        Debug.Log("Hago el evento del miercoles");
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
