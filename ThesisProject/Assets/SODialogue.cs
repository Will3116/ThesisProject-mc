using UnityEngine;

[CreateAssetMenu(fileName = "New_Dialogue", menuName = "SODialogue")]
public class SODialogue : ScriptableObject
{
    public Info[] dialogueInfo;     //"scriptable" game object som håller data (dialogue data)

    [System.Serializable]           //gör så att man kan se info classen i "Inspector"
    public class Info
    {
        [TextArea(4, 8)] public string dialogue;    //gör det enklare att läsa "Inspectorn"
    }
}