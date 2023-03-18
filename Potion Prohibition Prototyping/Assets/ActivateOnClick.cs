using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnClick : MonoBehaviour
{
    public GameObject[] ActivateObjOnClick;
    public GameObject[] DeactivateObjOnClick;

    public void ActivateOnClickFunc()
    {
        foreach (GameObject ThisObj in ActivateObjOnClick)
        {
            ThisObj.SetActive(true);
        }
        foreach (GameObject ThisObj in DeactivateObjOnClick)
        {
            ThisObj.SetActive(false);
        }

    }
}
