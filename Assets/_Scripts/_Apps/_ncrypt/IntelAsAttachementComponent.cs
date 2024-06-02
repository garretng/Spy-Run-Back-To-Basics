using UnityEngine;
using TMPro;

public class IntelAsAttachmentComponent : MonoBehaviour
{
    public TMP_Text intelIDText;
    public TMP_Text intelTitleText;
    public TMP_Text intelDescriptionText;

    public void SetIntelData(IntelItem intel)
    {
        if (intel != null)
        {
            intelIDText.text = intel.ID.ToString();
            intelTitleText.text = intel.title;
            intelDescriptionText.text = intel.description;
        }
    }
}
