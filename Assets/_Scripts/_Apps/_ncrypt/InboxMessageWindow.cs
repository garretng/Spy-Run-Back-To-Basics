using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InboxMessageWindow : MonoBehaviour
{
    public TMP_Text idText;
    public TMP_Text flagsText; // Add reference to the flags text
    public TMP_Text subjectText;
    public TMP_Text fromText;
    public TMP_Text bodyText;
    public Button closeButton; // Add reference to the close button

    [HideInInspector]
    public NcryptManager ncryptManager; // Reference to NcryptManager

    void Start()
    {
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseWindow);
        }
    }

    public void SetMessageData(Message message)
    {
        if (message != null)
        {
            idText.text = "Message ID: " + message.ID.ToString();
            flagsText.text = "Flags: " + message.Flags; // Set the flags text
            subjectText.text = "Subject: " + message.Subject;
            fromText.text = "From: " + message.From;
            bodyText.text = message.Body;
        }
    }

    void CloseWindow()
    {
        if (ncryptManager != null)
        {
            ncryptManager.CloseWindow(gameObject);
        }
    }
}
