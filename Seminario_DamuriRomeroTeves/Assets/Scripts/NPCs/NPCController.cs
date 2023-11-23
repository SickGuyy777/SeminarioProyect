using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] ResourserManagment _manager;
    [SerializeField] NPCsManager _npcManager;
    float _timer;
    float _maxtimer;

    private void Awake()
    {
        _maxtimer = Random.Range(60, 60 * 4);
        _timer = _maxtimer;
    }

    private void Update()
    {
        _timer -= 1 * Time.deltaTime;
        if(_timer <= 0)
        {
            int earning = Random.Range(15, 201);
            _manager.currentMoney += earning;
            _manager.lastEarnings.text += "\n" + "+" + earning.ToString() + "$";
            this.gameObject.SetActive(false);
            _npcManager.npcList.Add(this);
            _timer = _maxtimer;
        }        
    }
}
