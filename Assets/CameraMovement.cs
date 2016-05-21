using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    float speed = 50f;

    void Update()
    {
        var v3 = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        transform.Translate(v3 * speed * Time.deltaTime);

        if (Input.GetMouseButton(1))
        {            
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }

    void Start()
    {
    }
}
