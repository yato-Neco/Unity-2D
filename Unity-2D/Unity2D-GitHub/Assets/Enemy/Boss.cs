using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
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

   
    float enemyAttackInterval;
    bool flag_r = false;
    bool flag_l = false;
    float jumptimer_r = 0;
    float jumptimer_l = 0;


    float enemyAttackTimer;

    private void Start()
    {


        enemyAttackInterval = Random.Range(1.0f, 5.0f);
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyAttackTimer += Time.deltaTime;
        
        if (enemyAttackTimer > enemyAttackInterval)
        {
            int random = Random.Range(0, 4);
            enemyAttackTimer = 0; 
            enemyAttackInterval = Random.Range(1.0f, 4.0f);

            if (onoff == 1)
            {
                print(random);



            
            }
            if (0 == random)
            {






                flag_r = true;
                anim.SetBool("jump", true);
                Debug.Log("1");
                
               

            }
            else
            {

                anim.SetBool("jump", false);

            }
            if (1 == random)
            {



                flag_l = true;
                anim.SetBool("jump", true);
               


            }
            else
            {

                anim.SetBool("jump", false);

            }
            if (flag_r == true)
            {
                jumptimer_r += Time.deltaTime;
                Debug.Log("2");
                if (jumptimer_r >= 1 )
                {
                    Debug.Log("3");
                    Vector2 force = new Vector2(x * speed , y * speed);
                    rb.AddForce(force);
                    flag_r = false;
                    jumptimer_r = 0;
                    anim.SetBool("jump", false);

                }
            }
            if(flag_l == true)
            {
                jumptimer_l += Time.deltaTime;
                if (jumptimer_l >= 1 )
                {
                    Vector2 force = new Vector2(x * speed * -1, y * speed);
                    rb.AddForce(force);
                    flag_l = false;
                    jumptimer_l
                        = 0;
                    anim.SetBool("jump", false);

                }



            }

        }

    }
}