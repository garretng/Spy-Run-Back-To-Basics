using UnityEngine;
using System.Collections.Generic;

public class MessageManager : MonoBehaviour
{
    // List of all message ScriptableObjects in the game
    public List<Message> allMessages = new List<Message>();

    // List of messages in the player's inbox
    public List<Message> playerInbox = new List<Message>();

    void Start()
    {
        // Load all Message ScriptableObjects from the specified folder
        LoadAllMessages();

        // Add the default message with ID 0 to the playerInbox list at the start of the game
        AddMessageToInbox(0);
    }

    // Load all Message ScriptableObjects from the specified folder
    void LoadAllMessages()
    {
        allMessages.AddRange(Resources.LoadAll<Message>("data/scriptableobjects/messagedata/messages"));
        Debug.Log($"Loaded {allMessages.Count} messages from data/scriptableobjects/messagedata/messages folder.");
    }

    // Add a message to the player's inbox by ID
    public void AddMessageToInbox(int id)
    {
        Message messageToAdd = allMessages.Find(message => message.ID == id);
        if (messageToAdd != null)
        {
            playerInbox.Add(messageToAdd);
            Debug.Log($"Message added to inbox: ID = {messageToAdd.ID}, Subject = {messageToAdd.Subject}, From = {messageToAdd.From}");
        }
        else
        {
            Debug.LogError($"Message with ID = {id} not found in all messages");
        }
    }
}
