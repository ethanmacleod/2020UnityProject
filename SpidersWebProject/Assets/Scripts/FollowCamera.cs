using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    // floats for the camera boundry
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    // variable for the background cheese im going to do
    public Image backgroundImage;


    void Start()
    {
        cameraOffset = new Vector3(0, 0, -20);

        transform.position = player.position + cameraOffset;




    }

    void FixedUpdate()
    {
        Vector3 finalPosition = player.position + cameraOffset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
        transform.position = lerpPosition;

        // Camera boundry
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );

    }

    private void OnDrawGizmos()
    {
        // draw a box arounf the camera boundry
        Gizmos.color = Color.red;
        // top boundry line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        // right boundry line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        // bottom boundry line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left boundry line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));
    }

}