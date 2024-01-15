using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class test : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            animator.SetBool("walking", true);
        }
    

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            animator.SetBool("walking", true);
        }
     

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            animator.SetBool("walking", true);
        }
    
    }
}
