using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float maxDelaySpawn = 1f;
    float delaySpawn = 0f;
    float rangeSpawn = 5f;

    GameObject mPlayer;
    GameResource mGameResource;

    const float MAX_HORIZONTAL = 50f;
    const float MAX_VERTICAL = 24f;

    // Use this for initialization
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mGameResource = GameObject.FindGameObjectWithTag("Config").GetComponent<GameResource>();
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

            int ids = (int)Unity.Mathematics.math.floor(Random.Range(0, 10)) < 5 ? (int)EnemyIDs.Wraith : (int)EnemyIDs.Slime_blue;
            var enemyPrefab = mGameResource.getEnemyPrefab(ids);
            var enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity) ;
        }
        else
        {
            delaySpawn -= Time.deltaTime;
        }

    }
}