using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoliceTalkUI : MonoBehaviour
{
    [SerializeField] SurpriseVisit _event;
    [SerializeField] ResourserManagment _manager;
    [SerializeField] GameObject _noAlcohol, _withAlcohol, _gameplayUI;
    [SerializeField] TMP_Text _bribeTxt, _threatenTxt, _blameTxt;

    public bool _finishTalk = false;

    private void Awake()
    {
        if (_event.cantPick == 3)
        {
            _noAlcohol.gameObject.SetActive(true);
            _finishTalk = true;
        }

        else _withAlcohol.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _finishTalk == true)
        {
            _event.policeObj.SetActive(false);
            _gameplayUI.SetActive(true);
            foreach (var item in _event.naturalObjs)
                item.gameObject.SetActive(true);
            _event.finishEvent = true;
            this.gameObject.SetActive(false);
        }
    }

    public void Threaten()
    {
        _withAlcohol.gameObject.SetActive(false);
        _threatenTxt.gameObject.SetActive(true);
        _manager.currentRelCops -= 20;
        _manager.currentRelMafia += 10;
        _finishTalk = true;
    }

    public void Bribe()
    {
        _withAlcohol.gameObject.SetActive(false);
        _bribeTxt.gameObject.SetActive(true);
        _manager.currentRelCops += 5;
        _manager.currentMoney -= 1000;
        _finishTalk = true;
    }

    public void BlameTheMafia()
    {
        _withAlcohol.gameObject.SetActive(false);
        _blameTxt.gameObject.SetActive(true);
        _manager.currentRelCops += 10;
        _manager.currentRelMafia -= 30;
        _finishTalk = true;

    }
}
