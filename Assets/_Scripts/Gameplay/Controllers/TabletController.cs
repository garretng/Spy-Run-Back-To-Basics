using UnityEngine;

public class TabletController : MonoBehaviour
{
    public Canvas tabletScreen;
    public GameObject pnlAlfred;
    public GameObject pnlNcrypt;
    public GameObject pnlKnox;

    void Start()
    {
        if (tabletScreen == null)
        {
            Debug.LogError("TabletScreen is not assigned!");
        }

        if (pnlAlfred == null || pnlNcrypt == null || pnlKnox == null)
        {
            Debug.LogError("One or more panels are not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BringPanelToFront(pnlAlfred);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            BringPanelToFront(pnlNcrypt);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            BringPanelToFront(pnlKnox);
        }
    }

    void BringPanelToFront(GameObject panel)
    {
        if (panel != null)
        {
            panel.transform.SetAsLastSibling();
            Debug.Log($"Panel {panel.name} brought to front.");
        }
        else
        {
            Debug.LogError("Panel reference is null.");
        }
    }
}
