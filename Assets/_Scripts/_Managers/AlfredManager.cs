using UnityEngine;
using TMPro;

public class AlfredManager : MonoBehaviour
{
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI bitcoinText;

    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        UpdateHUD();
    }

    private void Update()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
        powerText.text = "Power: " + resourceManager.GetResourceAmount("Power");
        bitcoinText.text = "Bitcoin: " + resourceManager.GetResourceAmount("Bitcoin") + " BTC";
    }

    public void AddPower()
    {
        resourceManager.AddResource("Power", 1);
    }

    public void AddBitcoin()
    {
        resourceManager.AddResource("Bitcoin", 1);
    }
   
}
