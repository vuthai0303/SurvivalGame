using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//public class Skill: MonoBehaviour
//{
//    int skillID;
//    string skillName;
//    int skillLevel;
//    int maxLevel;
//    Dictionary<int, float> skillsDamage = new Dictionary<int, float>();

//    public Skill(int skillID, string skillName, int maxLevel)
//    {
//        this.skillID = skillID;
//        this.skillName = skillName;
//        this.skillLevel = 1;
//        this.maxLevel = maxLevel;

//        for (int i = 1; i <= maxLevel; i++)
//        {
//            skillsDamage.Add(i, 10 * i);
//        }
//    }

//    // Update is called once per frame
//    public virtual void OnUpdate(){}
//    public virtual float getDamage() { return skillsDamage[skillLevel]; }
//}

public class SliceSkill : MonoBehaviour
{
    public int skillID;
    public int skillLevel;
    public int maxLevel;
    public GameObject prefab;
    public float maxTimeSpawn;
    public float timeSpawn;
    public float duration;
    public GameObject player;
    public UnityEngine.Vector3 offset;
    public bool isActive;

    public Dictionary<int, float> skillsDamage = new Dictionary<int, float>();

    public void Start()
    {
        isActive = false;
    }

    public void setSliceSkill(int skillID, int maxLevel, float maxTimeSpawn, float duration
                , GameObject prefab, GameObject player, UnityEngine.Vector3 offset)
    {
        this.skillID = skillID;
        this.maxLevel = maxLevel;
        this.prefab = prefab;
        this.maxTimeSpawn = maxTimeSpawn;
        this.timeSpawn = maxTimeSpawn;
        this.duration = duration;
        this.player = player;
        this.offset = offset;

        for (int i = 1; i <= maxLevel; i++)
        {
            this.skillsDamage.Add(i, 10 * i);
        }

        isActive = true;
    }

    public void Update() {
        if(timeSpawn <= 0)
        {
            //spawn skill
            timeSpawn = maxTimeSpawn;
            prefab.GetComponent<SkillForwardMove>()?.create(duration, 10f, player.transform.right);
            prefab.GetComponent<SkillDamage>()?.setDamage(10f);
            Instantiate(prefab, player.transform.position + offset, UnityEngine.Quaternion.identity);
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}
