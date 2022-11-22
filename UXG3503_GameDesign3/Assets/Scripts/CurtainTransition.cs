using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTutorial = false;
    private Animator animref;
    private InGameDialogue theshowgoon;
    public postprocess postprocessref;
    private AudioScript audioscript;


    void Start()
    {
        audioscript = GetComponent<AudioScript>();
        animref = GetComponent<Animator>();
        theshowgoon = GameObject.Find("TheShowMustGoOn!").GetComponent<InGameDialogue>();
        EventManager.current.onGameOver += CurtainClose;
        EventManager.current.onTutorialEnded += CurtainClose;
        EventManager.current.onCompletedGame += CurtainClose2;
      
    }


    private void OnDestroy()
    {
        EventManager.current.onGameOver -= CurtainClose;
        EventManager.current.onTutorialEnded -= CurtainClose;
        EventManager.current.onCompletedGame -= CurtainClose2;
    }

    public void TurnOffPost()
    {
        if(!isTutorial)
        postprocessref.OffPP();
    }

    public void TurnOnPost()
    {
        if (!isTutorial)
            postprocessref.OnPP();
    }
    public void CurtainClose()
    {
        animref.SetTrigger("GameOver");
    }

    public void CurtainClose2(int unaliver)
    {

        //Gretel
        if(unaliver == 1)
        {
            animref.SetTrigger("GameSuccess1");
            Debug.Log("GRETELANIMGAMEOVER");
        }

        //Gretel
        if (unaliver == 2)
        {
            animref.SetTrigger("GameSuccess2");
            Debug.Log("HASNELANIMGAMEOVER");
        }

       
    }


    public void TriggerWords()
    {
        theshowgoon.StartDialogue();
        audioscript.playAudio();
    }

    public void RestartGame()
    {
        if(!isTutorial)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FinishGame(int id)
    {
        if(id == 1)
        SceneManager.LoadScene("Gretel");

        if (id == 2)
        SceneManager.LoadScene("Hansel");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
