using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] private float interval;

    private LineRenderer lineRenderer;

    private float time;
    private int intTime;
    private bool isButtonHeld;
    private bool isEnable;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        time = 0f;
        isButtonHeld = false;
        isEnable = false;

        //StartCoroutine(ApplyPulse());
    }

    // Update is called once per frame
    void Update()
    {
        if(isButtonHeld && !isEnable)
        {
            StartCoroutine(ApplyPulse());
            isEnable = true;
        }
        else if(!isButtonHeld && isEnable)
        {
            StopCoroutine(ApplyPulse());
            isEnable = false;
        }
    }

    void SetLineYPos()
    {
        // lineRenderer.SetPosition(1, new Vector3(-6, 3, 0));
    }

    void SetRandLineYPos(int index)
    {
        Vector3 randPos = new Vector3(index, Random.Range(-2, 2), 0);
        lineRenderer.SetPosition(index, randPos);
    }

    void SetSinLineYPos(int index)
    {
        Vector3 sinPos = new Vector3(index, 3 * Mathf.Sin(Time.time), 0);
        lineRenderer.SetPosition(index, sinPos);
    }

    IEnumerator ApplyPulse()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while(isButtonHeld)
        {
            SetRandLineYPos(intTime);
            intTime++;
            if(intTime >= 15)
            {
                intTime = 0;
                isButtonHeld = false;
            }
            yield return wait;
        }
    }

    public bool GetButtonState() { return isButtonHeld; }
    public void SetButtonState(bool value) { isButtonHeld = value; }
}
