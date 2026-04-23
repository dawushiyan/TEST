using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 5f;
    public float rotateSpeed = 120f;

    void Update()
    {
        // 转向：A 左转 D 右转
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);

        // 前进后退：W 前 S 后
        float v = Input.GetAxis("Vertical");
        // 去掉了 Mathf.Max，现在 v 正=前 负=后
        transform.Translate(0, 0, v * moveSpeed * Time.deltaTime);
    }
}