using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withc : MonoBehaviour
{
    private AudioScript audioscript;
    private Animator animRef;
    public float countDown = 200f;
    private bool phase1 = false;
    private bool phase2 = false;
    private bool phase3 = false;

    private bool istooLate = false;
    void Start()
    {
        animRef = GetComponent<Animator>();
        audioscript = GetComponent<AudioScript>();
        EventManager.current.onWitchDeath += ResetCountDown;
        EventManager.current.onResetWitchTimer += ResetCountDown;
    }

    private void OnDestroy()
    {
        EventManager.current.onWitchDeath -= ResetCountDown;
        EventManager.current.onResetWitchTimer -= ResetCountDown;
    }

    public void Cackle()
    {
        audioscript.playAudio();
    }
    void UpdateWitchTimer()
    {
        if (istooLate) return;

        countDown -= Time.deltaTime;

        if(countDown <= 150f && phase1 == false)
        {
            phase1 = true;
            Debug.Log("Phase1");
            animRef.SetTrigger("Phase1");
         
        }
        if(countDown <= 120f && phase2 == false)
        {
            phase2 = true;
            Debug.Log("Phase2");
            animRef.SetTrigger("Phase2");
        }
        if (countDown <= countDown - 80f && phase3 == false)
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

    public void WitchDeath()
    {
        EventManager.current.GameOverTriggered();
    }
    public void ResetCountDown()
    {

        countDown = 150;
        animRef.SetTrigger("Rest");
    }
    // Update is called once per frame
    void Update()
    {
        UpdateWitchTimer();
    }
}
