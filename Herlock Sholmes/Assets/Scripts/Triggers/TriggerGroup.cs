using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGroup : Trigger
{

    public Trigger[] triggers;

    void Update()
    {
        triggered = AllTriggered();
    }

    bool AllTriggered()
    {
        foreach (Trigger trigger in triggers)
        {
            if (trigger.triggered == false)
            {
                return false;
            }
        }
        return true;
    }
}
