using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slide;
    public TextMeshProUGUI textExp;

    private GameObject mPlayer;
    private GameObject mGameConfig;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mGameConfig = GameObject.FindGameObjectWithTag("Config");
    }

    // Update is called once per frame
    void Update()
    {
        if(mPlayer)
        {
            updateExp();
            textExp.text = slide.value.ToString() + " / " + slide.maxValue.ToString();
        }
        else
        {
            mPlayer = GameObject.FindGameObjectWithTag("Player");
        }
        
    }

    public void updateExp()
    {
        slide.value = mPlayer.GetComponent<PlayerController>().getCurrentExp();
        slide.maxValue = mGameConfig.GetComponent<Config>().getExp(mPlayer.GetComponent<PlayerController>().getLevel());
    }

    public float getExp()
    {
        return slide.value;
    }
}
