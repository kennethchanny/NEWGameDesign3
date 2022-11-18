using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public bool gameOver = false;
    private CameraFollowTarget cameraref;
    [SerializeField] private float deathdecaytimer = 0;
    public float maxdeathDecay = 2f;
    private bool playSound;
    private AudioScript audioref;
    private AudioSource audiosourceref;
    void Start()
    {
        audioref = GetComponent<AudioScript>();
        audiosourceref = GetComponent<AudioSource>();
        cameraref = GameObject.Find("CinemachineStateDrivenCamera").GetComponent<CameraFollowTarget>();
        deathdecaytimer = 0;
        gameOver = false;
    }

    // Update is called once per frame


    private void GameOverChecker()
    {

        //if game is over, dont continue
        if (gameOver == true) return;

        if (deathdecaytimer > maxdeathDecay)
        {
            //die
            audiosourceref.volume = 1;
            audioref.playAudio2();
            deathdecaytimer = 0;
            gameOver = true;
            EventManager.current.GameOverTriggered();

        }

        //if more than boundary, start countdown
        if (cameraref.playerseparation > cameraref.maxseparation)
        {
            //increase timer
            deathdecaytimer += Time.deltaTime;
            //if cross timer, gg
           

            if (playSound == false)
            {
                audioref.playAudio();
                playSound = true;
                
            }
           


        }

        //while more than boundary, if become less,
        if (cameraref.playerseparation < cameraref.maxseparation)
        {
            deathdecaytimer = 0;
           
            if (playSound == true)
            {
               
                playSound = false;
                audiosourceref.Stop();

            }
        
           

        }
    }
    void Update()
    {
        GameOverChecker();
    }
}
