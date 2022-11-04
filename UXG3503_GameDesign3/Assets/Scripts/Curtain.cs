using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{

    //AudioScript reference
    private AudioScript audioRef;
    public float delayTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioRef = GetComponent<AudioScript>();
        audioRef.playAudio();
        StartCoroutine("DelayAudioCoroutine");
    }

    IEnumerator DelayAudioCoroutine()
    {
        yield return new WaitForSeconds(delayTime);
        audioRef.playAudio2();
    }
}
