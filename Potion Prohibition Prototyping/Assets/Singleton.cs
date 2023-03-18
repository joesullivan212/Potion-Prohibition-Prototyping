using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public string TagName;
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag(TagName) == null)
        {
            gameObject.tag = TagName;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
