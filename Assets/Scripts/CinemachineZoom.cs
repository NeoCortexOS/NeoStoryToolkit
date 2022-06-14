using UnityEngine;
using Cinemachine;

public class CinemachineZoom : MonoBehaviour
{
    public CinemachineFramingTransposer playerzoomcam;
    public float scrollSensitivity = 3;
    public float lerpSpeed = 10;
    public float minDistance = 5;
    public float maxDistance = 30;
    public float targetDistance;

    void SetTargetDistance(float value)
    {
        targetDistance = Mathf.Clamp(value, minDistance, maxDistance);
    }

    private void Awake()
    {
        playerzoomcam = this.GetComponentInChildren<CinemachineFramingTransposer>();
        targetDistance = playerzoomcam.m_CameraDistance;
        //print("distance: " + playerzoomcam.m_CameraDistance);
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0.01f)
        {
            SetTargetDistance(targetDistance - scrollSensitivity);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < -0.01f)
        {
            SetTargetDistance(targetDistance + scrollSensitivity);
        }

        playerzoomcam.m_CameraDistance = Mathf.Lerp(
            playerzoomcam.m_CameraDistance, targetDistance, Time.deltaTime * lerpSpeed);

    }
}