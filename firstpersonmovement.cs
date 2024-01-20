using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstpersonmovement : MonoBehaviour
{
    public float ypos;
    public Vector3 positionadd = new Vector3();
    public float speed;
    public Vector3 position = new Vector3();
    public GameObject camera;
    public bool movementenabled = true;
    public Rigidbody rb;
    public Vector3 rotation;
    public float rot;
    public InputField gptinput;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        movementenabled = (!gptinput.isFocused);
        if (movementenabled)
        {
            if (Input.GetAxis("Vertical") != 0f)
            {
                positionadd = transform.right * speed * Time.deltaTime;
                ypos = transform.position.y;
                position = transform.position + positionadd;
                transform.position = new Vector3(position.x, ypos, position.z);
            }
            if (Input.GetAxis("Horizontal") != 0f)
            {
                positionadd = -transform.forward * speed * Time.deltaTime;
                ypos = transform.position.y;
                position = transform.position + positionadd;
                transform.position = new Vector3(position.x, ypos, position.z);
            }
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.05f)
            {
                rb.velocity += new Vector3(0, 5f, 0);
            }

            rotation = new Vector3(0f, Input.GetAxis("Mouse X"), 0);
            transform.Rotate(rotation);
            rot += Input.GetAxisRaw("Mouse Y");
            rot = Mathf.Clamp(rot, -90f, 90f);
            camera.transform.localRotation = Quaternion.Euler(-rot, 0f, 0f);
        }
    }
}
