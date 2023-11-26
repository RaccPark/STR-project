using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinPulse : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int points;
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private Vector2 xLimits = new Vector2(0, 1);
    [SerializeField] private float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Draw()
    {
        float xStart = 0;
        float Tau = 3 * Mathf.PI;
        float xFinish = Tau;

        lineRenderer.positionCount = points;
        for(int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin((Tau * frequency * x) + (Time.timeSinceLevelLoad * movementSpeed));
            lineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }
}
