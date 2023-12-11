using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{
    // https://uemonwe.tistory.com/4

    private List<Vector3> positions;
    private Vector3[] vertices;
    //private MeshFilter meshFilter;

    [SerializeField] private DrawLine drawLineScr;

    // Start is called before the first frame update
    void Start()
    {
        drawLineScr = gameObject.GetComponent<DrawLine>();
        //meshFilter = gameObject.GetComponent<MeshFilter>();
        positions = drawLineScr.GetPositions();

        vertices = positions.ToArray();
    }

    void SetMesh()
    {
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (drawLineScr.IsConnected())
        {
            SetMesh();
        }
    }
}
