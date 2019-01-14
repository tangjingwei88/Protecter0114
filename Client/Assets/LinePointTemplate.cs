using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePointTemplate : MonoBehaviour {

    int speed = 2;
    GameObject obj;
	// Use this for initialization
	void Start () {
        obj = GameObject.FindGameObjectWithTag("tree");
	}


    void Update()
    {
        if (obj != null)
        {
            float step = speed * Time.deltaTime;
            this.gameObject.transform.localPosition = new Vector3(Mathf.Lerp(this.gameObject.transform.localPosition.x, obj.transform.localPosition.x, step), Mathf.Lerp(this.gameObject.transform.localPosition.y, obj.transform.localPosition.y, step), Mathf.Lerp(this.gameObject.transform.localPosition.z, obj.transform.localPosition.z, step));//插值算法也可以
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "tree")
        {
            collision.gameObject.transform.Find("Imageguang").gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }

}
