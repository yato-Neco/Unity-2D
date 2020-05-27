using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UnderCheck : MonoBehaviour
{
    private string underenemyTag = "Ground";
    private bool underEnemy = false;
    private bool underEnemyEnter, underEnemyStay, underEnemyExit;

    //接地判定を返すメソッド
    public bool UnderEnemy()
    {
        if (underEnemyEnter || underEnemyStay)
        {
            underEnemy = true;
        }
        else if (underEnemyExit)
        {
            underEnemy = false;
        }

        underEnemyEnter = false;
        underEnemyStay = false;
        underEnemyExit = false;
        return underEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == underenemyTag)
        {
            underEnemyEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == underenemyTag)
        {
            underEnemyStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == underenemyTag)
        {
            underEnemyExit = true;
        }
    }
}
