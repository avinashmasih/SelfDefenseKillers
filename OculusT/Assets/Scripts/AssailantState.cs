using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssailantState : MonoBehaviour
{
    public Animator anim;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            anim.SetTrigger("startAttack");
        }
        if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            anim.SetBool("gotPoked", true);
        }
    }
}
