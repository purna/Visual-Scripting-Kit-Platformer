using UnityEngine;

[CreateAssetMenu(menuName = "Game/Cutscene/Character")]
public class CharacterSO : ScriptableObject
{
    public string characterName; // Name of the character
    public Sprite characterImage; // Optional portrait or icon for the character

    // Implicitly return the characterName when a CharacterSO is treated as a string
    public static implicit operator string(CharacterSO character)
    {
        return character.characterName;
    }

      // Implicitly return the characterImage when a CharacterSO is treated as a Sprite
    public static implicit operator Sprite(CharacterSO character)
    {
        return character.characterImage;
    }
}