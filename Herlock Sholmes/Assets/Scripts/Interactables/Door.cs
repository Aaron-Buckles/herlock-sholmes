using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    public override void PerformAction()
    {
        Collider2D doorCollider = gameObject.GetComponent<Collider2D>();
        SpriteRenderer doorSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        doorCollider.isTrigger = true;
        doorSpriteRender.enabled = false;
    }

    public override void UnPerformAction()
    {
        Collider2D doorCollider = gameObject.GetComponent<Collider2D>();
        SpriteRenderer doorSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        doorCollider.isTrigger = false;
        doorSpriteRender.enabled = true;
    }
}
