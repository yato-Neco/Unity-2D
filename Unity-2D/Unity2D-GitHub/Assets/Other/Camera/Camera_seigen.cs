using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_seigen : MonoBehaviour
{
    [Header("A")] public GameObject A;
    [Header("B")] public GameObject B;

    // Update is called once per frame
    void Update()
    {

            Transform camera_New = this.transform;
        Vector2 camera_New1 = camera_New.position;
        Vector2 max = A.transform.position;
        Vector2 min = B.transform.position;

            camera_New1.x = Mathf.Clamp(camera_New1.x, min.x, max.x);
            camera_New1.y = Mathf.Clamp(camera_New1.y, min.y, max.y);
        
    }
}
