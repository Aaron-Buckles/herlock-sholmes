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

    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

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
                levelManager.StarCollected();
                break;

            case ObjectType.Other:
                gameObject.SetActive(false);
                Debug.LogError("Unknown type of collectable");
                break;
        }
    }
}
