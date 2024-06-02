using UnityEngine;
using TMPro;
using System.Collections;

public class BitcoinMiner : MonoBehaviour
{
    public TextMeshProUGUI statusText;  // Reference to a TMP text element to show the status
    private bool isMining = false;      // Track whether the miner is on or off
    private ResourceManager resourceManager;  // Reference to the ResourceManager
    public float miningInterval = 7f;  // Interval in seconds to add Bitcoin

    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        UpdateStatusText();
    }

    public void ToggleMining()
    {
        isMining = !isMining;
        UpdateStatusText();

        if (isMining)
        {
            StartCoroutine(MineBitcoin());
            Debug.Log("Bitcoin mining started.");
        }
        else
        {
            StopCoroutine(MineBitcoin());
            Debug.Log("Bitcoin mining stopped.");
        }
    }

    private IEnumerator MineBitcoin()
    {
        yield return new WaitForSeconds(miningInterval);  // Initial delay before mining starts

        while (isMining)
        {
            resourceManager.AddResource("Bitcoin", 1);
            Debug.Log("1 Bitcoin mined.");
            yield return new WaitForSeconds(miningInterval);
        }
    }

    private void UpdateStatusText()
    {
        statusText.text = isMining ? "Mining: ON" : "Mining: OFF";
    }
}
