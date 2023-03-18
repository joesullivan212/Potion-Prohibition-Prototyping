using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRound : MonoBehaviour
{
    public GatheringManager gatheringManager;
    public GameObject SuccessWindow;

    public void NextRoundFunc()
    {
        gatheringManager.NextRound();
        SuccessWindow.SetActive(false);
    }
}
