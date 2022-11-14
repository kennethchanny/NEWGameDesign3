using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public bool lever1ison = false;
    public bool lever2ison = false;
    public bool lever3ison = false;
    private bool istutorialcomplete = false;

    public GameObject lever1Audio;
    public GameObject lever2Audio;
    public GameObject lever3Audio;
    public GameObject curtainCLoseAudio;

    // Start is called before the first frame update
    void Start()
    {

        EventManager.current.onLeverPulled += PullTutorialLever;
    }

    private void OnDestroy()
    {

        EventManager.current.onLeverPulled -= PullTutorialLever;
    }

    void CheckTutorialEnd()
    {
        if (istutorialcomplete) return;

        if(lever1ison == true && lever2ison == true && lever3ison == true)
        {
            istutorialcomplete = true;
            EventManager.current.TutorialEndedTriggered();
            curtainCLoseAudio.SetActive(true);
        }
    }

    void PullTutorialLever(int id)
    {
        
        if (id == 1)
        {
            if (lever1ison)
            {
                lever1ison = false;
                
            }
            else
            {
                lever1ison = true;
                lever1Audio.SetActive(true);
            }
        }

        if (id == 2)
        {
            if (lever2ison)
            {
                lever2ison = false;

            }
            else
            {
                lever2ison = true;
                lever2Audio.SetActive(true);

            }
        }
        if (id == 3)
        {
            if (lever3ison)
            {
                lever3ison = false;

            }
            else
            {
                lever3ison = true;
                lever3Audio.SetActive(true);

            }
        }
        CheckTutorialEnd();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
