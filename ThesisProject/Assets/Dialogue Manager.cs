using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private bool inDialogue;
    private bool typingDialogue;

    private Queue<SODialogue.Info> dialogueQueue;

    private string completelDialogue;

    [SerializeField] private float textDelay;

    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialogueBox;


    public void QueueDialogue(SODialogue dialogue)      //börjar dialogye queue (rader/ linjer av text skrivs en i taget (float textDelay) och rittas i dialogue boxen en i taget) !!! SKRIV VIDARE HÄR IMORGON !!!
    {
        if (inDialogue)
        {
            return;
        }
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        inDialogue = true;
        dialogueBox.SetActive(true);
        dialogueQueue.Clear();
        foreach (SODialogue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }
    private void DequeueDialogue()
    {
        if (typingDialogue)
        {
            CompleteText();
            StopAllCoroutines();
            typingDialogue = false;
            return;
        }
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        SODialogue.Info info = dialogueQueue.Dequeue();
        completelDialogue = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    private void OnInteract()       //när playern interaktar (t.ex, trycker "e", så körs "OnInteract" och om playern är i Dialogye, dequeue dialogue (skippar dialogue's typing och visar direkt hela texten)
    {
        if (inDialogue)
        {
            DequeueDialogue();
        }
    }

    private void CompleteText()     //metod för att "completar" texten som skrivs i dialogue boxen (t.ex när player trycker "e" så skippar den direkt dialogue delayen och visar hela texten i dialogue box)
    {
        dialogueText.text = completelDialogue;
    }

    private void EndDialogue()                          //slutar dialogue och gömmer dialogue box. Ger Players tillbaka deras inputs (movements)
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }

    private IEnumerator TypeText(SODialogue.Info info)  //loopar genom alla bokstäverna i dialogue och förvandla dem till .ToCharArray och sen lägger till delay mellan varje bokstav (typing dialogue onto dialogue box)
    {
        typingDialogue = true;
        foreach (char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += c;
        }
        typingDialogue = false;
    }
}
