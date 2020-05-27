using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Player6_Boss : MonoBehaviour
{
    #region//インスペクター
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("敵頭判定")] public Enemy_HeadCheck headenemy;
    [Header("天井判定")] public GroundCheck head;
    [Header("足敵判定")] public Enemy_UnderCheck underenemy;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("リスポーン地点")] public GameObject Warp;
    [Header("R")] public R right;
    [Header("L")] public L left;
    [Header("j")] public J jump;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool headEnemy = false;
    private bool underEnemy = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool Right = false;
    private bool Left = false;
    private bool Jump = false;
    private float jumpPos = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private string enemyTag = "Enemy";
    private string abyss = "Abyss";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();
        headEnemy = headenemy.HeadEnemy();
        underEnemy = underenemy.UnderEnemy();
        Right = right.OnClick();
        Left = left.OnClick();
        Jump = jump.OnClick();

        //各種座標軸の速度を求める
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();


        //移動速度を設定
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;
        bool janp = Jump;

        if (isGround || (isGround && isHead))
        {
            if (((janp == true) || (verticalKey > 0)) && jumpTime < jumpLimitTime)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上ボタンを押されている。かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
            if (((janp == true) || (verticalKey > 0)) && jumpPos + jumpHeight > transform.position.y && jumpTime < jumpLimitTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }

    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        bool migi = Right;
        bool hidari = Left;


        if ((horizontalKey > 0) || (migi == true))
        {
            transform.localScale = new Vector3(4, 4, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
            Debug.Log("r");
        }
        else if ((horizontalKey < 0) || (hidari == true))
        {
            transform.localScale = new Vector3(-4, 4, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
            Debug.Log("l");
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }
        beforeKey = horizontalKey;

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }



    #region//敵接触判定    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (head.IsGround())
        {
            Debug.Log("頭がぶつかった");
        }
        if (collision.collider.tag == enemyTag)
        {
            Debug.Log("敵と接触した！");

        }

        if (collision.collider.tag == abyss)
        {
            Debug.Log("奈落に落ちた！");
            transform.position = Warp.transform.position;

        }

        if (headenemy.HeadEnemy() && underenemy.UnderEnemy())
        {
            Debug.Log("敵が頭に当たった！");
            SceneManager.LoadScene("Title");
        }
    }

    #endregion
}