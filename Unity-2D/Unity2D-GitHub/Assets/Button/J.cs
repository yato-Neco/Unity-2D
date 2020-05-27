using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class J : MonoBehaviour
{
    private bool jPush = false;
    private bool Jump = false;

    public void DPush()
    {

        jPush = true;

    }

    public void UPUsh()
    {

        jPush = false;

    }

    public bool OnClick()
    {

        if (jPush == true)
        {

            Jump = true;

        }
        else if (jPush == false)
        {

            Jump = false;

        }

        return Jump;

    }

}