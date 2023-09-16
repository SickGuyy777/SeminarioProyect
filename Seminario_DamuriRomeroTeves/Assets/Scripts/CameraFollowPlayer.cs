using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    Vector3 _offset;
    Vector3 _currentVelocity = Vector3.zero;
    [SerializeField] Transform _target;
    [SerializeField] float _smoothTime;

    private void Awake()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _currentVelocity, _smoothTime);
    }
}
