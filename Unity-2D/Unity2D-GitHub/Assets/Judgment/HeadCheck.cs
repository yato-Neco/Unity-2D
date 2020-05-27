using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    private string headTag = "Ground";
    private bool isHead = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isHead = true;
        }
        else if (isGroundExit)
        {
            isHead = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isHead;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == headTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == headTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == headTag)
        {
            isGroundExit = true;
        }
    }
}
