using UnityEngine;
using System.Collections.Generic;

public class NPC : MonoBehaviour, F_IInteractable
{
    //[SerializeField] SODialogue dialogue; //Replacar detta med "Challange Yourself" delen av tutorial. List av Dialogues istället för en enkel dialogue per npc
    [SerializeField] private List<SODialogue> dialogues;

    private int lastIndex = -1;     //ny, "Challange Yourself", för att undvika repetition av samma dialogue

    public void Interact()
    {
        if (dialogues == null || dialogues.Count == 0)  //ny, "Challange Yourself", om dialogues är null eller det inte finns några dialogues (count == 0), inget händer
        {
            return;
        }

        int randomIndex;                                                //ny, "Challange Yourself", int för random index nummer

        do                                                              //ny, "Challange Yourself", Do-While loop för att välja random dialogue med "randomIndex" int
        {
            randomIndex = Random.Range(0, dialogues.Count);             //ny, "Challange Yourself", randomIndex == en Random mellan 0 (index 1) och mängden av dialogues i List
        }
        while (dialogues.Count > 1 && randomIndex == lastIndex);        //ny, "Challange Yourself", fortsätter "while" mängden av dialogues är större än 1 och randomIndex = lastIndex

        lastIndex = randomIndex;                                        //ny, "Challange Yourself", int för förra index från randomIndex nummer

        DialogueManager.Instance.QueueDialogue(dialogues[randomIndex]); //ny, "Challange Yourself", väljer en random dialogue från "randomIndex"

        //DialogueManager.Instance.QueueDialogue(dialogue); //Replacar detta med "Challange Yourself" delen av tutorial. List av Dialogues istället för en enkel dialogue per npc
    }
}
