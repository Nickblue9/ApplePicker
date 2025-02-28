﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY){
            Destroy(this.gameObject);

            //Get a reference to the ApplePicker component of main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            //Call the public AppleDestoryed() method of apScript
            apScript.AppleDestroyed();
        }
    }
}
