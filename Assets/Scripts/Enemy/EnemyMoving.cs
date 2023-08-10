using System;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public float speed;

    GameObject m_Enemy;
    GameObject m_Player;
    Animator m_Animator;
    bool isLookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Enemy = this.gameObject;
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_Animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moving();
    }

    void moving()
    {
        if (!m_Player)
        {
            return;
        }

        Vector3 playerPosition = m_Player.transform.position;
        Vector3 myPosition = m_Enemy.transform.position;

        if (Vector3.Distance(myPosition, playerPosition) < 0.1f)
        {
            m_Animator.SetFloat("speed", 0f);
            return;
        }

        if (playerPosition.x > myPosition.x)
        {
            isLookRight = true;
        }
        else if (playerPosition.x < myPosition.x)
        {
            isLookRight = false;
        }

        m_Animator.SetFloat("speed", speed);
        Vector3 direction = (playerPosition - myPosition).normalized;
        var newPosition = m_Enemy.transform.position + direction * speed * Time.deltaTime;

        if (isLookRight)
        {
            m_Enemy.transform.right = Vector3.right;
        }
        else
        {
            m_Enemy.transform.right = Vector3.left;
        }
        m_Enemy.transform.position = newPosition;
    }
}
