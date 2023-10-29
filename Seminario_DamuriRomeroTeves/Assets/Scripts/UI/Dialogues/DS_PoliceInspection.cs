using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DS_PoliceInspection : MonoBehaviour
{
    public string[] firstLines;
    public TextMeshProUGUI textComp;
    [SerializeField] InteractionSystem _intSys;
    bool _noMoreText;
    int _textIndex;

    private void Update()
    {
        if(_noMoreText == false)
        {
            textComp.text = firstLines[_textIndex];
            if (Input.GetMouseButtonDown(0))
            {
                if (_textIndex == firstLines.Length - 1)
                {
                    _intSys.CloseUI();
                    _textIndex = 0;
                }
                else _textIndex++;
            }
        }
    }
}
