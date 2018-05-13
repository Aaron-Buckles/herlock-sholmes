using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PressurePlate : Trigger {

    protected Collider2D pressurePlateCollider;

    void Awake()
    {
        pressurePlateCollider = gameObject.GetComponent<Collider2D>();
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
    }

    public virtual void OnTriggerExit2D(Collider2D col)
    {
    }
}
