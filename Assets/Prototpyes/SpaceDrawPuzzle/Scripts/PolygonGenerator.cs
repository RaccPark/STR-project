using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PolygonGenerator : MonoBehaviour
{
    private List<Vector3> positions;

    [SerializeField] private DrawLine drawLineScr;

    private Mesh mesh;
    private Vector3[] vertices; // 다각형의 정점 정보 배열
    private int[] indices;      // 정점을 잇는 폴리곤 정보 배열

    private void Awake()
    {
        mesh = new Mesh();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        drawLineScr = GetComponent<DrawLine>();
        /*positions = drawLineScr.GetPositions();
        Debug.Log(positions);
        vertices = positions.ToArray();*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positions = drawLineScr.GetPositions();
        Debug.Log(positions);
        vertices = positions.ToArray();

        if (drawLineScr.IsConnected())
        {
            DrawFilled(vertices.Length);
        }
        
    }

    private void DrawFilled(int sides)
    {
        // 정점을 잇는 폴리곤 정보
        indices = DrawFilledIndices(vertices);
        // 메시 생성
        GeneratePolygon(vertices, indices);
    }

    private int[] DrawFilledIndices(Vector3[] vertices)
    {
        int triangleCount = vertices.Length - 2;
        List<int> indices = new List<int>();

        for (int i = 0; i < triangleCount; ++i)
        {
            indices.Add(0);
            indices.Add(i+2);
            indices.Add(i+1);
        }

        return indices.ToArray();
    }

    private void GeneratePolygon(Vector3[] vertices, int[] indices)
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = indices;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
