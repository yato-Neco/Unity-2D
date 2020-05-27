using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class R : MonoBehaviour
{
    private bool rPush = false;
    private bool Right = false;

    public void DPush()
    {

        rPush = true;

    }

    public void UPUsh()
    {

        rPush = false;

    }
    
    public bool OnClick()
    { 

        if (rPush == true)
        {
            
            Right = true;

        }
        else if (rPush == false)
        {
            
            Right = false;
       
        }

        return Right;

    }

}