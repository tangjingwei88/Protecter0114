using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PubbleItem : MonoBehaviour {

    public Image heart_1;
    public Image heart_2;
    public Image heart_3;

    public Slider sliderBar;

    float timer = 0;
	void Update () {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            this.transform.localEulerAngles = Vector3.zero;
            timer = 0;
        }

        sliderBar.value = GameData.Instance.rewardNum / GameData.Instance.collidePoint;
        //碰撞点积满
        if (GameData.Instance.rewardNum >= GameData.Instance.collidePoint)
        {
            GameData.Instance.rewardNum = 0;
            if (GameData.Instance.bloodNum < 3)
            {
                //血点加1
                GameData.Instance.bloodNum += 1;
                this.gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
                PlayMusic("bloodRiase");
            }
            else
            {
                //血点积满，增加钻石
                Object popUpObj;
                GameObject popUpItem;
                popUpObj = Resources.Load(GameDefine.UIPrefabPath + "PopupItemTemplate");
                popUpItem = Instantiate((GameObject)popUpObj);
                popUpItem.SetActive(true);
                popUpItem.transform.parent = this.gameObject.transform.parent;
                popUpItem.transform.localPosition = this.gameObject.transform.localPosition;
                popUpItem.transform.localScale = Vector3.one;

                if (GameData.Instance.curStageState == StageState.OrderState)
                {
                    popUpItem.GetComponent<PopupItemTemplate>().Apply(GameDefine.UIPath + "diamond", "+ 2");
                    GameData.Instance.diamonds += 2;
                }
                else if (GameData.Instance.curStageState == StageState.RandomState)
                {
                    popUpItem.GetComponent<PopupItemTemplate>().Apply(GameDefine.UIPath + "diamond", "+ 5");
                    GameData.Instance.diamonds += 5;
                }
                else if (GameData.Instance.curStageState == StageState.GhostState)
                {
                    popUpItem.GetComponent<PopupItemTemplate>().Apply(GameDefine.UIPath + "diamond", "+ 10");
                    GameData.Instance.diamonds += 10;
                }
                else if (GameData.Instance.curStageState == StageState.SkeletonState)
                {
                    popUpItem.GetComponent<PopupItemTemplate>().Apply(GameDefine.UIPath + "diamond", "+ 30");
                    GameData.Instance.diamonds += 30;
                }

                PlayerPrefs.SetInt("Diamonds", GameData.Instance.diamonds);
                GameData.Instance.bloodNum = 0;
            }
        }

        RefreshBloodShow(GameData.Instance.bloodNum);
        // Debug.LogError("##" +sliderBar.value);
    }

    //刷新血点
    private void RefreshBloodShow(int num)
    {
        if (num == 1)
        {
            heart_1.gameObject.SetActive(true);
            heart_2.gameObject.SetActive(false);
            heart_3.gameObject.SetActive(false);
        }
        else if (num == 2)
        {
            heart_1.gameObject.SetActive(true);
            heart_2.gameObject.SetActive(true);
            heart_3.gameObject.SetActive(false);
        }
        else if (num == 3)
        {
            heart_1.gameObject.SetActive(true);
            heart_2.gameObject.SetActive(true);
            heart_3.gameObject.SetActive(true);
        }
        else
        {
            heart_1.gameObject.SetActive(false);
            heart_2.gameObject.SetActive(false);
            heart_3.gameObject.SetActive(false);
        }
    }

    public void PlayMusic(string name)
    {
        if (GameData.Instance.isMusic)
        {
            string audioStr = GameDefine.AudioPath + name;
            //Debug.LogError("audioStr: " + audioStr);
            AudioClip collideClip = Resources.Load(audioStr) as AudioClip;
            if (collideClip != null)
            {
                //  Debug.LogError("audio");
                AudioSource.PlayClipAtPoint(collideClip, Camera.main.transform.position);
            }
        }
    }
}
