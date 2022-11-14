using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMover : MonoBehaviour
{
    public GameObject cameraRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position, new Vector2(cameraRef.transform.position.x, transform.position.y) , 2f);
    }
}
