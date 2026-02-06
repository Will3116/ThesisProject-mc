using UnityEngine;

[CreateAssetMenu(fileName = "new_Dialogue", menuName = "Dialogue")]
public class SODialogue : ScriptableObject
{
    public Info[] dialogueInfo;

    [System.Serializable]
    public class Info
    {
        [TextArea(4, 8)] public string dialogue;
    }
}