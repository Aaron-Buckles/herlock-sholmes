using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPressurePlate : PressurePlate
{

    public override void OnTriggerEnter2D(Collider2D col)
    {
        StickyEnter(col);
    }

    void StickyEnter(Collider2D col)
    {
        triggered = !triggered;
    }
}
