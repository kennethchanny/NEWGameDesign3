using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePopUp : MonoBehaviour
{
    public TMP_Text popupText;
    private Animator animref;
    public float resettimer = 4.2f;

    public float randomtexttimer = 7.2f;
    public Transform playerTransform;

    public bool isSpawned = false;


    [Header("Texts for Straying too Far")]
    public string[] toofartexts;

    [Header("Random Texts")]
    public string[] randomtexts;



    public void PopUp(int id)
    {
        if (isSpawned) return;

        if(id == 1) //Stray too far texts
        {
            isSpawned = true;
            int usetext = Random.Range(0, toofartexts.Length);
            string picktext = toofartexts[usetext];
            popupText.text = picktext;
            animref.SetTrigger("popup");
        }

        if (id == 2) //Random texts
        {
            isSpawned = true;
            int usetext = Random.Range(0, randomtexts.Length);
            string picktext = randomtexts[usetext];
            popupText.text = picktext;
            animref.SetTrigger("popup");
        }

    }


    void Start()
    {
        animref = GetComponent<Animator>();
        EventManager.current.onDialogueTriggered += PopUp;

    }

    private void OnDestroy()
    {
        EventManager.current.onDialogueTriggered -= PopUp;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1.2f, playerTransform.position.z);
        

        if(isSpawned == true)
        {
            resettimer -= Time.deltaTime;
            if (resettimer < 0)
            {
                resettimer =Random.Range(2f, 4.2f);
                isSpawned = false;
            }
        }

        randomtexttimer -= Time.deltaTime;
        if (randomtexttimer < 0)
        {
            randomtexttimer = Random.Range(11.5f, 13f);
            if (isSpawned == false)
            {
                PopUp(2);
                isSpawned = true;
            }

        }

    }
}
