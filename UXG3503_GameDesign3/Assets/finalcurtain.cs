using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalcurtain : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public void FinalTransition(int id)
    {
        if(id == 31)
        {
          
            //GRETEL NEARER
            if(Vector2.Distance(player1.transform.position, transform.position) < Vector2.Distance(player2.transform.position, transform.position))
            {
                EventManager.current.CompletedGame(1);
                Debug.Log("GAMEENDGRETEL");
            }

            else
            {
                //HANSEL
                EventManager.current.CompletedGame(2);
                Debug.Log("GAMEENDHANSEL");
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.onLeverPulled += FinalTransition;
        player1 = GameObject.Find("GretelPlayer1");
        player2 = GameObject.Find("HanselPlayer2");
    }

    private void OnDestroy()
    {
        EventManager.current.onLeverPulled -= FinalTransition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
