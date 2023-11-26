using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using System.Runtime.InteropServices;


public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetMousePos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetMousePos()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return (new WaitForSeconds(0.5f));
        Cursor.lockState = CursorLockMode.None;
    }
}
