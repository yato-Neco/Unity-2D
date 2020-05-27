
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraseigyo : MonoBehaviour
{
    [Header("Player")] public GameObject NPlayer;
    [Header("CameraZ")] public float CameraZ;
    [Header("CameraY")] public float CameraY;

    private float Playertr;
    void Update()
    {

        Playertr = NPlayer.transform.position.x;

        Vector3 Camera_Y2 = NPlayer.transform.position;
        Camera_Y2.y = CameraY;
        Camera_Y2.x = Playertr;
        Camera_Y2.z = CameraZ;

        transform.position = Camera_Y2;

    }











}