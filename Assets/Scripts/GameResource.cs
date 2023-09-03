using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResource : MonoBehaviour
{
    public GameObject SliceSkillPrefab;
    public GameObject SpineSkillPrefab;

    public GameObject WraithEnemyPrefab;
    public GameObject SlimeBlueEnemyPrefab;

    Dictionary<int, GameObject> skillsPrefab = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> enemysPrefab = new Dictionary<int, GameObject>();

    private void Awake()
    {
        skillsPrefab.Add((int)SkillsIDs.Slice, SliceSkillPrefab);
        skillsPrefab.Add((int)SkillsIDs.Spine, SpineSkillPrefab);

        enemysPrefab.Add((int)EnemyIDs.Wraith, WraithEnemyPrefab);
        enemysPrefab.Add((int)EnemyIDs.Slime_blue, SlimeBlueEnemyPrefab);
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
}
