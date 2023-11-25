using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInteract : MonoBehaviour
{
    [SerializeField] SurpriseVisit _event;
    [SerializeField] LayerMask _playerMask;

    bool _canPick = false;

    private void Update()
    {
        if(_canPick)
        {
            if (Input.GetKeyDown(KeyCode.P) && _event.pickedUp == false)
            {
                Debug.Log("PICK");
                _event.pickedUp = true;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Humano")
        {
            _canPick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Humano")
        {
            _canPick = false;
        }
    }
}
