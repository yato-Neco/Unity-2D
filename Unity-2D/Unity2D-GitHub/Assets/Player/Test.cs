﻿using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0.1f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
    }

}
