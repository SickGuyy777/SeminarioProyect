using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringAlcoholEvent : MonoBehaviour
{
    [SerializeField] SurpriseVisit _event;

    bool _canPut;

    private void Update()
    {
        if (_canPut)
        {
            if (Input.GetKeyDown(KeyCode.P) && _event.pickedUp == true)
            {
                _event.cantPick++;
                _event.pickedUp = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Humano")
        {
            _canPut = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Humano")
        {
            _canPut = false;
        }
    }
}
