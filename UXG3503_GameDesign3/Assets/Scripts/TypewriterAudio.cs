using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class TypewriterAudio : MonoBehaviour
{
    private AudioSource audioSource_ref;    //Disable or stop when not using

    public bool PreloadOnStart = true;      //Takes up more space on the RAM, but CPU will work less 
    public AudioClip[] collection;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        audioSource_ref = GetComponent<AudioSource>();
        if (PreloadOnStart)
            LoadClips();
    }

    public virtual void PlayOneShot()
    {
        audioSource_ref.PlayOneShot(collection[Random.Range(0, collection.Length)]);
    }

    public virtual void PlayOneShot(int index)
    {
        audioSource_ref.PlayOneShot(collection[index]);
    }

    public virtual void Stop(int index)
    {
        audioSource_ref.Stop();
    }

    public virtual void LoadClips()
    {
        for (int i = 0; i < collection.Length; ++i)
            collection[i].LoadAudioData();
    }

    public virtual void LoadClips(int index)
    {
        collection[index].LoadAudioData();
    }

    public virtual void UnloadClips()
    {
        for (int i = 0; i < collection.Length; ++i)
            collection[i].UnloadAudioData();
    }

    public virtual void UnloadClips(int index)
    {
        collection[index].UnloadAudioData();
    }

    //public virtual void FadeOut()
    //{
    //    StartCoroutine(FadeOutMusic());

    //}

    //IEnumerator FadeOutMusic()
    //{
    //    // Find Audio Music in scene
    //    AudioSource audioMusic = this.GetComponent<AudioSource>();

    //    // Check Music Volume and Fade Out
    //    while (audioMusic.volume > 0.01f)
    //    {
    //        audioMusic.volume -= Time.deltaTime * 3;
    //        yield return null;
    //    }

    //    // Make sure volume is set to 0
    //    audioMusic.volume = 0;

    //    // Stop Music
    //    audioMusic.Stop();

    //    LoadSceneTo();
    //}

    //public int SceneBuildIndex;
    //private void LoadSceneTo()
    //{
    //    SceneManager.LoadScene(SceneBuildIndex);
    //}
}
