using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoving : MonoBehaviour
{
    public float speed;

    GameObject m_Player;
    Animator m_Animator;
    PlayerInput playerInput;
    bool isLookRight = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = this.gameObject;
        playerInput = m_Player.GetComponent<PlayerInput>();
        m_Animator = m_Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moving();
    }

    void moving()
    {
        Vector2 input = playerInput.actions["move"].ReadValue<Vector2>();
        if(input.x < 0)
        {
            isLookRight = false;
        }else if(input.x > 0)
        {
            isLookRight = true;
        }
        m_Animator.SetFloat("speed", speed * Math.Abs(input.x + input.y));
        Vector3 move = new Vector3(input.x, input.y, 0);
        var newPosition = m_Player.GetComponent<Transform>().position + move * speed * Time.deltaTime;
        
        if (isLookRight)
        {
            m_Player.GetComponent<Transform>().right = Vector3.right;
        }
        else
        {
            m_Player.GetComponent<Transform>().right = Vector3.left;
        }
        m_Player.GetComponent<Transform>().position = newPosition;
    }
}
