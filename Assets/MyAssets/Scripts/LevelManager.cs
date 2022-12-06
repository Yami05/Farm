using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject[] enemies;

    private void OnEnable()
    {
        enemies = Resources.LoadAll<GameObject>("EnemyGroups");
    }

    public int GetEnemyCount() => enemies.Length;
}
