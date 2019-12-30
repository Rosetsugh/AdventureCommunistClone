﻿using UnityEngine;

public class LevelSessionData : MonoBehaviour
{
    public static LevelSessionData Singleton { get; private set; }

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;

        else
        {
            Debug.LogError("Another Singleton Exits! " + GetType() + ".cs has been removed from the " + name + " Game Object");
            Destroy(this);
        }
    }

    public int numberOfComrades;
    public int numberOfFarmers;
    public int numberOfPotatoes;

    private void Start()
    {
        numberOfComrades = 0;
        numberOfFarmers = 0;
        numberOfPotatoes = 0;
    }
}
