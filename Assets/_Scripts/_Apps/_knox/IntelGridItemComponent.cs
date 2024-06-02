using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntelGridItemComponent : MonoBehaviour
{
    public TMP_Text intelTitleText;
    public Button openAnalyzerButton;
    public GameObject intelAnalyzerPrefab; // Reference to the intel analyzer prefab

    private IntelItem intelItem;

    public void SetIntelData(IntelItem intel)
    {
        intelItem = intel;
        if (intelTitleText != null)
        {
            intelTitleText.text = intel.title;
        }

        if (openAnalyzerButton != null)
        {
            openAnalyzerButton.onClick.AddListener(OpenAnalyzer);
        }
    }

    private void OpenAnalyzer()
    {
        if (intelItem != null)
        {
            GameObject analyzerWindow = Instantiate(intelAnalyzerPrefab);
            IntelAnalyzerComponent analyzerComponent = analyzerWindow.GetComponent<IntelAnalyzerComponent>();
            if (analyzerComponent != null)
            {
                analyzerComponent.SetIntelData(intelItem);
            }
        }
    }
}
