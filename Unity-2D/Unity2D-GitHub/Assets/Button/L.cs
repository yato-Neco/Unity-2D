using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class L : MonoBehaviour
{
    private bool lPush = false;
    private bool Left = false;

    public void DPush()
    {

        lPush = true;

    }

    public void UPUsh()
    {

        lPush = false;

    }

    public bool OnClick()
    {

        if (lPush == true)
        {

            Left = true;

        }
        else if (lPush == false)
        {

            Left = false;

        }

        return Left;

    }

}