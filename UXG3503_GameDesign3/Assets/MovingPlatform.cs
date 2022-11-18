using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2;
    private bool istarget1 = true;
    public int id;
    public Transform target1;
    public Transform target2;
    public Transform activetarget;

    //AudioScript reference
    private AudioScript audioRef;

    void Start()
    {
        audioRef = GetComponent<AudioScript>();
        EventManager.current.onLeverPulled += TogglePlatform;
    }
    private void OnDestroy()
    {
        EventManager.current.onLeverPulled -= TogglePlatform;
    }
    void TogglePlatform(int id)
    {
        if(this.id == id)
        {
            if (istarget1)
            {
                audioRef.playAudio();
                istarget1 = false;
                activetarget.position = target2.position;
            }
            else
            {
                audioRef.playAudio();
                istarget1 = true;
                activetarget.position = target1.position;
            }
        }
       
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }

    void UpdateMovement(Vector3 point)
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, point, step);

        float distancebetween = Vector3.Distance(transform.position,point);
        if(distancebetween <= 0.01)
        {
            transform.position = point;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateMovement(activetarget.position);
    }

}
