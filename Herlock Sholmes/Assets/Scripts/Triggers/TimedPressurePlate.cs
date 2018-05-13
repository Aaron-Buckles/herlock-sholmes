using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPressurePlate : PressurePlate
{

    public float time;

    public override void OnTriggerEnter2D(Collider2D col)
    {
        TimedEnter(col);
    }

    void TimedEnter(Collider2D col)
    {
        pressurePlateCollider.enabled = false;
        triggered = true;

        StopCoroutine(Timer());
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);

        triggered = false;
        pressurePlateCollider.enabled = true;
    }

}
