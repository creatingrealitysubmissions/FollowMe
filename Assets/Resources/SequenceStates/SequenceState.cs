using UnityEngine;

// Add an entry to the Assets menu for creating an asset of this type
[CreateAssetMenu(menuName = "ScriptableObjects/SequenceState")]
public class SequenceState : ScriptableObject {
    public AudioClip successClip;
    public AudioClip failClip;
}