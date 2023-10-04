using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float movementSpeed;
    [SerializeField] float _rotationSpeed;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] Animator animpl;
    CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        movementSpeed = maxSpeed;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movementDir = new Vector3(h, 0, v);
        float magnitude = Mathf.Clamp01(movementDir.magnitude) * movementSpeed;
        movementDir = Quaternion.AngleAxis(_cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDir;
        movementDir.Normalize();
        _characterController.SimpleMove(movementDir * magnitude);

        if (movementDir != Vector3.zero)
        {
            animpl.SetBool("Walk",true);
            Quaternion toRotation = Quaternion.LookRotation(movementDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            animpl.SetBool("Walk", false);
        }
    }
}
