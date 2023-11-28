using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Charlas : MonoBehaviour
{
    public TimeSystem time;
    public Animator chisme;
    private bool animacionActiva = false;
    private void Update()
    {
        if(time.currentDay==14 && time.currentHour==9 && !animacionActiva)
        {
            chisme.SetBool("Chisme", true);
            animacionActiva = true;
            Invoke("Falseanim", 10f);
        }

    }
    public void Falseanim()
    {
        chisme.SetBool("Chisme", false);
        animacionActiva = false;
    }
}
