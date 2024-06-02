using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public IntelManager intelManager; // Reference to the IntelManager
    public NcryptManager ncryptManager; // Reference to the NcryptManager

    void Start()
    {
        // Check for IntelManager setup
        if (intelManager != null)
        {
            Debug.Log("IntelManager assigned correctly.");
            StartCoroutine(AddInitialIntelToPlayerInbox());
        }
        else
        {
            Debug.LogError("IntelManager is not assigned!");
        }

        // Check for NcryptManager setup
        if (ncryptManager != null)
        {
            Debug.Log("NcryptManager assigned correctly.");
            StartCoroutine(AddInitialMessageToPlayerInbox());
        }
        else
        {
            Debug.LogError("NcryptManager is not assigned!");
        }
    }

    IEnumerator AddInitialIntelToPlayerInbox()
    {
        yield return new WaitForSeconds(1); // Wait for 1 second
        Debug.Log("Attempting to add initial intel item with ID 0 to player inbox.");
        intelManager.AddIntelToPlayerInbox(0); // Add intel item with ID 0 to the player inbox
        Debug.Log("Initial intel item added to player inbox after 1 second.");
    }

    IEnumerator AddInitialMessageToPlayerInbox()
    {
        yield return new WaitForSeconds(1); // Wait for 1 second
        Debug.Log("Attempting to add initial message with ID 0 to player inbox.");
        ncryptManager.AddMessageToPlayerInbox(0); // Adds the message with ID 0 to the player inbox
        Debug.Log("Initial message added to player inbox after 1 second.");
    }
}
