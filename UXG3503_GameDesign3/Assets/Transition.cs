using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public CurtainTransition curtainref;
    public void ChangeScene()
    {
        curtainref.CurtainClose();
    }

}
