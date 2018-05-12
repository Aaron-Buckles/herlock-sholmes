using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPlate : Trigger {

    static int playersStandingOn;
    int playersStandingOnMe;

    int playersRequired = 2;
    Collider2D pressurePlateCollider;

    void Awake()
    {
        playersStandingOn = 0;
        playersStandingOnMe = 0;

        pressurePlateCollider = gameObject.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        playersStandingOn++;
        playersStandingOnMe++;

        if ( playersStandingOn >= playersRequired && playersStandingOnMe <= 1 )
        {
            triggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playersStandingOn--;
        playersStandingOnMe--;
    }

}
