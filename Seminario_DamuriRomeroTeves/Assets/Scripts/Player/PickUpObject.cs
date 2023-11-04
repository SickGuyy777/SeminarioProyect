using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject UIPickUp;
    public bool hasObject;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>(); 

        if (player != null)
        {
            UIPickUp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            UIPickUp.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && UIPickUp.activeSelf)
        {
            hasObject = true;
            gameObject.SetActive(false);
            UIPickUp.SetActive(false);
        }
    }
}
