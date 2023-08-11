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
}
