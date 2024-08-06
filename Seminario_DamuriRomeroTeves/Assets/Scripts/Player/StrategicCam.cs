using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategicCam : MonoBehaviour
{
    public Transform target; // El personaje o punto de interés que la cámara puede seguir
    public Transform initialPosition; // Posición inicial a la que la cámara regresará cuando se presione la tecla E
    public PlayerController pl;
    public float moveSpeed = 10f; // Velocidad de movimiento de la cámara
    public float rotateSpeed = 100f; // Velocidad de rotación de la cámara
    public float zoomSpeed = 500f; // Velocidad de zoom de la cámara
    public float minZoom = 10f; // Mínimo nivel de zoom
    public float maxZoom = 100f; // Máximo nivel de zoom
    public float returnSpeed = 5f; // Velocidad a la que la cámara regresa a la posición inicial
    public float smoothZoomSpeed = 10f; // Velocidad de zoom suave

    private float currentZoom = 40f; // Nivel de zoom actual
    private float targetZoom; // Nivel de zoom de destino
    private Vector3 currentRotation; // Rotación actual de la cámara
    private bool returningToInitial = false; // Indica si la cámara está volviendo a la posición inicial


    //demas
    public Vector3 offset;
    Vector3 currentvelocity=Vector3.zero;
    [SerializeField] Transform targuet;
    [SerializeField] float smooth;
    private void Awake()
    {
        if(!pl.a) 
        {
            offset = transform.position - target.position;
        }
    }
    void Start()
    {
        currentRotation = transform.eulerAngles;
        targetZoom = currentZoom;
    }
    private void LateUpdate()
    {
        if (!pl.a)
        {
            Vector3 targpos=target.position+offset;
            transform.position=Vector3.SmoothDamp(transform.position,targpos,ref currentvelocity,smooth);
        }
    }
    void Update()
    {
        if(pl.a)
        {
            HandleMovement();
            HandleRotation();
            HandleZoom();
            HandleReturnToInitialPosition();
        }

    }

    void HandleMovement()
    {
        if (returningToInitial)
            return; // No permitir movimiento mientras se regresa a la posición inicial

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * direction;

        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    void HandleRotation()
    {
        if (returningToInitial)
            return; // No permitir rotación mientras se regresa a la posición inicial

        if (Input.GetMouseButton(1)) // Botón derecho del ratón
        {
            float h = Input.GetAxis("Mouse X");
            currentRotation.y += h * rotateSpeed * Time.deltaTime;
            transform.eulerAngles = currentRotation;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scroll * zoomSpeed * Time.deltaTime;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * smoothZoomSpeed);
        Camera.main.fieldOfView = currentZoom;
    }

    void HandleReturnToInitialPosition()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            returningToInitial = true;
            StartCoroutine(ReturnToInitial());
        }
    }

    IEnumerator ReturnToInitial()
    {
        while (Vector3.Distance(transform.position, initialPosition.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition.position, Time.deltaTime * returnSpeed);
            yield return null;
        }
        returningToInitial = false;
    }
}
