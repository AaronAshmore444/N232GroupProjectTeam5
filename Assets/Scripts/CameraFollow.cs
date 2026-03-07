using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private Transform Target;
    //Creates field variable to choose camera to follow target
    [SerializeField] private Transform CameraMove;
    // Creates variable to offset camera from player
    [SerializeField] private Vector3 Offset;
    //Creates variable to choose smooth camera speed
    [SerializeField] private float smoothTime;
    //Creates variable for camera velocity
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {   //Moves camera to player + the offset position
        Vector3 targetPosition = Target.position + Offset;
        //Moves the camera smoothly
        CameraMove.position = Vector3.MoveTowards(CameraMove.position, targetPosition, smoothTime);
        //Rotates the camera towards the player
        //transform.LookAt(Target);
        CameraMove.rotation = Quaternion.RotateTowards(CameraMove.rotation, Target.rotation, smoothTime);
    }
}
