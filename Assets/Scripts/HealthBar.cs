using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Vector3 offset;
    public Slider slide;

    private float m_health;
    private float m_maxHealth;

    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        slide.value = m_health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position + offset);
    }

    public void setHealth(float health, float maxHealth)
    {
        gameObject.SetActive(health < maxHealth);
        m_maxHealth = maxHealth;
        m_health = health;
        slide.maxValue = m_maxHealth;
    }

    public float getHealth()
    {
        return m_health;
    }
}
