using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionDialogue: DialoguesSystem, IScreen
{
    [SerializeField] bool _noMoreText;
    public string[] decisionLines;
    public GameObject[] buttons;
    public InteractionSystem interactSys;
    public Animator animboss;
    int _decisionIndex;
    bool _hasTalkMafia;


    public delegate void DecisionMade();
    public static event DecisionMade OnDecisionMade;

    private void Start()
    {
        
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
    public void Animcambio()
    {
        animboss.SetBool("up", true);
    }
    public void HelpMafia1()
    {
        if (_hasTalkMafia == true) return;


        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];
        _hasTalkMafia = true;

        interactSys.CloseUI();

        OnDecisionMade?.Invoke();
    }
    public void NotHelpMafia1()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }
    
    
    public void HelpPolice1()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        _decisionIndex = 0;
        textComp.text = decisionLines[_decisionIndex];

        OnDecisionMade?.Invoke();
    }


    public void NotHelpPolice1()
    {
        passText.text = "ESC TO EXIT>>>";
        DeactivateButtons(false);
        _noMoreText = true;
        _decisionIndex = 1;
        textComp.text = decisionLines[_decisionIndex];
    }

    void DeactivateButtons (bool truefalse)
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

    public void Free()
    {
        Destroy(gameObject);
    }

    public void Desactivate()
    {
        
    }
}
