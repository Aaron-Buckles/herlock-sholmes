using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPressurePlate : MonoBehaviour {

    public GameObject interactableObject;
    public int timeToWait = 1;

    private Interactable interactable;
    private Collider2D pressurePlateCollider;


    void Start()
    {
        interactable = interactableObject.GetComponent<Interactable>();
        pressurePlateCollider = gameObject.GetComponent<Collider2D>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Hitbox" && interactable.actionPerformed == false)
        {
            pressurePlateCollider.enabled = false;
            interactableObject.GetComponent<Interactable>().PerformAction();

            StopCoroutine(PressurePlateUp());
            StartCoroutine(PressurePlateUp());
        }
    }


    IEnumerator PressurePlateUp()
    {
        yield return new WaitForSeconds(timeToWait);

        interactableObject.GetComponent<Interactable>().UnPerformAction();
        pressurePlateCollider.enabled = true;
    }

}
