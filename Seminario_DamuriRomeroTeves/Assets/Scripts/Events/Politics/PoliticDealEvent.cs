using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoliticDealEvent : MonoBehaviour
{
    [SerializeField] string[] _textLines, _acceptDealLines, _denyDealLines;
    [SerializeField] GameObject[] _buttonsObj;
    [SerializeField] TMP_Text _text;
    [SerializeField] ResourserManagment _manager;
    [SerializeField] GameObject _gameplayUI;
    [SerializeField] GameObject _politicPrefab;

    bool _acceptDeal, _denyDeal, _finishText;
    int _index;

    private void Awake()
    {
        _acceptDeal = false;
        _denyDeal = false;
        _finishText = false;
        _index = 0;
        _text.text = _textLines[_index];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _finishText == false)
        {
            if (_acceptDeal == false && _denyDeal == false)
            {
                _index++;
                _text.text = _textLines[_index];

                if (_index >= _textLines.Length - 1)
                {
                    foreach (var button in _buttonsObj)
                        button.SetActive(true);
                }
            }
            else if (_acceptDeal == true && _denyDeal == false)
            {
                _index++;
                _text.text = _acceptDealLines[_index];
                if (_index >= _acceptDealLines.Length - 1) _finishText = true;
            }
            else
            {
                _index++;
                _text.text = _denyDealLines[_index];
                if (_index >= _denyDealLines.Length - 1) _finishText = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && _finishText == true)
        {
            _gameplayUI.SetActive(true);
            _politicPrefab.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    public void AcceptDealLines()
    {
        _index = 0;
        _text.text = _acceptDealLines[0];
        _acceptDeal = true;
        foreach (var button in _buttonsObj)
            button.SetActive(false);
        _manager.currentMoney -= 1500;
        _manager.currentRelCops += 30;
    }

    public void DenyDealLines()
    {
        _index = 0;
        _text.text = _denyDealLines[0];
        _denyDeal = true;
        foreach (var button in _buttonsObj)
            button.SetActive(false);
        _manager.currentRelCops -= 25;
    }
}
