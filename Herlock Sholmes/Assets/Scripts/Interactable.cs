using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public void PerformAction()
    {
        if(gameObject.tag == "Door")
        {
            Collider2D doorCollider = gameObject.GetComponent<Collider2D>();
            SpriteRenderer doorSpriteRender = gameObject.GetComponent<SpriteRenderer>();
            bool doorOpen = doorCollider.isTrigger;

            if (doorOpen)
            {
                doorCollider.isTrigger = false;
                doorSpriteRender.enabled = true;
            }
            else
            {
                doorCollider.isTrigger = true;
                doorSpriteRender.enabled = false;
            }
        }
    }

}
