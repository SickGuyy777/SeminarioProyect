using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DS_Mafia2 : DialoguesSystem
{
    [SerializeField] bool _noMoreText;
    public string[] decisionLines;
    public GameObject[] buttons;
    public GameObject Mafia;
    public InteractionSystem interactSys;
    public GameObject mafia;
    public GameObject HasObj;
    public GameObject NotHasObj;
    public PickUpObject PickUpObj;

    int _decisionIndex;

    private void Start()
    {
        DeactivateButtons(false);
    }

    private void Update()
    {
        //if (_noMoreText == false)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        if (textComp.text == lines[_index])
        //            NextLine();
        //        else
        //        {
        //            StopAllCoroutines();
        //            textComp.text = lines[_index];
        //        }
        //    }

        //    if (_index == lines.Length - 1) DeactivateButtons(true);
        //    else DeactivateButtons(false);
        //}
        HasObject();

    }

    public void Accept()
    {
        //passText.text = "ESC TO EXIT>>>";
        //DeactivateButtons(false);
        //_noMoreText = true;
        //_decisionIndex = 0;
        //textComp.text = decisionLines[_decisionIndex];

       // mafia.SetActive(false);
        interactSys.CloseUI();
        gameObject.SetActive(false);
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

    public void HasObject()
    {
        if (PickUpObj.hasObject)
        {
            Debug.Log("prendo la UI q le dice q muy bien");
            HasObj.SetActive(true);
        }
        else
        {
            NotHasObj.SetActive(true);

            Debug.Log("prendo la UI q le dice q traiga el cuchillo");
        }
    }

}
