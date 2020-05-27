using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck2 : MonoBehaviour
{
    private string groundTag = "Ground";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            Debug.Log("頭に何かが判定に入りました");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            Debug.Log("頭に何かが判定に入り続けています");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            Debug.Log("頭に何かが判定をでました");
        }
    }

    internal bool IsGround()
    {
        throw new NotImplementedException();
    }
}