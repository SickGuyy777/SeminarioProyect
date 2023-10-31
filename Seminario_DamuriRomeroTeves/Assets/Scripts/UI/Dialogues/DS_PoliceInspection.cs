using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DS_PoliceInspection : MonoBehaviour
{
    public string[] firstLines;
    public string[] firstTellTheTruth;
    public string[] firstLie, secondLie, goodFood, noRespond;
    public TextMeshProUGUI textComp;
    [SerializeField] InteractionSystem _intSys;
    [SerializeField] ResourserManagment _resourser;
    [SerializeField] GameObject[] _firstOpButtons, _secondOpButtons;
    [SerializeField] GameObject _police;
    bool _tellTheFirstTruth, _firstLie, _secondLie, _goodFood, _noRespond;
    int _textIndex;

    private void Start()
    {
        ResetIndex();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_tellTheFirstTruth == true)
            {
                TellTheTruth();
                if(_textIndex == firstTellTheTruth.Length)
                {
                    _resourser.currentMoney -= 1000;
                    _resourser.currentRelCops += 10;
                    _intSys.CloseUI();
                    this.gameObject.SetActive(false);
                }
            }
            else if(_firstLie == true)
            {
                Lie();
                if (_textIndex == firstLie.Length)
                {
                    foreach (var button in _secondOpButtons)
                        button.SetActive(true);
                    _firstLie = false;
                }
            }
            else if(_secondLie == true)
            {
                SorryILied();
                if (_textIndex == secondLie.Length)
                {
                    _resourser.currentMoney -= 2000;
                    _resourser.currentRelCops -= 10;
                    _intSys.CloseUI();
                    this.gameObject.SetActive(false);
                }
            }
            else if(_goodFood == true)
            {
                GoodFood();
                if (_textIndex == goodFood.Length)
                {
                    _resourser.currentRelCops += 20;
                    _intSys.CloseUI();
                    this.gameObject.SetActive(false);
                }
            }
            else if(_noRespond == true)
            {
                DontRespond();
                if (_textIndex == noRespond.Length)
                {
                    _resourser.currentRelCops -= 20;
                    _intSys.CloseUI();
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                Talk();
                if(_textIndex == firstLines.Length)
                {
                    foreach (var button in _firstOpButtons)
                        button.SetActive(true);
                }
            }
        }
        
    }

    public void Talk()
    {
        if (_textIndex > firstLines.Length)
        {
            _textIndex = firstLines.Length;
        }
        textComp.text = firstLines[_textIndex];
        _textIndex++;
    }

    public void ResetIndex()
    {
        foreach (var button in _firstOpButtons)
            button.SetActive(false);
        foreach (var button in _secondOpButtons)
            button.SetActive(false);
        _textIndex = 0;
    }

    public void TellTheTruth()
    {
        Debug.Log("Dijo la verdad");
        _tellTheFirstTruth = true;
        textComp.text = firstTellTheTruth[_textIndex];
        _textIndex++;
    }

    public void Lie()
    {
        Debug.Log("Menti");
        _firstLie = true;
        textComp.text = firstLie[_textIndex];
        _textIndex++;
    }

    public void SorryILied()
    {
        _secondLie = true;
        textComp.text = secondLie[_textIndex];
        _textIndex++;
    }

    public void DontRespond()
    {
        _noRespond = true;
        textComp.text = noRespond[_textIndex];
        _textIndex++;
    }

    public void GoodFood()
    {
        _goodFood = true;
        textComp.text = goodFood[_textIndex];
        _textIndex++;
    }
}
