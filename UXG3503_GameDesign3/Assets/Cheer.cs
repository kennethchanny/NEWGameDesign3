using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheer : MonoBehaviour
{
    //AudioScript reference
    private AudioScript audioRef;
    public float delayTime = 3.0f;
    public float delayTime2 = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioRef = GetComponent<AudioScript>();
        StartCoroutine("DelayAudioCoroutine");
    }

    IEnumerator DelayAudioCoroutine()
    {
        yield return new WaitForSeconds(delayTime);
        audioRef.playAudio();
        yield return new WaitForSeconds(delayTime2);
        audioRef.playAudio2();
    }
}
