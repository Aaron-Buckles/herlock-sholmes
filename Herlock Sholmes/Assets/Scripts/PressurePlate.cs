using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject interactableObject;

    private Interactable interactable;


    void Start()
    {
        interactable = interactableObject.GetComponent<Interactable>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Hitbox" && interactable.actionPerformed == false)
        {
            interactable.PerformAction();
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != "Hitbox" && interactable.actionPerformed)
        {
            interactable.UnPerformAction();
        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "Hitbox")
        {
            interactable.PerformAction();
        }
    }

}
