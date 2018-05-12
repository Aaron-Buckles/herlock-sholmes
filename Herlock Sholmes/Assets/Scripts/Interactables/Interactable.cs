using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public GameObject[] triggerObjects;

    void Update()
    {
        CheckTriggers();
    }

    void CheckTriggers()
    {
        foreach ( GameObject trigger in triggerObjects )
        {
            if ( trigger.GetComponent<Trigger>().triggered )
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
