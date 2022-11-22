using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float moveSpeed = 0;
    public int leverDirection = 0;
    public Transform rightrope;
    public Transform leftrope;
    public GameObject player2ref;
    public GameObject cageref;
    public float maxX = 0;
    public float minX = 0;
    public GameObject cageparticles;
    public bool isMoving;
    private AudioScript audioref;
    private bool sound;


    public void TriggerLever(int id)
    {
        switch (id)
        {
            case 1:
                {
                    switch (leverDirection)
                    {

                        case 0:
                            {
                                //play moving sound
                                Instantiate(cageparticles, rightrope.position, Quaternion.identity);
                                Instantiate(cageparticles, leftrope.position, Quaternion.identity);
                                leverDirection = 1;
                                isMoving = true;
                            }
                            break;
                        case 1:
                            {
                                //play moving sound
                                Instantiate(cageparticles, rightrope.position, Quaternion.identity);
                                Instantiate(cageparticles, leftrope.position, Quaternion.identity);
                                leverDirection = -1;
                                isMoving = true;
                            }
                            break;
                        case -1:
                            {
                                //play moving sound
                                Instantiate(cageparticles, rightrope.position, Quaternion.identity);
                                Instantiate(cageparticles, leftrope.position, Quaternion.identity);
                                leverDirection = 1;
                                isMoving = true;
                            }
                            break;


                    }
                }
                break;

            case 2:
                {
                    if(player2ref.transform.parent != null)
                    {
                        //play cage release sound
                        Instantiate(cageparticles, rightrope.position, Quaternion.identity);
                        Instantiate(cageparticles, leftrope.position, Quaternion.identity);
                        cageref.GetComponent<BoxCollider2D>().enabled = false;
                        player2ref.transform.parent = null;
                        leverDirection = 0;
                    }

                }
                break;


        }


    }

    private void Start()
    {
        audioref = GetComponent<AudioScript>();
        EventManager.current.onLeverPulled += TriggerLever;
    }

    private void OnDestroy()
    {
        EventManager.current.onLeverPulled -= TriggerLever;
    }
    public void MoveCage(int dir)
    {
        if(isMoving)
        {
            rightrope.Translate(moveSpeed * dir, 0, 0);

            leftrope.Translate(moveSpeed * dir, 0, 0);
        }
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
       
        if (cageref.transform.localPosition.x > maxX)
        { //add cage stop sound here
            if(sound == false)
            {
                audioref.playAudio();
                sound = true;
            }
           
            cageref.transform.localPosition = new Vector3(maxX, cageref.transform.localPosition.y, cageref.transform.localPosition.z);
            isMoving = false;



        }

        if (cageref.transform.localPosition.x < minX)
        {
            cageref.transform.localPosition = new Vector3(minX, cageref.transform.localPosition.y, cageref.transform.localPosition.z);
            //add cage stop sound here
            if (sound == false)
            {
                audioref.playAudio();
                sound = true;
            }
            EventManager.current.LeverPulled(2);

        }
    }
    private void FixedUpdate()
    {

        MoveCage(leverDirection);
    

    }
}
