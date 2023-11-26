using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject lineObj;
    private Pulse lineScr;
    // Start is called before the first frame update
    void Start()
    {
        lineScr = lineObj.GetComponent<Pulse>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Impulse()
    {
        lineScr.SetButtonState(true);
    }
}
