using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour {

    public GameObject[] triggerObjects;
    public string optionalArgument;


    void Update()
    {
        CheckTriggers();
    }


    private void CheckTriggers()
    {
        foreach (GameObject trigger in triggerObjects)
        {
            if (trigger.GetComponent<Trigger>().triggered)
            {
                PerformAction();
                return;
            }
        }

        UnPerformAction();
    }


	public void PerformAction()
    {
        if (gameObject.tag == "Door")
        {
            OpenDoor();
        }
        else if (gameObject.tag == "DialogueManager")
        {
            StartDialogue();
        }
        else if (gameObject.tag == "NextLevel")
        {
            NextLevel();
        }
    }


    public void UnPerformAction()
    {
        if (gameObject.tag == "Door")
        {
            CloseDoor();
        }
    }


    private void NextLevel()
    {
        SceneManager.LoadScene(optionalArgument);
    }


    private void StartDialogue()
    {
        DialogueManager dm = gameObject.GetComponent<DialogueManager>();
        dm.StartDialogueScene(optionalArgument);
    }


    private void OpenDoor()
    {
        Collider2D doorCollider = gameObject.GetComponent<Collider2D>();
        SpriteRenderer doorSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        doorCollider.isTrigger = true;
        doorSpriteRender.enabled = false;
    }


    private void CloseDoor()
    {
        Collider2D doorCollider = gameObject.GetComponent<Collider2D>();
        SpriteRenderer doorSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        doorCollider.isTrigger = false;
        doorSpriteRender.enabled = true;
    }

}
