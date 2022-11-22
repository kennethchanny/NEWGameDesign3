using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGate : MonoBehaviour
{
    public int id;
    public bool isOpen;
    public Transform point;
    public bool isResetWitch;
    void Start()
    {
     
        EventManager.current.onLeverPulled += OpenGate;

    }
    private void OnDestroy()
    {
        EventManager.current.onLeverPulled -= OpenGate;
    }
    public void OpenGate(int id)
    {
        if (id == this.id)
        {
            isOpen = true;

            if(isResetWitch)
            EventManager.current.ResetWitchTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen)
        {
            var step = 2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, point.position, step);

            float distancebetween = Vector3.Distance(transform.position, point.position);
            if (distancebetween <= 0.01)
            {
                transform.position = point.position;
            }
        }
       
    }
}
