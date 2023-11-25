using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SurpriseVisit : MonoBehaviour
{
    public List<GameObject> interactuableObjs = new List<GameObject>();
    public List<GameObject> naturalObjs = new List<GameObject>();
    [SerializeField] TimeSystem _timeSys;
    [SerializeField] TMP_Text _timerText;
    [SerializeField] TMP_Text _msgText;
    [SerializeField] Image _imageCount, _msgImage;
    public GameObject policeObj;

    [HideInInspector] public bool pickedUp, finishEvent;
    [HideInInspector] public int cantPick;

    float _min, _sec;
    bool _timeZero = false;

    private void Awake()
    {
        _timeZero = true;   
        _min = 1f;
        _sec = 10f;
        _msgImage.gameObject.SetActive(true);
        _imageCount.gameObject.SetActive(true);
        foreach (var item in interactuableObjs)
            item.gameObject.SetActive(true);
        foreach (var item in naturalObjs)
            item.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (finishEvent == true) this.gameObject.SetActive(false);
        if (_timeZero) Time.timeScale = 0;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _timeZero = false;
            _timeSys.isTimeXTwo = false;
            _msgImage.gameObject.SetActive(false);
        }

        Timer();
        _timerText.text = _min.ToString("00") + ":" + _sec.ToString("00");
        if (cantPick == 3) _msgText.text = "Well done, you hid everything";
    }

    void Timer()
    {
        if (_sec <= 0 && _min <= 0)
        {
            //TIME OVER
            policeObj.SetActive(true);
            _imageCount.gameObject.SetActive(false);
        }

        else if (_sec <= 0)
        {
            _sec = 59;
            _min -= 1;
        }
        else _sec -= 1 * Time.deltaTime;
    }
}
