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
                                leverDirection = 1;
                            }
                            break;
                        case 1:
                            {
                                leverDirection = -1;
                            }
                            break;
                        case -1:
                            {
                                leverDirection = 1;
                            }
                            break;


                    }
                }
                break;

            case 2:
                {
                    if(player2ref.transform.parent != null)
                    {
                        cageref.GetComponent<BoxCollider2D>().enabled = false;
                        player2ref.transform.parent = null;
                    }

                }
                break;


        }


    }

    private void Start()
    {
        EventManager.current.onLeverPulled += TriggerLever;
    }

    private void OnDestroy()
    {
        EventManager.current.onLeverPulled -= TriggerLever;
    }
    public void MoveCage(int dir)
    {
        rightrope.Translate(moveSpeed * dir, 0, 0);
        leftrope.Translate(moveSpeed * dir, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {

        MoveCage(leverDirection);
    

    }
}
