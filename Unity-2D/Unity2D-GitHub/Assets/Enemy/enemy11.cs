using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy11 : MonoBehaviour
{
    [Header("高さ(時間)")] public float Height;

    private Rigidbody2D rigid;
    private Vector3 defaultPos;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;
    }

    void FixedUpdate()
    {
        rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time,Height), defaultPos.z));
    }
}