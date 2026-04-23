using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // 拖你的角色进来
    public Vector3 offset;      // 相机和角色的固定偏移
    public float smooth = 5f;   // 顺滑度

    void LateUpdate()
    {
        if (player == null) return;

        // 关键：偏移量随人物朝向一起旋转
        Vector3 rotatedOffset = player.rotation * offset;

        // 相机位置 = 人物位置 + 旋转后的偏移
        Vector3 targetPos = player.position + rotatedOffset;

        // 平滑跟随
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);

        // 相机一直看向角色
        transform.LookAt(player);
    }
}