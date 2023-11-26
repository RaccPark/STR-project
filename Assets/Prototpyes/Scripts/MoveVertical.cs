using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MoveVertical : MonoBehaviour
{
    private float platformPos;
    [SerializeField] private float delta;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        platformPos = this.transform.position.y;
        Vector3 v = new Vector2(transform.position.x, this.platformPos);
        this.transform.position = v;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        Vector3 v = new Vector3(transform.position.x, this.platformPos, transform.position.z);
        v.y = delta * Mathf.Sin(Time.time * speed) + this.platformPos;
        transform.position = v;
    }
}
