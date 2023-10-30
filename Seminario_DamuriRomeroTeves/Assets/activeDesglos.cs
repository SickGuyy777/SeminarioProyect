using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeDesglos : MonoBehaviour
{
    [SerializeField] Animator animDesglose;
    bool anim;
    public void animdesTrue()
    {
        animDesglose.SetBool("Open",true);
    }
    public void animdesFalse()
    {
            animDesglose.SetBool("Open", false);
    }
}
