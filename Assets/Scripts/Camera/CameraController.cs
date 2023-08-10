using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 distanceOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distanceOffset = transform.position - player.GetComponent<Transform>().position ;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + distanceOffset;
        transform.position = newPosition;
        transform.LookAt(player.GetComponent<Transform>());
    }
}
