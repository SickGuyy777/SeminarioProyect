using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourserManagment : MonoBehaviour
{
    [Header("BAR")]
    [SerializeField] static float _currentAlcohol;
    [SerializeField] static float _currentTobacco;
    public TMP_Text alcSuplies;
    public TMP_Text tobSuplies;

    float _maxAlcohol = 1000;
    float _maxTobacco = 1000;

    private void Start()
    {
        _currentAlcohol = _maxAlcohol / 2;
        _currentTobacco = _maxTobacco / 2;
    }

    private void Update()
    {
        _currentAlcohol -= 0.25f * Time.deltaTime;
        alcSuplies.text = _currentAlcohol.ToString("0") + "/" + _maxAlcohol.ToString("0") + " Liters";
        _currentTobacco -= 0.25f * Time.deltaTime;
        tobSuplies.text = _currentTobacco.ToString("0") + "/" + _maxTobacco.ToString("0") + " Kilos";
    }
}
