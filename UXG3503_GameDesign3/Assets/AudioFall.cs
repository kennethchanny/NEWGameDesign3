using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFall : MonoBehaviour
{
    private AudioScript fallAudio;
    private bool fallAudio1;
    public GameObject HanselPlayer2;
    public GameObject GretelPlayer1;

    private float P2_Pos1;
    private float P1_Pos1;

    // Start is called before the first frame update
    void Start()
    {
        fallAudio = GetComponent<AudioScript>();
        P1_Pos1 = HanselPlayer2.transform.position.y - 20f;
        P2_Pos1 = GretelPlayer1.transform.position.y -20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (HanselPlayer2.transform.position.y < P1_Pos1 || GretelPlayer1.transform.position.y < P2_Pos1)
            fallAudio.playAudio();

    }
}
