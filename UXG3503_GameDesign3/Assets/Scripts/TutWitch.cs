using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutWitch : MonoBehaviour
{
    private Animator animRef;

    private bool tutPhase1 = true;
    private bool tutPhase2 = false;

    // Start is called before the first frame update
    void Start()
    {
        animRef = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutPhase1 == true)
        {
            animRef.SetTrigger("Tutorial_Phase1");
        }

        if (tutPhase2 == true)
        {
            animRef.SetTrigger("Tutorial_Phase2");
        }
    }

    void CueTutPhase02()
    {
        tutPhase2 = true;
    }
}
