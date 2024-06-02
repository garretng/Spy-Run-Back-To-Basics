using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntelAnalyzerComponent : MonoBehaviour
{
    public TMP_Text intelIDText;
    public TMP_Text intelTitleText;
    public TMP_Text intelDescriptionText;
    public TMP_Text intelTypeText;
    public Image intelImage;

    public Button revealIDButton;
    public Button revealTitleButton;
    public Button revealDescriptionButton;
    public Button revealTypeButton;
    public Button revealImageButton;
    public Button closeButton; // Button to close the analyze window

    private IntelItem intelItem;

    public void SetIntelData(IntelItem intel)
    {
        intelItem = intel;

        // Initially hide all intel information
        intelIDText.text = "Hidden";
        intelTitleText.text = "Hidden";
        intelDescriptionText.text = "Hidden";
        intelTypeText.text = "Hidden";
        intelImage.enabled = false;

        if (revealIDButton != null)
        {
            revealIDButton.onClick.AddListener(RevealID);
        }
        if (revealTitleButton != null)
        {
            revealTitleButton.onClick.AddListener(RevealTitle);
        }
        if (revealDescriptionButton != null)
        {
            revealDescriptionButton.onClick.AddListener(RevealDescription);
        }
        if (revealTypeButton != null)
        {
            revealTypeButton.onClick.AddListener(RevealType);
        }
        if (revealImageButton != null)
        {
            revealImageButton.onClick.AddListener(RevealImage);
        }
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseWindow);
        }
    }

    public void RevealID()
    {
        if (intelItem != null)
        {
            intelIDText.text = intelItem.ID.ToString();
        }
    }

    public void RevealTitle()
    {
        if (intelItem != null)
        {
            intelTitleText.text = intelItem.title;
        }
    }

    public void RevealDescription()
    {
        if (intelItem != null)
        {
            intelDescriptionText.text = intelItem.description;
        }
    }

    public void RevealType()
    {
        if (intelItem != null)
        {
            intelTypeText.text = intelItem.type;
        }
    }

    public void RevealImage()
    {
        if (intelItem != null)
        {
            intelTypeText.text = intelItem.type;
        }
        if (intelImage != null)
        {
            intelImage.sprite = intelItem.image;
            intelImage.enabled = true;
        }
    }

    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}
