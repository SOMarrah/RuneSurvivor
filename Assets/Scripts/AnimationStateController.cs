using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isMovingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isMovingHash = Animator.StringToHash("isMoving");
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = animator.GetBool(isMovingHash);

        bool forwardPressed = Input.GetKey("w");

        if(!isMoving && forwardPressed){

            animator.SetBool(isMovingHash, true);

        }
        if(isMoving && !forwardPressed){

            animator.SetBool(isMovingHash, false);

        }
    }
}
