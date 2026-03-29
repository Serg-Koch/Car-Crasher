using UnityEngine;

public static class SpawnPoints
{
    public static Vector3[] velocity = 
    {
        new Vector3(-1, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, 0, 0)
    };

    public static Vector3 [] spawn =
    {
        new Vector3(47, 0, -3.0f),
        new Vector3(47, 15, -3.0f),
        new Vector3(-47, 0, -3.0f),
        new Vector3(-47, 15, -3.0f)
    };
}
