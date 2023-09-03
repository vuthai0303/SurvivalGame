using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NavigationEnemy : MonoBehaviour
{
    private GameObject mPlayer;
    private NavMeshAgent mAgent;
    bool isLookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mAgent = GetComponent<NavMeshAgent>();
        mAgent.updateRotation = false;
        mAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        mAgent.destination = mPlayer.transform.position;
        if (mPlayer.transform.position.x > transform.position.x)
        {
            isLookRight = true;
        }
        else if (mPlayer.transform.position.x < transform.position.x)
        {
            isLookRight = false;
        }

        if (isLookRight)
        {
            transform.right = Vector3.right;
        }
        else
        {
            transform.right = Vector3.left;
        }
    }
}
