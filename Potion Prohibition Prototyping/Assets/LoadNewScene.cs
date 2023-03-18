using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public int SceneIndex;

    public void LoadNewSceneFunc()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
