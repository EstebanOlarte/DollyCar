using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    private ManagerPC managerPC;
    public float speed;
    public HingeJoint2D joint;
    public LineRenderer line;
    public SpriteRenderer pivote;

    Rigidbody2D rb;
    public bool gameOver;
    bool si = true;
    public TrailRenderer trail1, trail2;
    public ParticleSystem smoke;


    // Use this for initialization
    void Start()
    {
        managerPC = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ManagerPC>();
        rb = GetComponent<Rigidbody2D>();
        smoke.emissionRate = 0;

        line.enabled = false;
        pivote.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            rb.velocity = transform.up * speed;

            if (Input.GetMouseButtonUp(0))
            {
                rb.angularVelocity = 0;

                joint.enabled = false;
                line.enabled = false;
                pivote.enabled = false;

                trail1.emitting = false;
                trail2.emitting = false;
                smoke.emissionRate = 0;
            }

            if (Input.GetMouseButtonDown(0))
            {



                /*si = ((rb.velocity.x <= 0 && joint.transform.position.y < transform.position.y) ||
                       (rb.velocity.y > 0 && joint.transform.position.x < transform.position.x) ||
                       (rb.velocity.x > 0 && joint.transform.position.y > transform.position.y) ||
                       (rb.velocity.y <= 0 && joint.transform.position.x > transform.position.x));
                       */
            }
            if (Input.GetMouseButton(0))
            {
                trail1.emitting = true;
                trail2.emitting = true;
                smoke.emissionRate =13 ;
                if (rb.angularVelocity < 0)
                    si = false;
                else if (rb.angularVelocity > 0)
                    si = true;

                if (si)
                {
                    transform.right = Vector3.Lerp(transform.right, (transform.position - joint.transform.position).normalized, Time.deltaTime * 5);

                }
                else
                {
                    transform.right = Vector3.Lerp(transform.right, -(transform.position - joint.transform.position).normalized, Time.deltaTime * 5);

                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Muro")
        {

            joint.gameObject.SetActive(false);
            managerPC.GameOver();
            gameOver = true;
        }
    }
}
