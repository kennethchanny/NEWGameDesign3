using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTimer : MonoBehaviour
{

    AudioSource thisAudio;
    public float playTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        thisAudio = GetComponent<AudioSource>();
        StartCoroutine("StopAudioCoroutine");
        thisAudio.Stop();
    }

    IEnumerator StopAudioCoroutine()
    {
        while (true)
        {
            thisAudio.Play();
            yield return new WaitForSeconds(playTime);
            thisAudio.Stop();
        }
    }
}
