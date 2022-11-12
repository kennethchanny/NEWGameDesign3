using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{


    private Animator animRef;
    public AudioScript audioQuitRef;
    public GameObject sticksMovment;
    public GameObject curtainClosing;

    private void Start()
    {
        animRef = GetComponent<Animator>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
       
        StartCoroutine(PostBtnAudio(4.0f));
        Application.Quit();

    }

    ///////////////////////Nicole added below

    public void PlayMMPuppetAnim()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animRef.SetTrigger("Transition");
        sticksMovment.SetActive(true);
        StartCoroutine(CloseCurtainAudio(1.3f));
        // puppet moving down the screen 2.5s
        // 6 sticks moving
        // @1.3s play curtain sounds
        //StartCoroutine(CloseCurtainAudio(1.3f));
        
    }

    IEnumerator PostBtnAudio(float waitTime)
    {
        audioQuitRef.playAudio3();
        yield return new WaitForSeconds(waitTime);
        
    }

    IEnumerator CloseCurtainAudio(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        curtainClosing.SetActive(true);
    }


}
