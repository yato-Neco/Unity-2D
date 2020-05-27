using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BOSSwrap : MonoBehaviour
{
    private string playerTag = "Player";




    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == playerTag)
        {
            Debug.Log("次のシーン");
            SceneManager.LoadScene("BOSS");
            







        }

         







    }
}
