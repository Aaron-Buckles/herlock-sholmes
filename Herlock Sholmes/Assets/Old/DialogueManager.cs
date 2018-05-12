using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public Animator animator;
    public string dialogueFileName;
    public string firstScene;
    [Space]
    public TMP_Text speakerNameText;
    public TMP_Text dialogueText;

    bool speaking = false;
    JsonData dialogueData;

    JsonData currentScene;
    int currentLine;


    void Awake()
    {
        dialogueData = LoadDialogueScenes(dialogueFileName);
    }


    void Start()
    {
        StartDialogueScene(firstScene);    
    }


    private JsonData LoadDialogueScenes(string fileName)
    {
        string filePath = "Dialogue/" + fileName.Replace(".json", "");
        string data = Resources.Load<TextAsset>(filePath).text;
        return JsonMapper.ToObject(data);
    }


    public void ShowNextLine()
    {
        currentLine += 1;

        try
        {
            speakerNameText.text = (string)currentScene["dialogue"][currentLine]["name"];
            dialogueText.text = (string)currentScene["dialogue"][currentLine]["line"];
        }
        catch (System.ArgumentOutOfRangeException)
        {
            speaking = false;
            UpdateDialoguePanel();
        }
    }


    public void StartDialogueScene(string sceneName)
    {
        if (dialogueData != null)
        {
            currentScene = FindScene(sceneName);
            currentLine = -1;
            ShowNextLine();

            speaking = true;
            UpdateDialoguePanel();
        }
        else
        {
            Debug.LogWarning("dialogueData is null");
        }
    }


    private JsonData FindScene(string sceneName)
    {
        foreach(JsonData scene in dialogueData)
        {
            if((string)scene["sceneName"] == sceneName)
            {
                return scene;
            }
        }

        Debug.LogWarning(sceneName + " was not found");
        return null;
    }


    public void TestButtonClicked()
    {
        StartDialogueScene("test1");
    }

    
    private void UpdateDialoguePanel()
    {
        animator.SetBool("speaking", speaking);
    }
        

}