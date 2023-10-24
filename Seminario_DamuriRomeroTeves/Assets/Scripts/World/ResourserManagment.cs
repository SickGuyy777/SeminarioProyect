using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourserManagment : MonoBehaviour
{
    [Header("BAR")]
    public float currentAlcohol;
    public float currentTobacco;
    public float currentMoney = 10000;
    public float currentRelMafia;
    public float currentRelCops;
    public TMP_Text alcSuplies;
    public TMP_Text tobSuplies;
    public TMP_Text[] moneyCoutn;
    [SerializeField] Image _mafiaFill, _copsFill;

    float _maxAlcohol = 1000;
    float _maxTobacco = 1000;
    float _maxRelMafia = 100;
    float _maxRelCops = 100;

    private void Start()
    {
        currentAlcohol = _maxAlcohol / 2;
        currentTobacco = _maxTobacco / 2;

        currentRelCops = _maxRelCops;
        currentRelMafia = _maxRelMafia;
    }

    private void Update()
    {
        currentAlcohol -= 0.25f * Time.deltaTime;
        alcSuplies.text = currentAlcohol.ToString("0") + "/" + _maxAlcohol.ToString("0") + " Liters";
        currentTobacco -= 0.25f * Time.deltaTime;
        tobSuplies.text = currentTobacco.ToString("0") + "/" + _maxTobacco.ToString("0") + " Kilos";
        currentMoney += Random.Range(5f, 10f) * Time.deltaTime;
        moneyCoutn[0].text = "Money: " + currentMoney.ToString("0");
        moneyCoutn[1].text = /*"Money: " +*/ currentMoney.ToString("0");
        if (currentTobacco >= _maxTobacco) currentTobacco = _maxTobacco;
        if (currentAlcohol >= _maxAlcohol) currentAlcohol = _maxAlcohol;

        _mafiaFill.fillAmount = currentRelMafia / _maxRelMafia;
        _copsFill.fillAmount = currentRelCops / _maxRelCops;
    }

    public void BuyAlcohol()
    {
        if (currentMoney >= 2000 && currentAlcohol < _maxAlcohol - 1)
        {
            currentAlcohol += 100;
            currentMoney -= 2000;
        }
    }

    public void BuyTobacco()
    {
        if (currentMoney >= 1000 && currentTobacco < _maxTobacco - 1)
        {
                currentTobacco += 100;
                currentMoney -= 1000;
        }
    }
}
