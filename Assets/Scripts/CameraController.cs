using System.Collections;
using System.Collections.Generic;
using MiscUtil.Xml.Linq.Extensions;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] private  Transform objectToFollow;
    //[SerializeField] private  PlayerShipController player;
    [SerializeField] private  Camera camera;
    [Space] 
    [SerializeField] private float cameraMoveSpeed = 10.0f;
    [Space]
    [SerializeField] private  float minCameraSize = 5.0f;
    [SerializeField] private  float maxCameraSize = 25.0f;
    [SerializeField] private  float zoomSpeed = 10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerShipController ship = SpaceManager.instance.activeShip;
        Vector3 targetPosition = new Vector3(ship.transform.position.x, ship.transform.position.y, transform.position.z);
        float distToTargetPos = Vector3.Distance(transform.position, targetPosition);
        if(distToTargetPos > 0.01f)
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);

        float lerpDist = ship.SavedVelocity / ship.MaxLinearVelocity;
        float targetCameraSize = Mathf.Lerp(minCameraSize, maxCameraSize, lerpDist);
        float distToTargetCameraSize = Mathf.Abs(camera.orthographicSize - targetCameraSize);
        if (distToTargetCameraSize > 0.01f)
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetCameraSize, zoomSpeed * Time.deltaTime);
    }
}
