using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DS_Mafia1 : DialoguesSystem
{
    [SerializeField] bool _noMoreText;
    public string[] decisionLines;
    public GameObject[] buttons;
    public GameObject Mafia;
    public InteractionSystem interactSys;
    public GameObject DialogueAcept;
    public GameObject Dialogue;
    public GameObject UI;


    int _decisionIndex;

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

    public void Accept()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];

        DialogueAcept.SetActive(true);
        Dialogue.SetActive(false);

        gameObject.SetActive(false);
        UI.SetActive(true); 
    }
    public void Deny()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];

        interactSys.CloseUI();
        Mafia.SetActive(false);
        UI.SetActive(true); 

    }


    void DeactivateButtons(bool truefalse)
    {
        foreach (var button in buttons)
            button.SetActive(truefalse);
    }

    public void Activate()
    {
        _noMoreText = false;
        textComp.text = string.Empty;
        //StartDialogue();

        foreach (var button in buttons)
            button.SetActive(false);
    }

}
