using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPoseGuide : MonoBehaviour
{
    protected bool m_VRhandDetected = false;
    public Color greencolor;
    public Color whitecolor;

    private void OnTriggerEnter(Collider other)
    {
        m_VRhandDetected = true;
        transform.GetComponent<Renderer>().material.color = greencolor;
    }

    private void OnTriggerExit(Collider other)
    {
        m_VRhandDetected = false;
        transform.GetComponent<Renderer>().material.color = whitecolor;
    }

}
