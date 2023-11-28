using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCsManager : MonoBehaviour
{
    public List<NPCController> npcList = new List<NPCController>();
    [SerializeField] NPCController[] _npcArray;
    [SerializeField] TimeSystem _timeSys;
    [SerializeField] float _startTimer;
    public GameObject objetoParaActivar;
    private bool objetoActivo = false;
    float _currentTimer;

    private void Start()
    {
        _currentTimer = Random.Range(_startTimer, _startTimer/2);
    }

    private void Update()
    {
        if (_timeSys.currentHour >= 7 && _timeSys.currentHour <= 22)
        {
            _currentTimer -= 1 * Time.deltaTime;
            if (_currentTimer <= 0)
            {
                var randomNum = Random.Range(0, npcList.Count);
                var selected = npcList.ElementAt(randomNum);
                selected.gameObject.SetActive(true);
                npcList.Remove(selected);
                _currentTimer = Random.Range(_startTimer, _startTimer / 2);
            }
        }

        if (_timeSys.currentHour == 7 && !objetoActivo)
        {
            objetoParaActivar.SetActive(true);
            objetoActivo = true;
            Invoke("DesactivarObjeto", 5f);
        }
    }
    void DesactivarObjeto()
    {
        objetoParaActivar.SetActive(false);
    }
}
