using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupItemTemplate : MonoBehaviour {

    public Image icon;
    public Text contentText;


    public void Apply(string iconPath, string content)
    {
        icon.sprite = Resources.Load(iconPath,typeof(Sprite)) as Sprite;
        contentText.text = content;
        StartCoroutine("DestroySelf");
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.9f);
        Destroy(this.gameObject);
    }
}
