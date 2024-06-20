using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
 
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject destoryObject;
    public GameObject activeObjek;
    public GameObject activeObjek2;
    public GameObject activeObjek3;
 
    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            destoryObject.SetActive(false);
            activeObjek.SetActive(true);
            activeObjek2.SetActive(true);
            activeObjek3.SetActive(true);
        }
    }
}