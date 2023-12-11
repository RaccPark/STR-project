using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal;

public class MazeDrawLine : MonoBehaviour
{
    private List<Vector3> positions;

    private LineRenderer lineRenderer;
    [SerializeField] private Camera cam;

    private Vector3 mousePos;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 dir;
    private bool isStarted;

    // Start is called before the first frame update
    void Start()
    {
        // Var Settings
        positions = new List<Vector3>();
        isStarted = false;

        // lineRendere Settings
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        // Mouse Position Init
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        this.transform.position = mousePos;


        MouseEvent();
    }

    void MouseEvent()
    {
        if (positions.Count > 0)
        {
            dir = transform.position - positions[positions.Count - 1];
            Debug.DrawRay(positions[positions.Count - 1], dir, new Color(1, 0, 0));
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit2 = Physics2D.Raycast(mousePos, transform.forward, 15f);
            if(hit2)
            {
                if (hit2.collider.CompareTag("Start") && isStarted == false)
                {
                    isStarted = true;
                    hit2.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

            if (isStarted)
            {
                Debug.Log(positions.Count);
                if (positions.Count > 0)
                {
                    RaycastHit2D hit = Physics2D.Raycast(positions[positions.Count - 1], dir, Vector3.Distance(positions[positions.Count - 1], transform.position));
                    if (hit)
                    {
                        Debug.Log("DETECTED");
                        Debug.Log(hit.collider.tag);

                        if (hit.rigidbody.CompareTag("Point"))
                        {
                            lineRenderer.SetColors(new Color(1, 0, 0), new Color(1, 0, 0));
                            positions.Add(mousePos);
                            setLine();
                        }
                    }
                    else
                    {
                        positions.Add(mousePos);
                        setLine();
                    }

                }
                else
                {
                    positions.Add(mousePos);
                    setLine();
                }
            }

        }
    }

    private void setLine()
    {
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }
}
