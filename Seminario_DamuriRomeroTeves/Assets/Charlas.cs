using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Charlas : MonoBehaviour
{
    public TimeSystem time;
    public Animator chisme;
    public GameObject charlaBoos1;
    private bool animacionActiva = false;
    public bool call1 = false;

    private void Update()
    {
        if (time.currentDay == 14 && time.currentMonth == 0 && time.currentHour == 9 && time.CurrentMinutes <= 20 && !animacionActiva && !call1)
        {
            FeedBackPhone();
            call1 = true;
            Invoke("Call1Maf", 20);
        }
    }

    public void FeedBackPhone()
    {
        chisme.SetBool("Chisme", true);
        animacionActiva = true;
        Invoke("Falseanim", 10f);
    }

    public void Falseanim()
    {
        chisme.SetBool("Chisme", false);
        animacionActiva = false;
    }

    public void CharlaMaf1()
    {
        if (call1)
        {
            charlaBoos1.SetActive(true);
        }
    }

    private void Call1Maf()
    {
        call1 = false; // Setear call1 a falso después de 20 segundos
    }
}
