using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public static GrabObject instance;

    [SerializeField]
    private Transform grabPosition;
    private GameObject grabObject;
    private GameObject grabbedObject;
    private bool canGrab = false;
    public bool isGrabbing = false;
    [SerializeField]
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (canGrab)
            {
                playerAnim.SetBool("grab", true);
                grabbedObject = grabObject;
                grabObject = null;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.GetComponent<Rigidbody2D>().simulated = false;
                grabbedObject.transform.SetParent(this.transform);
                canGrab = false;
                isGrabbing = true;

            }

            else
            {
                if (isGrabbing)
                {
                    playerAnim.SetBool("grab", false);
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbedObject.GetComponent<Rigidbody2D>().simulated = true;
                    grabbedObject.transform.SetParent(null);
                    grabbedObject = null;
                    isGrabbing=false;

                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Object") && grabbedObject == null)
        {
            canGrab = true;
            grabObject = collision.gameObject;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Object") && grabObject == collision.gameObject)
        {
            grabObject = null;
            canGrab = false;
        }
    }


}
