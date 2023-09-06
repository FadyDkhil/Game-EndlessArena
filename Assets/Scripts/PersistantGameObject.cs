using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantGameObject : MonoBehaviour
{
    private static bool created = false;

    private void Awake()
    {
        // Ensure that only one instance of this GameObject exists
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            // If another instance already exists, destroy this one
            Destroy(this.gameObject);
        }
    }

    // Add any additional logic or components you need for the persistent GameObject
}
