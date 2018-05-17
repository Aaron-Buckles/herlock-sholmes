using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Star,
    Other
};

public class Collectable : MonoBehaviour
{
    public ObjectType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collect();
        }
    }

    private void collect()
    {
        switch (type)
        {
            case ObjectType.Star:
                gameObject.SetActive(false);
                Debug.Log("Collect a star");
                break;

            case ObjectType.Other:
                gameObject.SetActive(false);
                Debug.LogError("Unknown type of collectable");
                break;
        }
    }
}
