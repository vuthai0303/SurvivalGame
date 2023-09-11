using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 distanceOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            distanceOffset = transform.position - player.GetComponent<Transform>().position;
        }
    }

    private void LateUpdate()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if(player)
            {
                distanceOffset = transform.position - player.GetComponent<Transform>().position;
            }
        }
        else
        {
            Vector3 newPosition = player.transform.position + distanceOffset;
            transform.position = newPosition;
            transform.LookAt(player.GetComponent<Transform>());
        }
    }
}
