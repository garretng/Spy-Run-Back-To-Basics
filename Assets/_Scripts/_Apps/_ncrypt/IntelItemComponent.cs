using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntelItemComponent : MonoBehaviour
{
    public TMP_Text intelIDText;
    public TMP_Text intelTitleText;
    public TMP_Text intelDescriptionText;
    public Image intelImage; // Image field for the intel image
    public Button saveButton; // Button field for saving the intel item
    public Button analyzeButton; // Button field for analyzing the intel item

    private IntelItem intelItem;

    private void Start()
    {
        if (transform.parent != null && transform.parent.name == "message_window_prfb(Clone)")
        {
            if (saveButton != null)
            {
                saveButton.onClick.AddListener(SaveIntelItem);
                Debug.Log("Save button listener added in Start.");
            }
            else
            {
                Debug.LogError("Save button is not assigned.");
            }
        }

        if (transform.parent != null && transform.parent.name == "pnl_gridlayout_intel_collection_window")
        {
            if (analyzeButton != null)
            {
                analyzeButton.onClick.AddListener(AnalyzeIntelItem);
                Debug.Log("Analyze button listener added in Start.");
            }
            else
            {
                Debug.LogError("Analyze button is not assigned.");
            }
        }
    }

    private void OnDisable()
    {
        if (saveButton != null)
        {
            saveButton.onClick.RemoveListener(SaveIntelItem);
        }

        if (analyzeButton != null)
        {
            analyzeButton.onClick.RemoveListener(AnalyzeIntelItem);
        }
    }

    public void SetIntelData(IntelItem intel)
    {
        if (intel == null)
        {
            Debug.LogError("SetIntelData received a null IntelItem.");
            return;
        }

        intelItem = intel;
        Debug.Log($"Setting intel data: ID = {intel.ID}, Title = {intel.title}");

        if (intelIDText != null)
        {
            intelIDText.text = intel.ID.ToString();
        }
        if (intelTitleText != null)
        {
            intelTitleText.text = intel.title;
        }
        if (intelDescriptionText != null)
        {
            intelDescriptionText.text = intel.description;
        }
        if (intelImage != null)
        {
            intelImage.sprite = intel.image;
        }
    }

    public void SaveIntelItem()
    {
        if (intelItem != null)
        {
            IntelManager.Instance.CollectIntelFromInbox(intelItem.ID);
            Debug.Log($"Intel item with ID {intelItem.ID} has been saved.");
            Debug.Log("Save button was pressed.");
        }
        else
        {
            Debug.LogError("Intel item is null.");
        }
    }

    public void AnalyzeIntelItem()
    {
        if (intelItem != null)
        {
            IntelManager.Instance.OpenAnalyzeIntelWindow(intelItem);
            Debug.Log($"Analyzing intel item with ID {intelItem.ID}.");
        }
        else
        {
            Debug.LogError("Intel item is null.");
        }
    }
}
