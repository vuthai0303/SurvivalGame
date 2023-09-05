using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public List<GameObject> lstPlayerPrefab;
    public List<RuntimeAnimatorController> lstPlayerAnimator;
    public List<GameObject> lstBtnChoosePlayer;
    public GameObject Player;
    public int choosePlayerIds = 0;

    // Update is called once per frame
    void Update()
    {
        if(choosePlayerIds < 0) { return; }

        for (int i = 0; i < lstBtnChoosePlayer.Count; i++)
        {
            var buttonImage = lstBtnChoosePlayer[i].GetComponent<Image>();
            if (i == choosePlayerIds)
            {
                buttonImage.color = Color.yellow;
                Player.GetComponent<Animator>().runtimeAnimatorController = lstPlayerAnimator[i];
            }
            else
            {
                buttonImage.color = Color.white;
            }
        }
    }

    public void onClickBtnChooosePlayer(int idx)
    {
        choosePlayerIds = idx;
    }
}
