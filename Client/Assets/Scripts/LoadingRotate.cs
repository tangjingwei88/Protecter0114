﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingRotate : MonoBehaviour {

    public int speed = 500;
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0,0,-1),7);
	}
}
