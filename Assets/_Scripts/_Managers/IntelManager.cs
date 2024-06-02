using UnityEngine;
using System.Collections.Generic;

public class IntelManager : MonoBehaviour
{
    public static IntelManager Instance { get; private set; }

    public List<IntelItem> allIntel = new List<IntelItem>(); // All intel items available in the game
    public List<IntelItem> collectedIntel = new List<IntelItem>(); // Intel items collected by the player
    private List<IntelItem> playerIntelInbox = new List<IntelItem>(); // Intel items in the player's inbox

    public Transform intelGridParent; // Parent transform for the intel grid items
    public GameObject intelGridItemPrefab; // Prefab for displaying collected intel in the grid
    public GameObject intelAnalyzerPrefab; // Prefab for the intel analyzer window
    public GameObject intelAsAttachmentPrefab; // Prefab for displaying intel as an attachment in the inbox
    public Transform savedIntelCollectionWindow; // Parent transform for the analyze intel window

    private List<IntelItem> previousIntelList = new List<IntelItem>(); // To track changes in the intel list

    private GameObject analyzeIntelWindow; // Reference to the analyze intel window instance

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this GameObject persists across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        LoadAllIntel();
        UpdateIntelGrid(GetCollectedIntel());
    }

    void Update()
    {
        // Check for changes in the collected intel list
        List<IntelItem> currentIntelList = GetCollectedIntel();
        if (!AreListsEqual(previousIntelList, currentIntelList))
        {
            UpdateIntelGrid(currentIntelList);
            previousIntelList = new List<IntelItem>(currentIntelList);
        }
    }

    void LoadAllIntel()
    {
        allIntel.AddRange(Resources.LoadAll<IntelItem>("_data/inteldata"));
        Debug.Log($"Loaded {allIntel.Count} intel items from Resources/_data/inteldata folder.");
    }

    public void AddIntelToPlayerInbox(int intelID)
    {
        IntelItem intelToAdd = allIntel.Find(intel => intel.ID == intelID);
        if (intelToAdd != null && !playerIntelInbox.Contains(intelToAdd))
        {
            playerIntelInbox.Add(intelToAdd);
            Debug.Log($"Intel added to player inbox: ID = {intelToAdd.ID}, Title = {intelToAdd.title}");
        }
        else if (intelToAdd == null)
        {
            Debug.LogError($"Intel with ID = {intelID} not found in all intel.");
        }
        else
        {
            Debug.LogWarning($"Intel with ID = {intelID} already in the inbox.");
        }
    }

    public void DisplayPlayerInboxIntel()
    {
        GameObject intelInboxParent = GameObject.Find("message_attachments_prfb");
        if (intelInboxParent != null)
        {
            Transform intelInboxParentTransform = intelInboxParent.transform;

            // Clear previous inbox listings
            foreach (Transform child in intelInboxParentTransform)
            {
                Destroy(child.gameObject);
            }

            // Instantiate a prefab for each intel item in the player inbox
            foreach (IntelItem intel in playerIntelInbox)
            {
                GameObject intelInstance = Instantiate(intelAsAttachmentPrefab, intelInboxParentTransform);
                IntelItemComponent intelItemComponent = intelInstance.GetComponent<IntelItemComponent>();
                if (intelItemComponent != null)
                {
                    intelItemComponent.SetIntelData(intel);
                }
                else
                {
                    Debug.LogError("IntelItemComponent not found on instantiated prefab.");
                }
            }
        }
        else
        {
            Debug.LogError("Intel inbox parent GameObject 'message_attachments_prfb' not found.");
        }
    }

    public void CollectIntelFromInbox(int intelID)
    {
        IntelItem intelToCollect = playerIntelInbox.Find(intel => intel.ID == intelID);
        if (intelToCollect != null && !collectedIntel.Contains(intelToCollect))
        {
            collectedIntel.Add(intelToCollect);
            playerIntelInbox.Remove(intelToCollect);
            Debug.Log($"Intel collected from inbox: ID = {intelToCollect.ID}, Title = {intelToCollect.title}");
        }
        else if (intelToCollect == null)
        {
            Debug.LogError($"Intel with ID = {intelID} not found in inbox.");
        }
        else
        {
            Debug.LogWarning($"Intel with ID = {intelID} already collected.");
        }
    }

    public IntelItem GetIntelItemById(int intelID)
    {
        return allIntel.Find(intel => intel.ID == intelID);
    }

    public List<IntelItem> GetCollectedIntel()
    {
        return new List<IntelItem>(collectedIntel);
    }

    public List<IntelItem> GetPlayerIntelInbox()
    {
        return new List<IntelItem>(playerIntelInbox);
    }

    public void OpenAnalyzeIntelWindow(IntelItem intel)
    {
        if (analyzeIntelWindow == null)
        {
            analyzeIntelWindow = Instantiate(intelAnalyzerPrefab, savedIntelCollectionWindow);
        }

        IntelAnalyzerComponent analyzerComponent = analyzeIntelWindow.GetComponent<IntelAnalyzerComponent>();
        if (analyzerComponent != null)
        {
            analyzerComponent.SetIntelData(intel);
            analyzeIntelWindow.SetActive(true);
            analyzeIntelWindow.transform.SetAsLastSibling(); // Bring the analyze intel window to the front
            Debug.Log($"Analyze intel window opened for intel ID {intel.ID}.");
        }
        else
        {
            Debug.LogError("IntelAnalyzerComponent not found on analyze intel window prefab.");
        }
    }

    private void UpdateIntelGrid(List<IntelItem> intelList)
    {
        // Clear existing grid items
        foreach (Transform child in intelGridParent)
        {
            Destroy(child.gameObject);
        }

        // Populate the grid with the updated intel list
        foreach (IntelItem intel in intelList)
        {
            GameObject intelGridItem = Instantiate(intelGridItemPrefab, intelGridParent);
            IntelItemComponent intelItemComponent = intelGridItem.GetComponent<IntelItemComponent>();
            if (intelItemComponent != null)
            {
                intelItemComponent.SetIntelData(intel);
                // Add any additional setup for the intel grid item here
            }
        }
    }

    private bool AreListsEqual(List<IntelItem> list1, List<IntelItem> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }
        return true;
    }

    public void CloseWindow(GameObject window)
    {
        Destroy(window);
    }
}
