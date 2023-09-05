using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private TextMeshProUGUI levelText;
    private GameObject mPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        levelText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + mPlayer.GetComponent<PlayerController>().getLevel().ToString();
    }
}
