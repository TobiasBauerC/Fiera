using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.Animations;

public class PlanetArrow : MonoBehaviour
{
    [SerializeField] private Transform lookAtTarget;
    [SerializeField] private Camera uiCamera;
    [SerializeField] private float screenEdgeBuffer = 50.0f;

    private RectTransform arrowRectTransform;

    void Start()
    {
        arrowRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 toPosition = lookAtTarget.position;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = GetAngleFromVector(dir);

        arrowRectTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(lookAtTarget.position);
        
        Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
        if (cappedTargetScreenPosition.x <= screenEdgeBuffer) cappedTargetScreenPosition.x = screenEdgeBuffer;
        if (cappedTargetScreenPosition.x >= Screen.width - screenEdgeBuffer) cappedTargetScreenPosition.x = Screen.width - screenEdgeBuffer;
        if (cappedTargetScreenPosition.y <= screenEdgeBuffer) cappedTargetScreenPosition.y = screenEdgeBuffer;
        if (cappedTargetScreenPosition.y >= Screen.height - screenEdgeBuffer) cappedTargetScreenPosition.y = Screen.height - screenEdgeBuffer;

        arrowRectTransform.position = cappedTargetScreenPosition;
        arrowRectTransform.localPosition =
            new Vector3(arrowRectTransform.localPosition.x, arrowRectTransform.localPosition.y, 0f);
    }

    float GetAngleFromVector(Vector3 dir)
    {
        return (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
    }
}
