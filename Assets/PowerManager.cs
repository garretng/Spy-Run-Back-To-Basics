using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    public int power = 0;
    public Text powerDisplay;

    // Method to be called when the button is pressed
    public void GeneratePower()
    {
        power++;
        UpdatePowerDisplay();
    }

    // Update the power display text
    void UpdatePowerDisplay()
    {
        powerDisplay.text = "Power: " + power;
    }
}
