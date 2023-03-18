using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject ItemBeingDragged;
    public Camera camera;
    public Vector3 DraggedItemOffset;

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 rayOrigin = camera.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(rayOrigin, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                GameObject selectedObject = hit.collider.gameObject;

                if (selectedObject.CompareTag("Item"))
                {
                    ItemBeingDragged = selectedObject;
                }
                if (selectedObject.CompareTag("BrewButton"))
                {
                    BrewManager brewManager = selectedObject.GetComponent<BrewManager>();
                    if(brewManager.IsBrewing == false)
                    {
                        brewManager.BrewFunction();
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ItemBeingDragged = null;
        }

        if(ItemBeingDragged != null)
        {
            ItemBeingDragged.transform.position = camera.ScreenToWorldPoint(Input.mousePosition) + DraggedItemOffset;
        }
    }
}
