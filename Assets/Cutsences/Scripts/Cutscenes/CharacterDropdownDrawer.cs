using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CutsceneConversationSO.DialogueItem))]
public class CharacterDropdownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Calculate rects for each field
        Rect characterFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        Rect dialogueFieldRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, position.width, EditorGUIUtility.singleLineHeight * 3);
        Rect soundFieldRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 4 + 6, position.width, EditorGUIUtility.singleLineHeight);
        Rect delayFieldRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 5 + 8, position.width, EditorGUIUtility.singleLineHeight);

        // Get the parent object (CutsceneConversationSO)
        var parent = property.serializedObject.targetObject as CutsceneConversationSO;

        if (parent == null)
        {
            EditorGUI.PropertyField(position, property, label);
            return;
        }

        // Draw dropdown for character selection
        var characterIndexProp = property.FindPropertyRelative("charactersListIndex");
        var charactersList = parent.charactersList;

        if (charactersList.Count > 0)
        {
            // Clamp index to valid range
            characterIndexProp.intValue = Mathf.Clamp(characterIndexProp.intValue, 0, charactersList.Count - 1);

            // Show dropdown
            characterIndexProp.intValue = EditorGUI.Popup(
                characterFieldRect,
                "Character",
                characterIndexProp.intValue,
                charactersList.ToArray()
            );
        }
        else
        {
            EditorGUI.LabelField(characterFieldRect, "Character", "No characters available");
        }

        // Draw remaining fields
        EditorGUI.PropertyField(dialogueFieldRect, property.FindPropertyRelative("dialogue"), new GUIContent("Dialogue"));
        EditorGUI.PropertyField(soundFieldRect, property.FindPropertyRelative("dialogueSound"), new GUIContent("Dialogue Sound"));
        EditorGUI.PropertyField(delayFieldRect, property.FindPropertyRelative("delayAfterDialogue"), new GUIContent("Delay After Dialogue"));

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Adjust height to fit all fields
        return EditorGUIUtility.singleLineHeight * 6 + 10;
    }
}
