using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static int EnemiesSpawned;
    public static int OrbsCollected;
    public static int Lives = 5;

    public static void ResetStats()
    {
        EnemiesSpawned = 0;
        OrbsCollected = 0;
        Lives = 5;
    }
}
