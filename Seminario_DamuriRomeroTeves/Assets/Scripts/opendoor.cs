using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public Animator _animation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Humano"))
        {
            _animation.SetBool("pl",true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Humano"))
        {
            _animation.SetBool("pl", false);
        }
    }
}
