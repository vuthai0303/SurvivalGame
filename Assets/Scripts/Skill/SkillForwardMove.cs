using UnityEngine;

public class SkillForwardMove : MonoBehaviour
{
    public float duration;
    public float speed = 0f;
    public Vector3 direction;

    // Update is called once per frame
    public void Update()
    {
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            duration -= Time.deltaTime;
        }

        Vector3 move = direction * speed * Time.deltaTime;
        
        gameObject.transform.position += move;
    }

    public void create(float duration, float speed, Vector3 direction)
    {
        this.duration = duration;
        this.speed = speed;
        this.direction = direction;
        if(direction == Vector3.left)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        enabled = true;
    }
}
