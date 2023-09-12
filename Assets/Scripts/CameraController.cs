using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Vector2 cameraTurn;
    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private RectTransform crossTrans;

    private void Start()
    {
        crosshair.transform.localPosition = new Vector3(0, 0, 0);
        crossTrans = crosshair.GetComponent<RectTransform>();

    }

    private void LateUpdate()
    {
        crosshair.transform.localPosition += new Vector3(joystick.Direction.x * cameraSpeed, joystick.Direction.y * cameraSpeed, 0);

        Vector2 crossAnchor = crossTrans.anchoredPosition;
        float xpos = crossAnchor.x;
        float ypos = crossAnchor.y;
        xpos = Mathf.Clamp(xpos, -(Screen.width - crossTrans.sizeDelta.x) / xBounds, (Screen.width - crossTrans.sizeDelta.x) / xBounds);
        ypos = Mathf.Clamp(ypos, -(Screen.width - crossTrans.sizeDelta.y) / yBounds, (Screen.width - crossTrans.sizeDelta.y) / yBounds);
        crossAnchor.x = xpos;
        crossAnchor.y = ypos;
        crossTrans.anchoredPosition = crossAnchor;

    }
}
