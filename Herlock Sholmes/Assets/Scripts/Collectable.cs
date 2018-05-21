using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Coin,
    Other
};

public class Collectable : MonoBehaviour
{
    public ObjectType type;
    public int objectNumber;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        switch (type)
        {
            case ObjectType.Coin:
                gameObject.SetActive(false);
                levelManager.CoinCollected(objectNumber);
                break;

            case ObjectType.Other:
                gameObject.SetActive(false);
                Debug.LogError("Unknown type of collectable");
                break;
        }
    }
}
