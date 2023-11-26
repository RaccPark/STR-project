using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PulseRope : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegLen = 0.25f;
    private int segmentLength = 50;
    [SerializeField] private float lineWidth = 0.1f;
    [SerializeField] private int checkCount = 50;
    [Space(10f)]
    [SerializeField] private int pulseLen = 15;
    [Space(10f)]
    [SerializeField] private Transform startPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        // 로프 시작 위치
        Vector3 ropeStartPoint = startPoint.position;

        // ropSegments List에 추가
        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.x += ropeSegLen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetPulseShape();
        DrawRope();
    }

    private void Simulate()
    {

    }

    private void ApplyConstraint()
    {
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = this.startPoint.position;
        this.ropeSegments[0] = firstSegment;
    }

    private void SetPulseShape()
    {
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = this.startPoint.position;
        this.ropeSegments[0] = firstSegment;

        for (int i = 0; i < this.pulseLen; i++)
        {
            Vector2 ropePos;
            ropePos = new Vector2(-5f, 0f);
            this.ropeSegments[i] = new RopeSegment(ropePos);
            switch (i)
            {
                case 0:
                    ropePos = new Vector2(-5f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 1:
                    ropePos = new Vector2(-4.75f, 1f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 2:
                    ropePos = new Vector2(-4.5f, 2f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 3:
                    ropePos = new Vector2(-4.25f, 1f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 4:
                    ropePos = new Vector2(-4f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 5:
                    ropePos = new Vector2(-3.75f, -1f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 6:
                    ropePos = new Vector2(-3.5f, -2f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 7:
                    ropePos = new Vector2(-3.25f, -1f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 8:
                    ropePos = new Vector2(-3f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 9:
                    ropePos = new Vector2(-2.75f, 1f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 10:
                    ropePos = new Vector2(-2.5f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 11:
                    ropePos = new Vector2(-2.25f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 12:
                    ropePos = new Vector2(-2f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 13:
                    ropePos = new Vector2(-1.75f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;
                case 14:
                    ropePos = new Vector2(-1.5f, 0f);
                    this.ropeSegments[i] = new RopeSegment(ropePos);
                    break;

            }

        }

        for (int i = 0; i < this.segmentLength; i++)
        {
            RopeSegment segment = this.ropeSegments[i];
        }
    }

    private void MovePulseShape()
    {
        for(int i = 0; i< this.segmentLength;i++)
        {

        }

        for(int i = 0; i<pulseLen; i++)
        {
            RopeSegment oldSegment = this.ropeSegments[i+1];
            this.ropeSegments[i + 1] = this.ropeSegments[i];
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector2 posNow;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }
    }
}
