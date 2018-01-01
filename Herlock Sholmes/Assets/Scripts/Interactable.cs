using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public GameObject[] triggerObjects;


    void Update()
    {
        CheckTriggers();
    }


    private void CheckTriggers()
    {
        foreach (GameObject trigger in triggerObjects)
        {
            if (trigger.tag == "PressurePlate")
            {
                if (trigger.GetComponent<PressurePlate>().triggered)
                {
                    PerformAction();
                    return;
                }
            }
        }

        UnPerformAction();
    }


	public void PerformAction()
    {
        if(gameObject.tag == "Door")
        {
            OpenDoor();
        }
    }


    public void UnPerformAction()
    {
        if (gameObject.tag == "Door")
        {
            CloseDoor();
        }
    }


    private void OpenDoor()
    {
        Collider2D doorCollider = gameObject.GetComponent<Collider2D>();
        SpriteRenderer doorSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        doorCollider.isTrigger = true;
        doorSpriteRender.enabled = false;
    }


    private void CloseDoor()
    {
        Collider2D doorCollider = gameObject.GetComponent<Collider2D>();
        SpriteRenderer doorSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        doorCollider.isTrigger = false;
        doorSpriteRender.enabled = true;
    }

}
