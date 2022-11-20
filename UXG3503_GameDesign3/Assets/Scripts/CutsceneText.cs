using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneText : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public string[] sentence;
    private int index;
    public float textSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StoryCaption());
    }

    IEnumerator StoryCaption()
    {
        foreach (char character in sentence[index].ToCharArray())
        {
            storyText.text += character;
            yield return new WaitForSeconds(textSpeed);
        }
        nextSentence();
    }

    public void nextSentence()
    {
        if (index < sentence.Length - 1)
        {
            index++;
            storyText.text = "";
            StartCoroutine(StoryCaption());
        }

        else storyText.text = "";
    }
}
