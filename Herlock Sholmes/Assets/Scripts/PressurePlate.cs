using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject interactableObject;

	void OnTriggerEnter2D(Collider2D col)
    {
        interactableObject.GetComponent<Interactable>().PerformAction();
    }

}
