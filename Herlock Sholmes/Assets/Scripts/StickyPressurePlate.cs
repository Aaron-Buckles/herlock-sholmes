using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPressurePlate : MonoBehaviour {

    public GameObject interactableObject;

    private Interactable interactable;


    void Start()
    {
        interactable = interactableObject.GetComponent<Interactable>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Hitbox")
        {
            if (interactable.actionPerformed == false)
            {
                interactable.PerformAction();
            }
            else
            {
                interactable.UnPerformAction();
            }
        }
    }

}
