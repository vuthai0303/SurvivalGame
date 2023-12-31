using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    public HealthBar healthBar;

    float mHealth;
    int mLevel = 1;
    int currentExp;
    int maxExp;
    float rangeAbsorbExp;
    public LayerMask absorbLayerTarget;

    private GameObject mPlayer;
    private GameObject mGameConfig;
    private GameResource mGameResource;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mGameConfig = GameObject.FindGameObjectWithTag("Config");
        mGameResource = mGameConfig.GetComponent<GameResource>();
        mHealth = maxHealth;
        healthBar.setHealth(mHealth, maxHealth);
        currentExp = 0;
        maxExp = mGameConfig.GetComponent<Config>().getExp(mLevel);
        rangeAbsorbExp = 1f;
        gameObject.GetComponentInChildren<Canvas>().enabled = true;

        //create skill player
        mPlayer.AddComponent<SliceSkill>();
        mPlayer.GetComponent<SliceSkill>().setSliceSkill(mGameResource.getSkillPrefab((int)SkillsIDs.Slice), mPlayer);

        mPlayer.AddComponent<SpinSkill>();
        mPlayer.GetComponent<SpinSkill>().configSkill(mGameResource.getSkillPrefab((int)SkillsIDs.Spine), mPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        checkAbsorbExp();
        healthBar.setHealth(mHealth >= 0 ? mHealth : 0, maxHealth);
        if(mHealth <= 0)
        {
            Destroy(gameObject);
        }
        if(currentExp >= maxExp)
        {
            mLevel += 1;
            currentExp = 0;
            maxExp = mGameConfig.GetComponent<Config>().getExp(mLevel);
        }
    }

    public void isDamage(float damage)
    {
        mHealth -= damage;
    }

    public void checkAbsorbExp()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, rangeAbsorbExp, absorbLayerTarget);
        foreach(Collider2D collider in hitColliders)
        {
            if (collider.gameObject.tag == "Exp")
            {
                collider.GetComponent<ExpItem>().absorb();
            }
        }
    }

    public void absorbExp(int exp)
    {
        currentExp += exp;
    }

    public int getCurrentExp()
    {
        return currentExp;
    }

    public int getLevel()
    {
        return mLevel;
    }
}
