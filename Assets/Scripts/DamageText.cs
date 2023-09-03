using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public float existTime = 3f;
    public float speed = 0.01f;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(existTime > 0)
        {
            existTime -= Time.deltaTime;
            gameObject.transform.position = gameObject.transform.position + direction * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
