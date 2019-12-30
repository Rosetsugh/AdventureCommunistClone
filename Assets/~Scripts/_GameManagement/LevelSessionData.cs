using UnityEngine;

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
    public float comradeFillSpeed = 1;
    public int numberOfFarmers = 1;
    public float farmerFillSpeed = 0.5f;
    public int numberOfPotatoes;
    public float potatoFillSpeed = 0.5f;

    private void Start()
    {
        numberOfComrades = 0;
        numberOfFarmers = 1;
        numberOfPotatoes = 0;
    }

    public void UpdateScores()
    {

    }
}
