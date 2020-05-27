using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1213 : MonoBehaviour
{
    [Header("移動速度")] public float speed;
    [Header("y")] public float y;
    [Header("x")] public float x;
    [Header("乱数表時0～1")] public float onoff;


    #region//プライベート変数
    private Rigidbody2D rb;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    #endregion

    // 敵が攻撃する間隔
    float enemyAttackInterval;
    // 経過時間 
    float enemyAttackTimer;

    private void Start()
    {


        // Start()の中に書く
        // enemyAttackIntervalを初期化、5~10の数値が入る
        enemyAttackInterval = Random.Range(1.0f, 5.0f);
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();


        // Update()の中に書く
        // 経過時間を足していく
        enemyAttackTimer += Time.deltaTime;
        // 経過時間がenemyAttackIntervalを上回った
        if (enemyAttackTimer > enemyAttackInterval)
        {
            int random = Random.Range(0, 2);
            enemyAttackTimer = 0; // タイマーを戻す
            enemyAttackInterval = Random.Range(1.0f, 2.0f); // インターバルをセットしなおす

            if (onoff == 1)
            {
                print(random);




            }
            if (0 == random)
            {
                Vector2 force = new Vector2(x * speed, y * speed);
                rb.AddForce(force);


            }
            else
            {
               
            }
            if (1 == random)
            {
                Vector2 force = new Vector2(x * speed * -1, y * speed);
                rb.AddForce(force);



            }
            else
            {
               
            }
        }
    }
}