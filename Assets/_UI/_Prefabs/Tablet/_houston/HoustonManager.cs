using System.Collections.Generic;
using UnityEngine;

public class HoustonManager : MonoBehaviour
{
    public static HoustonManager Instance;

    private List<IntelItem> stagedForMissionBriefCreation = new List<IntelItem>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveIntel(IntelItem intel)
    {
        if (intel != null && !stagedForMissionBriefCreation.Contains(intel))
        {
            stagedForMissionBriefCreation.Add(intel);
            Debug.Log("Intel added for mission brief creation: " + intel.title);
        }
    }

    public List<IntelItem> GetStagedIntel()
    {
        return new List<IntelItem>(stagedForMissionBriefCreation);
    }

    public void ClearStagedIntel()
    {
        stagedForMissionBriefCreation.Clear();
        Debug.Log("Staged intel list cleared.");
    }
}
