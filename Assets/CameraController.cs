using System.Collections;
using System.Collections.Generic;
using MiscUtil.Xml.Linq.Extensions;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objectToFollow;
    public PlayerShipController player;
    public Camera camera;

    public float minCameraSize = 5.0f;
    public float maxCameraSize = 25.0f;
    public float zoomSpeed = 10.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, transform.position.z);

        float lerpDist = player.SavedVelocity / player.MaxLinearVelocity;
        float targetCameraSize = Mathf.Lerp(minCameraSize, maxCameraSize, lerpDist);
        float distToTargetCameraSize = Mathf.Abs(camera.orthographicSize - targetCameraSize);
        if (distToTargetCameraSize > 0.01f)
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetCameraSize, zoomSpeed * Time.deltaTime);
    }
}
