using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class buck : MonoBehaviour
{
    private bool firstPush = false;

    public void PressStart()
    {
        Debug.Log("Press Start!");
        if (!firstPush)
        {
            Debug.Log("Go Title");
            //ここに次のシーンへいく命令を書く
            SceneManager.LoadScene("Title");
            //
            firstPush = true;
        }
    }
}