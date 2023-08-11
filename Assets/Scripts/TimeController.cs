using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI textTime;

    private int time = 30 * 60;
    private float rangeTime = 1f;

    // Update is called once per frame
    void Update()
    {
        rangeTime -= Time.deltaTime;
        if(rangeTime <= 0)
        {
            rangeTime = 1f;
            time -= 1;
        }
        textTime.text = getTimeStr();
    }

    string getTimeStr()
    {
        int hours = (int)math.floor(time / 60);
        int minus = time % 60;
        string strHours = hours.ToString().Length > 1 ? hours.ToString() : "0" + hours.ToString();
        string strMinus = minus.ToString().Length > 1 ? minus.ToString() : "0" + minus.ToString();
        return strHours + " : " + strMinus;
    }
}
