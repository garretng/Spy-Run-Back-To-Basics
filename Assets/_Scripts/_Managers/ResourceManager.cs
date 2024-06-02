using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public ResourceData[] resources;

    private void Start()
    {
        InitializeResources();
    }

    public void AddResource(string resourceName, int amount)
    {
        ResourceData resource = GetResource(resourceName);
        if (resource != null)
        {
            resource.amount += amount;
            Debug.Log(resourceName + " updated. New amount: " + resource.amount);
        }
    }

    public int GetResourceAmount(string resourceName)
    {
        ResourceData resource = GetResource(resourceName);
        return resource != null ? resource.amount : 0;
    }

    private ResourceData GetResource(string resourceName)
    {
        foreach (ResourceData resource in resources)
        {
            if (resource.resourceName == resourceName)
            {
                return resource;
            }
        }
        Debug.LogWarning("Resource " + resourceName + " not found!");
        return null;
    }

    private void InitializeResources()
    {
        foreach (ResourceData resource in resources)
        {
            resource.amount = 0;
        }
        Debug.Log("All resources initialized to 0.");
    }
}
