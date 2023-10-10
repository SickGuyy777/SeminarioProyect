using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionDialogue: DialoguesSystem
{
    [SerializeField] bool _noMoreText;
    public string[] decisionLines;
    public GameObject[] buttons;
    //public EventsManager eventManager;
    public Police1Event police1;
    public Police2Event police2;
    public Police3Event police3;
    public Mafia1Event mafia1;
    public Mafia2Event mafia2;
    public Mafia3Event mafia3;

    int _decisionIndex;

    private void Start()
    {
        _noMoreText = false;
        textComp.text = string.Empty;
        StartDialogue();

        foreach (var button in buttons)
            button.SetActive(false);
    }

    private void Update()
    {
        if (_noMoreText == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComp.text == lines[_index])
                    NextLine();
                else
                {
                    StopAllCoroutines();
                    textComp.text = lines[_index];
                }
            }

            if (_index == lines.Length - 1) DeactivateButtons(true);
            else DeactivateButtons(false);
        }
    }

    public void HelpMafia1()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        mafia1.tortureEvent1 = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];
    }
    public void HelpMafia2()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        mafia2.tortureEvent2 = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];
    } 
    
    public void HelpMafia3()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        mafia3.tortureEvent3 = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];
    }
    

    public void NotHelpMafia1()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        mafia1.tortureEvent1 = false;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }
    
    public void NotHelpMafia2()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        mafia2.tortureEvent2 = false;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }
    
    public void NotHelpMafia3()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        mafia3.tortureEvent3 = false;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }
    
    public void HelpPolice1()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        police1.policeEvent1 = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex]; 
    }

    public void HelpPolice2()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        police2.policeEvent2 = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];
    }

    public void HelpPolice3()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        police3.policeEvent3 = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];
    }

    public void NotHelpPolice1()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        police1.policeEvent1 = false;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }

    public void NotHelpPolice2()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        police2.policeEvent2 = false;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }

    public void NotHelpPolice3()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        police3.policeEvent3 = false;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }

    void DeactivateButtons (bool truefalse)
    {
        foreach (var button in buttons)
            button.SetActive(truefalse);
    }
}
