using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float maxDelaySpawn = 1f;
    float delaySpawn = 1f;
    float rangeSpawn = 5f;

    GameObject mPlayer;

    const float MAX_HORIZONTAL = 50f;
    const float MAX_VERTICAL = 24f;

    // Use this for initialization
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!mPlayer)
        {
            return;
        }

        if (delaySpawn <= 0f)
        {
            delaySpawn = maxDelaySpawn;
            //spawn enemy here
            Vector3 playerPosition = mPlayer.transform.position;
            Vector3 enemyPosition = new Vector3(Random.Range(playerPosition.x + rangeSpawn, MAX_HORIZONTAL),
                                                    Random.Range(playerPosition.y + rangeSpawn, MAX_VERTICAL),
                                                    0);
            if(Random.Range(0, 100) > 50)
            {
                enemyPosition.x = enemyPosition.x * -1;
            }
            if (Random.Range(0, 100) > 50)
            {
                enemyPosition.y = enemyPosition.y * -1;
            }
            var enemy = Instantiate(EnemyPrefab, enemyPosition, Quaternion.identity);
        }
        else
        {
            delaySpawn -= Time.deltaTime;
        }

    }
}