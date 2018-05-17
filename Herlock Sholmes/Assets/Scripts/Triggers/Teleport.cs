using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : PressurePlate
{

    public GameObject destination;

    GameObject player;

    public override void OnTriggerEnter2D(Collider2D col)
    {
        player = col.gameObject;
        triggered = true;
        player.transform.position = destination.transform.position;
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        triggered = false;
    }
}
