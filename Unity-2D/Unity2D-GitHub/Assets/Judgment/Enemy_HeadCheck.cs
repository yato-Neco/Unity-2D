using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HeadCheck : MonoBehaviour
{
    private string enemyTag = "Enemy";
    private bool headEnemy = false;
    private bool headEnemyEnter, headEnemyStay, headEnemyExit;

    //接地判定を返すメソッド
    public bool HeadEnemy()
    {
        if (headEnemyEnter || headEnemyStay)
        {
            headEnemy = true;
        }
        else if (headEnemyExit)
        {
            headEnemy = false;
        }

        headEnemyEnter = false;
        headEnemyStay = false;
        headEnemyExit = false;
        return headEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            headEnemyEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            headEnemyStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            headEnemyExit = true;
        }
    }
}
  