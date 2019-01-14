using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour {

    private LineRenderer line = new LineRenderer();
    private GameObject huluObj;
    void Awake()
    {
        

        line = this.gameObject.GetComponent<LineRenderer>();
        //只有设置了材质 setColor才有作用
        //line.material = new Material(Shader.Find("Particles/Additive"));
        line.SetVertexCount(2); //设置两点
        line.SetColors(Color.yellow,Color.red); //设置直线颜色
        line.SetWidth(0.01f,0.01f); //设置直线宽度
    }

    // Update is called once per frame
    void Update () {

        huluObj = GameObject.FindGameObjectWithTag("tree");
        if (huluObj != null)
        {
            line.SetPosition(0, this.gameObject.transform.localPosition);
            line.SetPosition(1, huluObj.transform.localPosition);
        }
	}
}
