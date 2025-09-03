using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove: MonoBehaviour
{
    public Transform target;  // 카메라가 따라다닐 대상
    public float maxY;       
    public float minY;      

    private void LateUpdate()
    {
        // 카메라 이동
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
    }
}
