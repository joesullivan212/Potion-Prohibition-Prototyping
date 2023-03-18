using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{

    [Header("Variables")]
    public string[] TagsToCheck;
    public bool UseCollisionAlso = false;

    [Header("Debug")]
    public List<GameObject> EntitiesInTrigger = new List<GameObject>();


    private void OnTriggerStay2D(Collider2D collision)
    {
        // Add Entity to the list of enemies in sight
        if (!EntitiesInTrigger.Contains(collision.gameObject))
        {
            foreach (string TagToCheck in TagsToCheck)
            {
                if (collision.gameObject.CompareTag(TagToCheck))
                {
                    EntitiesInTrigger.Add(collision.gameObject);
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //Remove Entity from list
        EntitiesInTrigger.Remove(collision.gameObject);
    }

    //If use collision Also
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (UseCollisionAlso)
        {
            if (!EntitiesInTrigger.Contains(collision.gameObject))
            {
                foreach (string TagToCheck in TagsToCheck)
                {
                    if (collision.gameObject.CompareTag(TagToCheck))
                    {
                        EntitiesInTrigger.Add(collision.gameObject);
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (UseCollisionAlso)
        {
            //Remove Entity from list
            EntitiesInTrigger.Remove(collision.gameObject);
        }
    }



    private void OnDisable()
    {
        //Stoped aiming, clear the feild
        EntitiesInTrigger.Clear();
    }
}
