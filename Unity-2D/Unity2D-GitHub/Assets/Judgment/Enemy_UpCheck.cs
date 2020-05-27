using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UpCheck : MonoBehaviour
{
    private string upenemyTag = "Enemy";
    private bool upEnemy = false;
    private bool underEnemyEnter, upEnemyStay, upEnemyExit;

    //接地判定を返すメソッド
    public bool UnderEnemy()
    {
        if (underEnemyEnter || upEnemyStay)
        {
            upEnemy = true;
        }
        else if (upEnemyExit)
        {
            upEnemy = false;
        }

        underEnemyEnter = false;
        upEnemyStay = false;
        upEnemyExit = false;
        return upEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == upenemyTag)
        {
            underEnemyEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == upenemyTag)
        {
            upEnemyStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == upenemyTag)
        {
            upEnemyExit = true;
        }
    }
}
