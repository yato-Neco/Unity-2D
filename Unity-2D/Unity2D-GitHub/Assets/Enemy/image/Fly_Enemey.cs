using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemey : MonoBehaviour
{
    [Header("Y上限")] public float max_Y;
    [Header("Y下限")] public float min_Y;
    [Header("speed")] public float Dwonspeed;
    [Header("y")] public float y_height;
    [Header("x")] public float x_s;
    // Start is called before the first frame update

    private float height;
    private bool kari;




    // Update is called once per frame
    void Update()
    {

        height = transform.position.y;

        
        


        if (max_Y < height)//13 < 1~9 && 1~9 < 10
        {

            transform.position += (Vector3.down * Dwonspeed) * Time.deltaTime;

           
        }
        if(height > 10)
        {

            kari = true;



        }
        if (kari == true)
        {

            if (max_Y > height)
            {
                transform.position += (Vector3.right * x_s) * Time.deltaTime;
                transform.position += (Vector3.up * y_height) * Time.deltaTime;
                kari = false;
            }


        }


    }
}
