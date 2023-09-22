using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Humano"))
        {
            anim.SetBool("pl",true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Humano"))
        {
            anim.SetBool("pl", false);
        }
    }
}
