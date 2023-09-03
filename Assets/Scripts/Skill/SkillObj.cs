using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SliceData
{
    public float maxTimeSpawn;
    public float duration;
    public float speed;
    public float damage;

    public SliceData(float maxTimeSpawn, float duration, float speed, float damage)
    {
        this.maxTimeSpawn = maxTimeSpawn;
        this.duration = duration;
        this.speed = speed;
        this.damage = damage;
    }
}

public class SliceSkill : MonoBehaviour
{
    [SerializeField] int skillID = (int)SkillsIDs.Slice;
    [SerializeField] int curLevel = 1;
    [SerializeField] int maxLevel = 6;
    [SerializeField] float timeSpawn;
    [SerializeField] float damage;
    [SerializeField] bool isActive = false;
    [SerializeField] List<SliceData> dataPerLevel = new List<SliceData>();
    [SerializeField] SliceData curData;

    GameObject prefab;
    GameObject player;
    UnityEngine.Vector3 offset = new UnityEngine.Vector3(0f, 0f, 0f);

    public void setSliceSkill(GameObject prefab, GameObject player)
    {
        this.prefab = prefab;
        this.player = player;

        for (int i = 1; i <= maxLevel; i++)
        {
            SliceData data = new SliceData(2f - i % 2 * i * 0.1f, 1f, 10f, 50f + math.floor(i/2) * 50f);
            this.dataPerLevel.Add(data);
        }
        this.curData = dataPerLevel[curLevel - 1];
        this.timeSpawn = curData.maxTimeSpawn;
        this.isActive = true;
    }

    public void Update() {
        if(!isActive)
        {
            return;
        }
        curData = dataPerLevel[curLevel - 1];
        damage = curData.damage;
        if(timeSpawn <= 0)
        {
            //spawn skill
            timeSpawn = curData.maxTimeSpawn;
            prefab.GetComponent<SkillForwardMove>()?.create(curData.duration, curData.speed, player.transform.right);
            prefab.GetComponent<SkillDamage>()?.setDamage(curData.damage);
            Instantiate(prefab, player.transform.position + offset, UnityEngine.Quaternion.identity);
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}

public class SpineData
{
    public float maxTimeSpawn;
    public float maxDuration;
    public float range;
    public float speed;
    public float damage;
    public int numBall;

    public SpineData(float maxTimeSpawn, float maxDuration, float range, float speed, float damage, int numBall)
    {
        this.maxTimeSpawn = maxTimeSpawn;
        this.maxDuration = maxDuration;
        this.range = range;
        this.speed = speed;
        this.damage = damage;
        this.numBall = numBall;
    }

    public SpineData clone()
    {
        SpineData newSpineData = new SpineData(maxTimeSpawn, maxDuration, range, speed, damage, numBall);
        return newSpineData;
    }
}

public class SpinSkill : MonoBehaviour
{
    [SerializeField] int skillID = (int)SkillsIDs.Spine;
    [SerializeField] int curLevel = 1;
    [SerializeField] int maxLevel = 6;
    [SerializeField] float timeSpawn;
    [SerializeField] float duration;
    [SerializeField] float radius;
    [SerializeField] float mCurrentAngle = 0f;
    [SerializeField] bool isActive = false;

    [SerializeField] List<SpineData> dataPerLevel = new List<SpineData>();
    [SerializeField] SpineData curData;

    private GameObject player;
    private GameObject prefab;
    private List<GameObject> balls = new List<GameObject>();

    public void configSkill(GameObject prefab, GameObject player)
    {
        this.prefab = prefab;
        this.player = player;
        for (int i = 1; i <= maxLevel; i++)
        {
            //SpineData prevData;
            //SpineData data;

            //if (i == 1)
            //{
            //    data = new SpineData(2f, 2f, 1f, 200f, 50f + math.floor(i / 2) * 50f, (int)math.floor(i / 2) + (i % 2));
            //}
            //else
            //{
            //    prevData = dataPerLevel[i - 1];
            //    data = prevData.clone();
            //    if(i % 2 == 0)
            //    {
            //        data.damage += 50f;
            //        data.numBall += 1;
            //    }
            //    else
            //    {
            //        data.maxTimeSpawn -= 0.2f;
            //        data.maxDuration += 0.2f;
            //        data.range += 0.5f;
            //        data.speed += 50f;
            //    }
            //}

            SpineData data = new SpineData(2f, 2f, 1f, 200f, 50f + math.floor(i / 2) * 50f, (int)math.floor(i / 2) + (i % 2));
            dataPerLevel.Add(data);
        }

        curData = dataPerLevel[curLevel - 1];
        timeSpawn = 0f;
        duration = curData.maxDuration;
        radius = 0f;
        isActive = true;
    }

    public void Update()
    {
        if(!isActive)
        {
            return;
        }

        curData = dataPerLevel[curLevel - 1];
        if (timeSpawn <= 0)
        {
            //spawn skill
            var numberOfObjects = curData.numBall;
            //var numberOfObjects = 2;
            for (int i = 0; i < numberOfObjects; i++)
            {
                prefab.GetComponent<SkillDamage>()?.setDamage(curData.damage);
                //prefab.GetComponent<SkillDamage>()?.setDamage(10f);
                var ball = Instantiate(prefab, player.transform.position, UnityEngine.Quaternion.identity);
                balls.Add(ball);
            }
            timeSpawn = curData.maxTimeSpawn;
            duration = curData.maxDuration;
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
                    mCurrentAngle += Time.deltaTime * curData.speed;
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
                radius = (radius >= curData.range) ? curData.range : (radius + Time.deltaTime);
                float angleIncrement = 360.0f / balls.Count;
                mCurrentAngle += Time.deltaTime * curData.speed;
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
