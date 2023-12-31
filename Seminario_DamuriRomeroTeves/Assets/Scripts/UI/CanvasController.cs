using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public bool onManagment;

    PlayerController _playerPr;

    private void Awake()
    {
        _playerPr = PlayerController.FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (onManagment) _playerPr.movementSpeed = 0f;
        else _playerPr.movementSpeed = _playerPr.maxSpeed;
    }
}
