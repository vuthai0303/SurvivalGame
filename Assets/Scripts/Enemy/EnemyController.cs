using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject mDamagePopup;
    public GameObject mExpPrefab;
    public float maxHealth = 100f;
    public HealthBar healthBar;
    public float damage = 10f;
    public float maxDelayDamge = 1f;
    private float delayDamge = 1f;

    private bool isHurt = false;
    public float maxDelayHurt = 0.1f;
    private float delayHurt = 0.1f;

    public bool isKnockBack = false;
    public float maxDelayKnockBack = 1f;
    private float delayKnockBack = 0f;

    [SerializeField]
    float mHealth;

    Vector3 offsetDamageText = new Vector3 (0f, 0.5f, 0f);

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
            Instantiate(mExpPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        if (isHurt)
        {
            var spriteRender = gameObject.GetComponent<SpriteRenderer>();
            if (delayHurt <= 0f)
            {
                isHurt = false;
                delayHurt = maxDelayHurt;
                spriteRender.color = Color.white;
            }
            else
            {
                delayHurt -= Time.deltaTime;
                spriteRender.color = Color.red;
            }
        }

        if (delayKnockBack > 0f)
        {
            delayKnockBack -= Time.deltaTime;
        }
    }

    public void isDamage(float damage)
    {
        if (isHurt) return;

        mHealth -= damage;
        var damageText = Instantiate(mDamagePopup, gameObject.transform.position + offsetDamageText, Quaternion.identity);
        damageText.GetComponent<TextMeshPro>().text = "- " + damage.ToString();

        isHurt = true;

        if (isKnockBack && delayKnockBack  <= 0f)
        {
            //knock back
            delayKnockBack = maxDelayKnockBack;
            var mPlayer = GameObject.FindGameObjectWithTag("Player");
            if (mPlayer != null)
            {
                Vector3 direction = (gameObject.transform.position - mPlayer.transform.position).normalized;
                gameObject.transform.position += direction * 1f;
            }
        }
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