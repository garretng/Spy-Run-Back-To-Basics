using UnityEngine;

[CreateAssetMenu(fileName = "IntelItem", menuName = "ScriptableObjects/IntelItem", order = 1)]
public class IntelItem : ScriptableObject
{
    public int ID;
    public string title;
    public string description;
    public string type;
    public Sprite image; // Existing Sprite field for the image
    public string Rarity; // New field for rarity string
    public Sprite RarityImage; // New field for rarity border image
}
