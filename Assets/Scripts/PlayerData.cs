using UnityEngine;

// Add an entry to the Assets menu for creating an asset of this type
[CreateAssetMenu(menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : SingletonScriptableObject<PlayerData> {
    public int maximumPlayerHealth;
    public int startingLives;
}