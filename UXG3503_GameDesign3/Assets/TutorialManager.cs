using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public bool lever1ison = false;
    public bool lever2ison = false;
    public bool lever3ison = false;
    private bool istutorialcomplete = false;
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

            }
        }
        CheckTutorialEnd();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
