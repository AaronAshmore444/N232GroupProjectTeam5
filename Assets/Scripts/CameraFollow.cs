using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraRotationSpeed = 240f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //On game start, the cursor is locked and hidden
        Cursor.lockState =CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets mouse direction X and Y
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //Sets mouse rotation X and Y to camera Rotate Speed Variable
        float rotationY = mouseX * GameManager.Instance.PlayerMouseSensitivity * Time.deltaTime;
        float rotationX = - mouseY * GameManager.Instance.PlayerMouseSensitivity * Time.deltaTime;
        //Sets new rotation from rotation X and Y
        float newRotationY = transform.localEulerAngles.y + rotationY;
        float newRotationX = transform.localEulerAngles.x + rotationX;
        //Ensures that rotation stays between 0 and 180.
        if (newRotationX > 180) newRotationX -=360;
        //Clamps Rotation so character spin upsidedown
        newRotationX = Mathf.Clamp(newRotationX, -90f, 90f);
        //Converts rotation to Unity rotation
        transform.localEulerAngles = new Vector3(newRotationX, newRotationY, 0);
    }
}
