using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCam : MonoBehaviour
{
    [SerializeField] Camera _Cam;
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _Cam.transform.position);
    }
}
