using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private List<Vector3> positions;

    private LineRenderer lineRenderer;
    private Vector3 mousePos;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isConnected;

    private IEnumerator recordMouseCoroutine;

    [SerializeField] private float pointOffset = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Var Settings
        positions = new List<Vector3>();
        isConnected = false;

        // lineRendere Settings
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        // Mouse Position Init
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        // Coroutine Settings
        recordMouseCoroutine = RecordMousePos();
        StartCoroutine(recordMouseCoroutine);
    }

    public List<Vector3> GetPositions()
    {
        return positions;
    }

    public bool IsConnected()
    {
        return isConnected;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        
        TestFunc();
    }

    private void setLine()
    {
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }

    private void TestFunc()
    {
        if (positions.Count == 25)
        {
            if (Vector3.Distance(positions[0], positions.Last()) < pointOffset)
            {
                StopCoroutine(recordMouseCoroutine);
                positions[24] = positions[0];
                setLine();
                isConnected = true;
            }
        }
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
            positions.Add(mousePos);
            setLine();

            yield return wait;
        }
    }

}
