using UnityEngine;

public class TabletManager : MonoBehaviour
{
    public Canvas tabletScreen;

    void Start()
    {
        if (tabletScreen == null)
        {
            Debug.LogError("TabletScreen is not assigned!");
        }
    }

    // Method to bring an object to the top of the hierarchy
    public void BringToFront(GameObject obj)
    {
        if (obj.transform.parent != null)
        {
            obj.transform.SetAsLastSibling();
        }
        else
        {
            Debug.LogWarning("The object has no parent to bring it to the front of.");
        }
    }

    // Method to bring a specific object to the top of the hierarchy within the TabletScreen canvas
    public void BringToFrontInTabletScreen(GameObject obj)
    {
        if (tabletScreen == null)
        {
            Debug.LogError("TabletScreen is not assigned!");
            return;
        }

        Transform parentTransform = tabletScreen.transform;
        if (obj.transform.parent == parentTransform)
        {
            obj.transform.SetAsLastSibling();
        }
        else
        {
            Debug.LogWarning("The object is not a child of the TabletScreen canvas.");
        }
    }
}
