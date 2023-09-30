using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionDialogue: DialoguesSystem
{
    [SerializeField] bool _noMoreText;
    public string[] decisionLines;
    public GameObject[] buttons;
    public EventsManager eventManager;

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

    public void Help()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        eventManager.tortureEvent = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];
    }

    public void NotHelp()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        eventManager.tortureEvent = false;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }

    void DeactivateButtons (bool truefalse)
    {
        foreach (var button in buttons)
            button.SetActive(truefalse);
    }
}
