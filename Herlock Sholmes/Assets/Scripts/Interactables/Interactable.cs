using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public Trigger[] triggerObjects;

    void Update()
    {
        CheckTriggers();
    }

    void CheckTriggers()
    {
        foreach ( Trigger trigger in triggerObjects )
        {
            if ( trigger.triggered )
            {
                PerformAction();
                return;
            }
        }

        UnPerformAction();
    }

	public virtual void PerformAction()
    {
    }

    public virtual void UnPerformAction()
    {
    }
}
