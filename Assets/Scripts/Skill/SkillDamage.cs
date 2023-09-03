using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    public float damage;

    public void setDamage (float damage)
    {
        enabled = true;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().isDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision);
            collision.gameObject.GetComponent<EnemyController>().isDamage(damage);
        }
    }
}
