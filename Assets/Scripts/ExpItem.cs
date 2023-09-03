using UnityEngine;

public class ExpItem : MonoBehaviour
{
    public int exp = 50;
    public float speed = 5f;

    bool isAbsorb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        isAbsorb = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAbsorb)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if(distance <= 0.2f)
            {
                player.GetComponent<PlayerController>().absorbExp(exp);
                Destroy(gameObject);
            }
            Vector3 direction = player.transform.position - transform.position;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void absorb()
    {
        isAbsorb = true;
    }
}
