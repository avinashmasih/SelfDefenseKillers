using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject orient;
    public GameObject leftpoke;
    public GameObject rightpoke;

    private bool input = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        orient.SetActive(true);
        leftpoke.SetActive(false);
        rightpoke.SetActive(false);
        StartCoroutine(OnStart());
    }

    private IEnumerator OnStart()
    {

        orient.SetActive(false);
        leftpoke.SetActive(true);
    }
}
