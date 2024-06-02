using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InboxListing : MonoBehaviour
{
    public TMP_Text idText;
    public TMP_Text flagsText;
    public TMP_Text subjectText;
    public TMP_Text fromText;
    public Button openMessageButton; // Reference to the button to open the message window

    public Transform inboxParentTransform; // Parent transform for the instantiated messages

    private Message currentMessage; // Store the current message

    public void SetMessageData(Message message)
    {
        if (message != null)
        {
            currentMessage = message;
            idText.text = message.ID.ToString();
            flagsText.text = message.Flags; // Set the flags text
            subjectText.text = message.Subject;
            fromText.text = message.From;
        }
    }

    void Start()
    {
        if (openMessageButton != null)
        {
            openMessageButton.onClick.AddListener(OnOpenMessageButtonClicked);
        }
    }

    void OnOpenMessageButtonClicked()
    {
        if (currentMessage != null)
        {
            IntelManager intelManager = FindAnyObjectByType<IntelManager>();
            NcryptManager ncryptManager = FindObjectOfType<NcryptManager>();
            if (ncryptManager != null)
            {
                ncryptManager.DisplayMessageWindow(currentMessage);
                intelManager.DisplayPlayerInboxIntel();
            }
        }
    }
}