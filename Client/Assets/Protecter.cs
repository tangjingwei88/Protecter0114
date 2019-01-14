using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protecter : MonoBehaviour {

    GameObject rewardPointObj;
    GameObject pointObj;
    GameObject obj;

    List<GameObject> rewardPointList = new List<GameObject>();
    List<GameObject> pointList = new List<GameObject>();
    int ext = 1;

    void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("tree");
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            obj = GameObject.FindGameObjectWithTag("tree");
            if (obj != null)
            {
                Object linePointObj;
                linePointObj = Resources.Load(GameDefine.UIPrefabPath + "RewardPointTemplate");
                rewardPointObj = Instantiate((GameObject)linePointObj);
                rewardPointObj.name += ext.ToString();
                ext++;
                rewardPointObj.SetActive(true);
                rewardPointObj.transform.parent = this.gameObject.transform.parent;
                rewardPointObj.transform.localPosition = this.gameObject.transform.localPosition;
                rewardPointObj.transform.localScale = Vector3.one;
                rewardPointList.Add(rewardPointObj);

                GameData.Instance.rewardNum += 1;
               // Debug.LogError("#rewardNum" + GameData.Instance.rewardNum);
            }
        }
    }
    // Update is called once per frame
    void Update () {
          obj = GameObject.FindGameObjectWithTag("tree");
          if (obj != null)
          {
              Object linePointObj;
              linePointObj = Resources.Load(GameDefine.UIPrefabPath + "LinePointTemplate");
              pointObj = Instantiate((GameObject)linePointObj);
              pointObj.name += ext.ToString();
              ext++;
              pointObj.SetActive(true);
              pointObj.transform.parent = this.gameObject.transform.parent;
              pointObj.transform.localPosition = this.gameObject.transform.localPosition;
              pointObj.transform.localScale = Vector3.one;
              pointList.Add(pointObj);
          }
          else {
              Clean();
          }
        
    }



    private void Clean()
    {
        for (int i = 0; i < rewardPointList.Count; i++)
        {
            Destroy(rewardPointList[i].gameObject);
        }
        rewardPointList.Clear();

        for (int i = 0; i < pointList.Count; i++)
        {
            Destroy(pointList[i].gameObject);
        }
        pointList.Clear();
    }
}
