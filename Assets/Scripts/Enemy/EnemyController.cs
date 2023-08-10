using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100f;
    public HealthBar healthBar;

    [SerializeField]
    float mHealth;


    // Start is called before the first frame update
    void Start()
    {
        mHealth = maxHealth;
        healthBar.setHealth(mHealth, maxHealth);
        gameObject.GetComponentInChildren<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(mHealth >= 0 ? mHealth : 0, maxHealth);
        if (mHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void isDamage(float damage)
    {
        mHealth -= damage;
    }
}
