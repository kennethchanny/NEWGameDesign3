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


    void Start()
    {
        animref = GetComponent<Animator>();
        theshowgoon = GameObject.Find("TheShowMustGoOn!").GetComponent<InGameDialogue>();
        EventManager.current.onGameOver += CurtainClose;
        EventManager.current.onTutorialEnded += CurtainClose;
      
    }


    private void OnDestroy()
    {
        EventManager.current.onGameOver -= CurtainClose;
        EventManager.current.onTutorialEnded -= CurtainClose;
    }

    public void TurnOffPost()
    {
        postprocessref.OffPP();
    }

    public void TurnOnPost()
    {
        postprocessref.OnPP();
    }
    public void CurtainClose()
    {
        animref.SetTrigger("GameOver");
    }

    public void TriggerWords()
    {
        theshowgoon.StartDialogue();
    }

    public void RestartGame()
    {
        if(!isTutorial)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
