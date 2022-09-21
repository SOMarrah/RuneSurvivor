using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    int isMovingHash;
    public float speed;
    public float rotationSpd;
    // public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isMovingHash = Animator.StringToHash("isMoving");
    }
    void lookAtMouse(){
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if(playerplane.Raycast(ray, out hitdist)){
            Vector3 targetpoint = ray.GetPoint(hitdist);
            Quaternion targetrotation = Quaternion.LookRotation(targetpoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, rotationSpd *Time.deltaTime);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        bool isMoving = animator.GetBool(isMovingHash);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        lookAtMouse();
        Vector3 movementDirection = new Vector3(horizontalInput, 0 , verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        if(movementDirection != Vector3.zero){
            // transform.forward = movementDirection
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);
            animator.SetBool(isMovingHash, true);
        }
        else
        {
            animator.SetBool(isMovingHash, false);
        }
    }
}
