using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WaterWave : MonoBehaviour
{
    [Header("波浪参数（直接在Inspector调）")]
    [Tooltip("波浪流动速度，越大越快")]
    public float waveSpeed = 1.2f;
    [Tooltip("波浪高度，越大起伏越明显")]
    public float waveHeight = 0.15f;
    [Tooltip("波浪频率，越大波纹越密")]
    public float waveFrequency = 2f;

    private MeshFilter meshFilter;
    private Vector3[] originalVertices;

    void Start()
    {
        // 缓存平面原始顶点，避免越跑越歪
        meshFilter = GetComponent<MeshFilter>();
        originalVertices = meshFilter.mesh.vertices;
    }

    void Update()
    {
        // 实时修改顶点Y轴位置，生成波浪
        Vector3[] vertices = meshFilter.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            // 正弦函数模拟自然波浪
            float y = Mathf.Sin(Time.time * waveSpeed + vertices[i].x * waveFrequency + vertices[i].z * waveFrequency) * waveHeight;
            vertices[i].y = originalVertices[i].y + y;
        }

        // 应用修改并重新计算法线，保证光影正确
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}