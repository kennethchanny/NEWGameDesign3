using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withc : MonoBehaviour
{
    private Animator animRef;
    public float countDown = 80f;
    private bool phase1 = false;
    private bool phase2 = false;
    private bool phase3 = false;

    private bool istooLate = false;
    void Start()
    {
        animRef = GetComponent<Animator>();
        EventManager.current.onWitchDeath += ResetCountDown;
    }

    private void OnDestroy()
    {
        EventManager.current.onWitchDeath -= ResetCountDown;
    }

    void UpdateWitchTimer()
    {
        if (istooLate) return;

        countDown -= Time.deltaTime;

        if(countDown <= 60f && phase1 == false)
        {
            phase1 = true;
            Debug.Log("Phase1");
            animRef.SetTrigger("Phase1");
        }
        if(countDown <= 40f && phase2 == false)
        {
            phase2 = true;
            Debug.Log("Phase2");
            animRef.SetTrigger("Phase2");
        }
        if (countDown <= 20f && phase3 == false)
        {
            phase3 = true;
            Debug.Log("Phase3");
            animRef.SetTrigger("Phase3");
        }
        if(countDown  <= 0f)
        {
            countDown = 0;
            istooLate = true;
            animRef.SetTrigger("Death");
        }
    }

    public void ResetCountDown()
    {
        countDown = 60;
        animRef.SetTrigger("Rest");
    }
    // Update is called once per frame
    void Update()
    {
        UpdateWitchTimer();
    }
}
