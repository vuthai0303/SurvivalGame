using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100f;
    public HealthBar healthBar;
    public float damage = 10f;
    public float maxDelayDamge = 1f;
    public float delayDamge = 1f;

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

    private void OnDestroy()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(delayDamge >= maxDelayDamge)
            {
                delayDamge = 0f;
                collision.gameObject.GetComponent<PlayerController>().isDamage(damage);
            }
            else
            {
                delayDamge += Time.deltaTime;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            delayDamge = maxDelayDamge;
        }
    }

}