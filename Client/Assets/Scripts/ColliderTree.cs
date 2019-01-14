using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTree : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "enemy")
        {
            //血点为空，死亡
            if (GameData.Instance.bloodNum <= 0)
            {
                GameData.Instance.isLost = true;
                StopAllCoroutines();
                StartCoroutine(DestroyTree());
            }
            else
            {   //血点减1
                GameData.Instance.bloodNum -= 1;
                GameData.Instance.isBloodSplash = true;
                //机器震动
                if (GameData.Instance.isShake)
                {
                    Handheld.Vibrate();
                }
                //屏幕震动
                ScreenShake.isshakeCamera = true;
                // Debug.LogError("%%%" + GameData.Instance.bloodNum);
            }
        }
        else if (coll.transform.tag == "wall")
        {
            //this.gameObject.transform.localPosition = 
        }
    }


    IEnumerator DestroyTree()
    {
        this.gameObject.transform.Find("Image").gameObject.SetActive(false);
        GameObject boom = transform.Find("BoomImage").gameObject;
        boom.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        boom.SetActive(false);
        Destroy(this.gameObject);
        
    }
}
