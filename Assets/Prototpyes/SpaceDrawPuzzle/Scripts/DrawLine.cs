using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private List<Vector3> positions;

    private LineRenderer lineRenderer;
    private Vector3 mousePos;
    private Vector3 startPos;
    private Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();

        // lineRendere Settings
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        // Mouse Position Init
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        // Coroutine Settings
        StartCoroutine(RecordMousePos());
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    private void setLine()
    {
        positions.Add(mousePos);

        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }

    IEnumerator RecordMousePos()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while (true)
        {
            if (positions.Count == 25)
            {
                positions.RemoveAt(0);
            }
            setLine();

            yield return wait;
        }
    }

}
