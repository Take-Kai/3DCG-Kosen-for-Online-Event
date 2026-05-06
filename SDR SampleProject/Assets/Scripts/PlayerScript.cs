using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  [SerializeField] Animator anim;
    private CharacterController characterController;
    private Vector3 velocity;
    float gravitySpeed = 2f;

    float x,  z;
    float speed = 0.1f;
    public  GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    bool cursorLock = true;
    float minX = -90f, maxX = 90f;

 void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.W))
       {
           transform.position += transform.forward * speed;
       }
       if(Input.GetKey(KeyCode.S))
       {
           transform.position -= transform.forward * speed;
       }
       if(Input.GetKey(KeyCode.D))
       {
           transform.position += transform.right * speed;
       }
       if(Input.GetKey(KeyCode.A))
       {
           transform.position -= transform.right * speed;
       }
    float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
       float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

       cameraRot *= Quaternion.Euler(-yRot, 0, 0);
       characterRot *= Quaternion.Euler(0, xRot, 0);

       cameraRot = ClampRotation(cameraRot);

       cam.transform.localRotation = cameraRot;
       transform.localRotation = characterRot;
       UpdateCursorLock();

       if(characterController.isGrounded)
       {
           velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
       }

       velocity.y += Physics.gravity.y * Time.deltaTime;
       characterController.Move(velocity * gravitySpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        transform.position += cam.transform.forward * z + cam.transform.right * x;
    }

    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }

        else if(Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX,minX,maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);
        return q;
    }

}
