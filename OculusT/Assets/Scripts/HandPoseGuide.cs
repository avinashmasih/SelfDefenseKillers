using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPoseGuide 
    : MonoBehaviour
{
    private OVRInput.Controller m_controller;
    protected bool m_VRhandDetected = false;
    public Color greencolor;
    public Color whitecolor;

    private void OnTriggerEnter(Collider other)
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true && (OVRInput.Get(OVRInput.Touch.PrimaryThumbRest)) == false)
            
        {
            m_VRhandDetected = true;
            transform.GetComponent<Renderer>().material.color = greencolor;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        m_VRhandDetected = false;
        transform.GetComponent<Renderer>().material.color = whitecolor;
    }
    //m_isGivingThumbsUp = !OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, m_controller);
}
