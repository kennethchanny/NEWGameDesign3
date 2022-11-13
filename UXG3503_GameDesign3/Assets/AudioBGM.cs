using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioBGM : MonoBehaviour
{
    private AudioSource AudioRef;

    private void Awake()
    {
        // Do not destroy audio track
        DontDestroyOnLoad(transform.gameObject);
        AudioRef = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //reach main screne fade out
    }
}
