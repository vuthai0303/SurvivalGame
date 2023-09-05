using System.Collections.Generic;
using UnityEngine;

public class GameResource : MonoBehaviour
{
    public GameObject SliceSkillPrefab;
    public GameObject SpineSkillPrefab;

    public GameObject WraithEnemyPrefab;
    public GameObject SlimeBlueEnemyPrefab;

    public GameObject Player1Prefab;
    public GameObject Player2Prefab;
    public GameObject Player3Prefab;

    Dictionary<int, GameObject> skillsPrefab = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> enemysPrefab = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> playersPrefab = new Dictionary<int, GameObject>();

    private void Awake()
    {
        skillsPrefab.Add((int)SkillsIDs.Slice, SliceSkillPrefab);
        skillsPrefab.Add((int)SkillsIDs.Spine, SpineSkillPrefab);

        enemysPrefab.Add((int)EnemyIDs.Wraith, WraithEnemyPrefab);
        enemysPrefab.Add((int)EnemyIDs.Slime_blue, SlimeBlueEnemyPrefab);

        playersPrefab.Add((int)PlayerIDs.Player1, Player1Prefab);
        playersPrefab.Add((int)PlayerIDs.Player2, Player2Prefab);
        playersPrefab.Add((int)PlayerIDs.Player3, Player3Prefab);
    }

    public Dictionary<int, GameObject> getSkillsPrefab()
    {
        return skillsPrefab;
    }
    public GameObject getSkillPrefab(int skillID)
    {
        if (skillsPrefab.ContainsKey(skillID))
        {
            return skillsPrefab[skillID];
        }
        else
        {
            return null;
        }
    }
    public int getCountSkill()
    {
        return skillsPrefab.Count;
    }

    public Dictionary<int, GameObject> getEnemysPrefab()
    {
        return enemysPrefab;
    }
    public GameObject getEnemyPrefab(int enemyID)
    {
        if (enemysPrefab.ContainsKey(enemyID))
        {
            return enemysPrefab[enemyID];
        }
        else
        {
            return null;
        }
    }
    public int getCountEnemy()
    {
        return enemysPrefab.Count;
    }

    public Dictionary<int, GameObject> getPlayersPrefab()
    {
        return playersPrefab;
    }
    public GameObject getPlayerPrefab(int playerID)
    {
        if (playersPrefab.ContainsKey(playerID))
        {
            return playersPrefab[playerID];
        }
        else
        {
            return null;
        }
    }
    public int getCountPlayer()
    {
        return playersPrefab.Count;
    }
}
