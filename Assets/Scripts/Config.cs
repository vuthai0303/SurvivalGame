using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Config : MonoBehaviour
{
    public List<float> expPerLevel = new List<float>();
    public Dictionary<int, float> dictLevel = new Dictionary<int, float>();

    void Start()
    {
        for(int i = 1; i <= expPerLevel.Count; i++)
        {
            dictLevel.Add(i, expPerLevel[i-1]);
        }
        
    }

    public float getExp(int level)
    {
        return dictLevel.ContainsKey(level) ? dictLevel[level]: 0f;
    }
}
