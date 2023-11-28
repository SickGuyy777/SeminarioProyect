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
    public float currentVeg;
    public float currentLobster;
    public float currentMeat;
    public float currentMoney = 10000;
    public float currentRelMafia;
    public float currentRelCops;
    public List<GameObject> ObjDecoration;
    public List<GameObject> ButtomEquip;
    public List<GameObject> Langosta;
    public List<GameObject> Carne;
    public List<GameObject> Vegetales;
    public TMP_Text alcSuplies;
    public TMP_Text meatSuplies;
    public TMP_Text lobsterSuplies;
    public TMP_Text vegSuplies;
    public TMP_Text tobSuplies;
    public TMP_Text[] moneyCoutn;
    public LightManager timesys;
    [SerializeField] Image _mafiaFill, _copsFill;
    float _maxAlcohol = 1000;
    float _maxMeat = 1000;
    float _maxVeg = 1000;
    float _maxTobacco = 1000;
    float _maxLobstare = 300;
    float _maxRelMafia = 100;
    float _maxRelCops = 100;
    int cantidadDeCarne=-1;
    int cantidadDeLangosta=-1;
    int cantidadDeVegetales=-1;
    [Header("UI")]
    public TMP_Text lastEarnings;

    private void Start()
    {
        currentAlcohol = _maxAlcohol / 2;
        currentTobacco = _maxTobacco / 2;
        currentMeat = _maxMeat / 2;
        currentVeg = _maxVeg / 2;
        currentLobster = 100;
        currentRelCops = _maxRelCops / 2;
        currentRelMafia = _maxRelMafia / 2;
    }

    private void Update()
    {
        currentAlcohol -= 0.25f * Time.deltaTime;
        alcSuplies.text = currentAlcohol.ToString("0") + "/" + _maxAlcohol.ToString("0") + " Liters";
        currentTobacco -= 0.25f * Time.deltaTime;
        tobSuplies.text = currentTobacco.ToString("0") + "/" + _maxTobacco.ToString("0") + " Units";
        currentMeat -= 0.25f * Time.deltaTime;
        //langosta
        lobsterSuplies.text = currentLobster.ToString("0") + "/" + _maxLobstare.ToString("0") + " Units";
        currentLobster -= 0.25f * Time.deltaTime;
        //hasta aca
        meatSuplies.text = currentMeat.ToString("0") + "/" + _maxMeat.ToString("0") + " Kilos";
        currentVeg -= 0.25f * Time.deltaTime;
        vegSuplies.text = currentVeg.ToString("0") + "/" + _maxVeg.ToString("0") + " Kilos";
        moneyCoutn[0].text = "Money: " + currentMoney.ToString("0");
        moneyCoutn[1].text = currentMoney.ToString("0");
        if (currentTobacco >= _maxTobacco) currentTobacco = _maxTobacco;
        if (currentAlcohol >= _maxAlcohol) currentAlcohol = _maxAlcohol;
        if (currentVeg >= _maxVeg) currentVeg = _maxVeg;
        if (currentMeat >= _maxMeat) currentMeat = _maxMeat;

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
    public void BuyMeat()
    {
       if (currentMoney >= 750 && currentMeat < _maxMeat - 1)
       {
            currentMeat += 100;
            currentMoney -= 750;
            cantidadDeCarne++;
            if (cantidadDeCarne < Carne.Count)
            {
                Carne[cantidadDeCarne].SetActive(true);
            }
        }
    }
    public void BuyVeg()
    {
        if (currentMoney >= 500 && currentVeg < _maxVeg - 1)
        {
            currentVeg += 100;
            if (currentVeg > _maxVeg)
            {
                currentVeg = _maxVeg;
            }
            currentMoney -= 500;
            cantidadDeVegetales++;
            if (cantidadDeVegetales < Vegetales.Count)
            {
                Vegetales[cantidadDeVegetales].SetActive(true);
            }
        }
    }
    public void BuyLobster()
    {
        if (currentMoney >= 900 && currentLobster < _maxLobstare - 1)
        {
            currentLobster += 25;
            if(currentLobster>_maxLobstare)
            {
                currentLobster = _maxLobstare;
            }
            currentMoney -= 900;
            cantidadDeLangosta++;
            if (cantidadDeLangosta < Langosta.Count)
            {
                Langosta[cantidadDeLangosta].SetActive(true);
            }
        }
    }

    #region VisualShoop
    public void BuyRockola()
    {
        if(currentMoney>=100)
        {
            currentMoney -= 100;
            ButtomEquip[0].SetActive(true);
        }
    }
    public void BuyEscenario()
    {
        if (currentMoney >= 150)
        {
            currentMoney -= 150;
            ButtomEquip[1].SetActive(true);
        }
    }
    public void EquipRockola()
    {
        ObjDecoration[0].SetActive(true);
        ObjDecoration[1].SetActive(false);
    }
    public void EquipEscenario()
    {
        ObjDecoration[0].SetActive(false);
        ObjDecoration[1].SetActive(true);
    }
    #endregion
}
