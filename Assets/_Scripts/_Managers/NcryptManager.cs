using UnityEngine;
using System.Collections.Generic;

public class NcryptManager : MonoBehaviour
{
    public List<Message> allMessages = new List<Message>(); // List to store all messages
    public List<Message> playerInbox = new List<Message>(); // List to store player inbox messages
    public Transform inboxParentTransform; // Parent transform for the instantiated messages
    public GameObject inboxMessagePrefab; // Reference to the inbox listing prefab
    public GameObject messageWindowPrefab;
    

    void Start()
    {
        LoadAllMessages();
    }

    void LoadAllMessages()
    {
        allMessages.AddRange(Resources.LoadAll<Message>("_data/messagedata/messages"));
        Debug.Log($"Loaded {allMessages.Count} messages from Resources/_data/messagedata/messages folder.");
    }

    public void AddMessageToPlayerInbox(int messageId)
    {
        Message messageToAdd = allMessages.Find(message => message.ID == messageId);
        if (messageToAdd != null && !playerInbox.Contains(messageToAdd))
        {
            playerInbox.Add(messageToAdd);
            Debug.Log($"Message added to player inbox: ID = {messageToAdd.ID}, Subject = {messageToAdd.Subject}, From = {messageToAdd.From}");
            DisplayInboxList();
        }
        else if (messageToAdd == null)
        {
            Debug.LogError($"Message with ID = {messageId} not found in all messages.");
        }
        else
        {
            Debug.LogWarning($"Message with ID = {messageId} already exists in the player inbox.");
        }
    }

    public void DisplayInboxList()
    {
        // Clear previous inbox listings
        foreach (Transform child in inboxParentTransform)
        {
            if (child.name == "inbox_listing_prfb(Clone)")
            {
                Destroy(child.gameObject);
            }
        }

        // Instantiate a prefab for each message in the player inbox
        foreach (Message message in playerInbox)
        {
            GameObject messageInstance = Instantiate(inboxMessagePrefab, inboxParentTransform);
            InboxListing inboxListing = messageInstance.GetComponent<InboxListing>();
            if (inboxListing != null)
            {
                inboxListing.SetMessageData(message);
            }
        }
    }

    public void DisplayMessageWindow(Message message)
    {
        foreach (Transform child in inboxParentTransform)
        {
            if (child.name == "message_window_prfb(Clone)")
            {
                Destroy(child.gameObject);
            }
        }

        GameObject messageInstance = Instantiate(messageWindowPrefab, inboxParentTransform);
        InboxMessageWindow inboxMessageWindow = messageInstance.GetComponent<InboxMessageWindow>();
        if (inboxMessageWindow != null)
        {
            inboxMessageWindow.SetMessageData(message);
            inboxMessageWindow.ncryptManager = this; // Set reference to NcryptManager
        }
    }

    public void CloseWindow(GameObject window)
    {
        Destroy(window);
    }
}
