using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineConnect : MonoBehaviour
{
    private float lineWidth = 0.1f;
    private LineRenderer lr;
    private Vector3[] linePoints = new Vector3[2];

    [SerializeField] private GameObject connectedProduct;
    private RaycastHit2D hit;
    private Vector3 mousePosition;

    private bool mouseButton = false;

    [SerializeField] private GameObject targetPoint;

    private void OnMouseDown()
    {
        mouseButton = true;
    }

    private void OnMouseUp()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
 
        mouseButton = false;
        lr.enabled = false;

        Debug.Log("Mouse UP");

        hit = Physics2D.Raycast(mousePosition, transform.forward, 15f);
        Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, 0.3f);

        // Ray2D ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (hit)
        {
            if (targetPoint == null)
            {
                if (hit.collider.gameObject != this.gameObject)
                {
                    connectedProduct = hit.collider.gameObject;

                    Debug.Log(hit.collider.gameObject.name + " is connected");

                    lr.enabled = true;

                    /* 선택된 오브젝트에 라인 연결 */
                    linePoints[1] = hit.collider.gameObject.transform.position;
                    lr.SetPositions(linePoints);
                    this.OnConnectedPoint(hit.collider.gameObject);

                    // Camera Moving
                    Camera.main.transform.position = new Vector3(mousePosition.x, Camera.main.transform.position.y, -10);

                    return;
                }
            }
            else
            {
                if (hit.collider.gameObject != this.gameObject
                    && hit.collider.gameObject.name == targetPoint.gameObject.name)
                {
                    connectedProduct = hit.collider.gameObject;

                    Debug.Log(hit.collider.gameObject.name + " is connected");

                    lr.enabled = true;

                    /* 선택된 오브젝트에 라인 연결 */
                    linePoints[1] = hit.collider.gameObject.transform.position;
                    lr.SetPositions(linePoints);
                    this.OnConnectedPoint(hit.collider.gameObject);

                    // Camera Moving
                    Camera.main.transform.position = new Vector3(mousePosition.x, Camera.main.transform.position.y, -10);

                    return;
                }
            }


            if (hit.collider.gameObject == this.gameObject)
            {
                if (connectedProduct == null) return;
            }
        }

        connectedProduct = null; /* 빈 공간 hit */
        Debug.Log("failed to connect");
    }

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        lr.material.color = Color.white;
        lr.widthMultiplier = lineWidth;
        linePoints[0] = transform.position; /* 첫번째 점의 위치는 gameobject */
        lr.positionCount = linePoints.Length;

        
    }

    void Update()
    {
        if (mouseButton)
        {
            lr.enabled = true;

            linePoints[1] = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 10f));

            lr.SetPositions(linePoints);
        }

    }

    private void OnConnectedPoint(GameObject target)
    {
        LineRenderer lrobj;

        target.AddComponent<LineRenderer>();
        target.AddComponent<LineConnect>();
    }
}
