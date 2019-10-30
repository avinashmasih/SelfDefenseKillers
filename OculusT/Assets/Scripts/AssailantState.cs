using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssailantState : MonoBehaviour
{
    public Animator anim;
    public bool reset = false;
    public bool poked = false;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            anim.SetTrigger("pokeApproach");
            if(poked)
            {
                anim.SetBool("gotPoked", true);
            }
        }

      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("groinApproach");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("punchApproach");
        }
        //Eye Poke
        //anim.SetBool("gotPoked", true);
        //groin punch
        //anim.SetBool("groinHit", true);
        //Block
        //anim.SetBool("gotBlock", true);
        //Reset to idle
        //anim.SetBool("reset",true);
        //Reset()
    }

    private void Reset()
    {
        //Clearing out
        //Eye Poke
        anim.SetBool("gotPoked", false);
        //groin punch
        anim.SetBool("groinHit", false);
        //Block
        anim.SetBool("gotBlock", false);
        //Reset to idle
        anim.SetBool("reset",false);
    }

    public void setPoked()
    {
        anim.SetBool("gotPoked", true);
    }

   
}
