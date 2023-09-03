using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public List<int> expPerLevel = new List<int>();

    void Start()
    {
        
    }

    public int getExp(int level)
    {
        return expPerLevel.Count >= level ? expPerLevel[level - 1] : 999999999;
    }
}
