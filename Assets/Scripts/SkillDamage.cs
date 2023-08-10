using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    public float damage;

    public void Update()
    {
    }

    public void setDamage (float damage)
    {
        enabled = true;
        this.damage = damage;
    }

    public void OnCollisionStay(Collision2D collision)
    {
        print(collision);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().isDamage(damage);
        }
    }
}
