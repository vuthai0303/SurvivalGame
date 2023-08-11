using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using Unity.Mathematics;
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
    public int level;
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
        this.level = 1;
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
            prefab.GetComponent<SkillDamage>()?.setDamage(50f);
            Instantiate(prefab, player.transform.position + offset, UnityEngine.Quaternion.identity);
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}

public class SpinSkill : MonoBehaviour
{
    public int skillID;
    public int level;
    public int maxLevel;
    public GameObject prefab;
    public float maxTimeSpawn;
    public float timeSpawn;
    public float maxDuration;
    public float duration;
    public float range;
    public float speed;
    public float radius;
    public float mCurrentAngle = 0f;
    public GameObject player;
    public bool isActive;

    public Dictionary<int, float> skillsDamage = new Dictionary<int, float>();
    public Dictionary<int, float> numBall = new Dictionary<int, float>();
    public List<GameObject> balls = new List<GameObject>();

    public void Start()
    {
        isActive = false;
    }

    public void setSpinSkill(int skillID, int maxLevel, float maxTimeSpawn, float range
                , GameObject prefab, GameObject player, float maxDuration, float speed)
    {
        this.skillID = skillID;
        this.maxLevel = maxLevel;
        this.level = 1;
        this.prefab = prefab;
        this.maxTimeSpawn = maxTimeSpawn;
        this.timeSpawn = 0f;
        this.maxDuration = maxDuration;
        this.duration = maxDuration;
        this.range = range;
        this.speed = speed;
        this.radius = 0f;
        this.player = player;
        // set damage for each level
        for (int i = 1; i <= maxLevel; i++)
        {
            this.skillsDamage.Add(i, 50 * i);
        }
        // set num of ball for each level
        for (int i = 1; i <= maxLevel; i++)
        {
            this.numBall.Add(i, math.floor(i / 2) + (i % 2));
        }

        isActive = true;
    }

    public void Update()
    {
        if (timeSpawn <= 0)
        {
            //spawn skill
            var numberOfObjects = numBall[level];
            //var numberOfObjects = 2;
            for (int i = 0; i < numberOfObjects; i++)
            {
                prefab.GetComponent<SkillDamage>()?.setDamage(skillsDamage[level]);
                //prefab.GetComponent<SkillDamage>()?.setDamage(10f);
                var ball = Instantiate(prefab, player.transform.position, UnityEngine.Quaternion.identity);
                balls.Add(ball);
            }
            timeSpawn = maxTimeSpawn;
            duration = maxDuration;
        }
        else
        {
            if(duration <= 0)
            {
                //skill end
                if(radius > 0f)
                {
                    radius -= Time.deltaTime;
                    float angleIncrement = 360.0f / balls.Count;
                    mCurrentAngle += Time.deltaTime * speed;
                    float currentAngle = mCurrentAngle;

                    for (int i = 0; i < balls.Count; i++)
                    {
                        var ball = balls[i];
                        float x = player.transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * currentAngle);
                        float y = player.transform.position.y + radius * Mathf.Sin(Mathf.Deg2Rad * currentAngle);

                        UnityEngine.Vector3 newPosition = new UnityEngine.Vector3(x, y, transform.position.z);
                        ball.transform.position = newPosition;

                        currentAngle -= angleIncrement;
                    }
                }
                else
                {
                    timeSpawn -= Time.deltaTime;
                    if(balls.Count > 0)
                    {
                        for (int i = 0; i < balls.Count; i++)
                        {
                            GameObject ball = balls[i];
                            Destroy(ball);
                        }
                        balls.Clear();
                        mCurrentAngle = 0f;
                    }
                }
            }
            else
            {
                //skill play
                duration -= Time.deltaTime;
                radius = (radius >= range) ? range : (radius + Time.deltaTime);
                float angleIncrement = 360.0f / balls.Count;
                mCurrentAngle += Time.deltaTime * speed;
                float currentAngle = mCurrentAngle;

                for (int i = 0; i < balls.Count; i++)
                {
                    var ball = balls[i];
                    float x = player.transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * currentAngle);
                    float y = player.transform.position.y + radius * Mathf.Sin(Mathf.Deg2Rad * currentAngle);

                    UnityEngine.Vector3 newPosition = new UnityEngine.Vector3(x, y, transform.position.z);
                    ball.transform.position = newPosition;

                    currentAngle -= angleIncrement;
                }
            }
            
        }
    }

}
