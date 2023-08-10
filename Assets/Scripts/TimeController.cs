using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI textTime;

    private int time = 30;
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
        textTime.text = time.ToString();
    }
}
