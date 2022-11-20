using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneText : MonoBehaviour
{
    //public TextMeshProUGUI storyText;
    //public string[] sentence;
    //private int index;
    //public float textSpeed;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //IEnumerator StoryCaption()
    //{
    //    foreach (char character in sentence[index].ToCharArray())
    //    {
    //        storyText.text += character;
    //        yield return new WaitForSeconds(textSpeed);
    //    }
    //    nextSentence();
    //}

    //public void nextSentence()
    //{
    //    if (index < sentence.Length - 1)
    //    {
    //        index++;
    //        storyText.text = "";
    //        StartCoroutine(StoryCaption());
    //    }

    //    else storyText.text = "";
    //}

    //public void StartStoryNarration()
    //{
    //    StartCoroutine(StoryCaption());
    //}

    public TextMeshProUGUI[] storyText;
    public string[] sentence;
    public float textSpeed;

    IEnumerator StoryCaption(int currentTextIndex)
    {
        foreach (char character in sentence[currentTextIndex].ToCharArray())
        {
            storyText[currentTextIndex].text += character;
            yield return new WaitForSeconds(textSpeed);
        }

        if (currentTextIndex == 0 || currentTextIndex == 2 || currentTextIndex == 5 || currentTextIndex == 9 || currentTextIndex == 11 || currentTextIndex == 13) StartCoroutine(StoryCaption(currentTextIndex + 1));
        else if (currentTextIndex == 7)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(StoryCaption(8));
        }
        yield return new WaitForSeconds(1f);

        if (currentTextIndex == 1 || currentTextIndex == 3 || currentTextIndex == 6 || currentTextIndex == 8 || currentTextIndex == 10 || currentTextIndex == 12 || currentTextIndex == 14)
        {
            while (storyText[currentTextIndex-1].color.a > 0 && storyText[currentTextIndex].color.a > 0)
            {
                storyText[currentTextIndex - 1].color = Color.Lerp(storyText[currentTextIndex - 1].color, Color.clear, 3f * Time.deltaTime);
                storyText[currentTextIndex].color = Color.Lerp(storyText[currentTextIndex].color, Color.clear, 3f * Time.deltaTime);
                yield return null;
            }
        }

        else if (currentTextIndex == 4)
        {
            while (storyText[currentTextIndex].color.a > 0)
            {
                storyText[currentTextIndex].color = Color.Lerp(storyText[currentTextIndex].color, Color.clear, 3f * Time.deltaTime);
                yield return null;
            }
        }
    }

    public void StartStoryNarration(int currentTextIndex)
    {
        StartCoroutine(StoryCaption(currentTextIndex));
    }
}
