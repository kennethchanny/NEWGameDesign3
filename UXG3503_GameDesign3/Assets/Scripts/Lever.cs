using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int id;
    private Animator animref;
    private AudioScript audioRef;

    private GameObject player1;
    private GameObject player2;
    public float delayTime = 0.2f;

    public float leverDistance;

    IEnumerator DelayAudioCoroutine()
    {
        yield return new WaitForSeconds(delayTime);
        audioRef.playAudio2();
    }
    void ToggleLever()
    {
        if(Vector2.Distance(player1.transform.position, transform.position) < leverDistance)
        {
      
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                animref.SetTrigger("ToggleLever");
                EventManager.current.LeverPulled(id);
                audioRef.playAudio();
                StartCoroutine(DelayAudioCoroutine());
            }
           
        }

        if (Vector2.Distance(player2.transform.position, transform.position) < leverDistance && Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                animref.SetTrigger("ToggleLever");
                EventManager.current.LeverPulled(id);
                audioRef.playAudio();
                StartCoroutine(DelayAudioCoroutine());

            }
        }

    }
    void Start()
    {
        audioRef = GetComponent<AudioScript>();
       
        animref = GetComponent<Animator>();
        player1 = GameObject.Find("GretelPlayer1");
        player2 = GameObject.Find("HanselPlayer2");
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleLever();
    }
}
