using UnityEngine;

[CreateAssetMenu(fileName = "IntelItem", menuName = "ScriptableObjects/IntelItem", order = 1)]
public class IntelItem : ScriptableObject
{
    public int ID;
    public string title;
    public string description;
    public string type;
    public Sprite image; // Add a Sprite field for the image
}
