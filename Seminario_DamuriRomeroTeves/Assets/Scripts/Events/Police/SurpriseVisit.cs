using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseVisit : MonoBehaviour
{
    [SerializeField] List<GameObject> _interactuableObjs = new List<GameObject>();
    [SerializeField] List<GameObject> _naturalObjs = new List<GameObject>();

    private void Awake()
    {
        foreach (var item in _interactuableObjs)
            item.gameObject.SetActive(true);
        foreach (var item in _naturalObjs)
            item.gameObject.SetActive(false);
    }
}
