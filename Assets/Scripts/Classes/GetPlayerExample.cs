using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerExample : MonoBehaviour
{
    private Dictionary<string, object> skillMemory;

    public T Remember<T>(string key)
    {
        if (!skillMemory.TryGetValue(key, out object result))
            return default;
        return (T)result;
    }

    public void Remember<T>(string key, T value)
    {
        skillMemory[key] = value;
    }

    private void OnEnable()
    {
        skillMemory = new Dictionary<string, object>();
    }

    protected GameObject FindPlayer()
    {
        GameObject player = Remember<GameObject>("player");

        if (!player)
        {
            // Find the player
            player = GameObject.FindGameObjectWithTag("Player");

            Remember<GameObject>("player");

        }

        if (!player)
        {
            Debug.Log("Player not found!");
            return null;
        }

        return player;
    }
}
