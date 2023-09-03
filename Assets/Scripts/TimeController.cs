using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI textTime;

    private int minus = 0;
    private int second = 0;
    private float rangeTime = 1f;

    // Update is called once per frame
    void Update()
    {
        rangeTime -= Time.deltaTime;
        if(rangeTime <= 0)
        {
            rangeTime = 1f;
            second += 1;
            if(second >= 60)
            {
                minus += 1;
                second = 0;
            }
        }
        textTime.text = getTimeStr();
    }

    string getTimeStr()
    {
        string strMinus = minus.ToString().Length > 1 ? minus.ToString() : "0" + minus.ToString();
        string strSecond = second.ToString().Length > 1 ? second.ToString() : "0" + second.ToString();
        return strMinus + " : " + strSecond;
    }
}
