using UnityEngine;

[CreateAssetMenu(fileName = "Message", menuName = "ScriptableObjects/Message", order = 1)]
public class Message : ScriptableObject
{
    public int ID;
    public string Flags;
    public string Subject;
    public string To;
    public string From;
    public string Body;
}
