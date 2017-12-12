using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public Animator animator;

    bool speaking = false;


    public void TestButtonClicked()
    {
        speaking = !speaking;
        UpdateDialoguePanel();
    }

    
    private void UpdateDialoguePanel()
    {
        animator.SetBool("speaking", speaking);
    }
        

}
