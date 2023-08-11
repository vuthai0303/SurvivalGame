using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    public HealthBar healthBar;
    public LevelBar levelBar;
    public GameObject configGame;
    public GameObject sliceSkillPrefab;
    public GameObject spinSkillPrefab;

    float mHealth;
    private int mLevel = 1;
    private float currentExp;
    private float maxExp;
    private GameObject mPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mHealth = maxHealth;
        healthBar.setHealth(mHealth, maxHealth);
        currentExp = 0f;
        maxExp = configGame.GetComponent<Config>().getExp(mLevel);
        levelBar.setExp(currentExp, maxExp);
        gameObject.GetComponentInChildren<Canvas>().enabled = true;

        //create skill player
        mPlayer.AddComponent<SliceSkill>();
        mPlayer.GetComponent<SliceSkill>().setSliceSkill(1, 10, 3, 1, sliceSkillPrefab, mPlayer, new UnityEngine.Vector3(0f, 0f, 0f));

        mPlayer.AddComponent<SpinSkill>();
        mPlayer.GetComponent<SpinSkill>().setSpinSkill(2, 10, 2f, 1f, spinSkillPrefab, mPlayer, 10f, 200f);
    }

    // Update is called once per frame
    void Update()
    {
        //maxExp = configGame.GetComponent<Config>().getExp(mLevel);
        healthBar.setHealth(mHealth >= 0 ? mHealth : 0, maxHealth);
        if(mHealth <= 0)
        {
            Destroy(gameObject);
        }
        if(currentExp >= maxExp)
        {
            mLevel += 1;
            currentExp = 0f;
            maxExp = configGame.GetComponent<Config>().getExp(mLevel);
        }
        levelBar.setExp(currentExp, maxExp);
    }

    public void isDamage(float damage)
    {
        mHealth -= damage;
    }
}
