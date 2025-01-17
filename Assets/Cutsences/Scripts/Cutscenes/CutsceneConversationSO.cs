using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Conversation")]
public class CutsceneConversationSO : ScriptableObject
{
    [HideInInspector]
    public List<string> charactersList = new List<string>(); // Automatically populated and hidden from the Inspector

    public List<CharacterSO> characters = new List<CharacterSO>(); // Character scriptable objects

    public List<DialogueItem> dialogueList = new List<DialogueItem>();

    [System.Serializable]
    public class DialogueItem
    {
        [CharacterDropdown] // Custom dropdown for selecting a character
        public int charactersListIndex = -1;

        [TextArea(2, 3)]
        public string dialogue; // Dialogue text

        public AudioClip dialogueSound; // Optional sound for the dialogue
        public float delayAfterDialogue = 1.0f; // Delay before the next dialogue

        
    }

    private void OnValidate()
    {
        // Synchronize charactersList with characters
        charactersList.Clear();
        foreach (var character in characters)
        {
            charactersList.Add(character != null ? character.characterName : "Unnamed Character");
        }

    }
}


  

 