using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCIntractable : MonoBehaviour
{
    public GameObject speechPrompt;
    public GameObject questBubble;
    public DialogueRunner runner;
    public string startNode;
    public bool canStartConversation;

    // Start is called before the first frame update
    void Start()
    {
        runner = FindAnyObjectByType<DialogueRunner>();
        speechPrompt.SetActive(false);
        questBubble.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!runner.IsDialogueRunning && canStartConversation)
            {
                runner.StartDialogue(startNode);
                questBubble.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAreaTrigger player = collision.GetComponent<PlayerAreaTrigger>();
        if (player != null)
        {
            canStartConversation = true;
            speechPrompt.SetActive(canStartConversation);
            questBubble.SetActive(false);



        }
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerAreaTrigger player = collision.GetComponent<PlayerAreaTrigger>();
        if (player != null)
        {
            canStartConversation = false;
            speechPrompt.SetActive(canStartConversation);
            questBubble.SetActive(false);
            runner.Stop();
        }

    }
}
