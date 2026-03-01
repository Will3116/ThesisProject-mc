using UnityEngine;
//public interface IInteractable
//{
//    void Interact();
//}

public class NPC : MonoBehaviour, F_IInteractable
{
    [SerializeField] SODialogue dialogue;
    public void Interact()
    {
        DialogueManager.Instance.QueueDialogue(dialogue);
    }
}
