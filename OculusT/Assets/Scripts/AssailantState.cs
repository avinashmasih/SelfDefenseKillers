using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssailantState : MonoBehaviour
{
    public Animator anim;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("startAttack");
        }
        if(Input.GetKey(KeyCode.X))
        {
            anim.SetBool("gotPoked", true);
        }
    }
}
