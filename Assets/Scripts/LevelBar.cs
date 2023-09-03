using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slide;
    public TextMeshProUGUI textExp;

    private int currentExp = 0;
    private int maxCurrentExp = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        slide.value = currentExp;
    }

    // Update is called once per frame
    void Update()
    {
        textExp.text = currentExp.ToString() + " / " + maxCurrentExp.ToString();
        slide.value = currentExp;
    }

    public void setExp(int exp, int maxExp)
    {
        maxCurrentExp = maxExp;
        currentExp = exp;
        slide.maxValue = maxExp;
    }

    public float getExp()
    {
        return currentExp;
    }
}
