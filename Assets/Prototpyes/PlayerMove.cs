using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;

    [SerializeField] private Transform destination;
    [Space]
    [SerializeField] private float speed;

    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }
        
    }

    public void SetWalking()
    {
        isWalking = true;
        animator.SetBool("isWalking", true);
    }

    public void StopWalking()
    {
        isWalking = false;
        animator.SetBool("isWalking", false);
    }
}
