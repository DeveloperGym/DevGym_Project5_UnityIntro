using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    #region Unity Editor Fields
    public Transform MainCamera;
    public Vector3[] CameraPositions;
    #endregion

    #region Local Fields
    private int _CameraPositionIndex = 0;
    #endregion

    #region Local Properties
    private int CameraPositionIndex
    {
        get { return _CameraPositionIndex; }
        set
        {
            if (value < 0) { value = CameraPositions.Length - 1; }
            else if (value >= CameraPositions.Length) { value = 0; }
            _CameraPositionIndex = value;
        }
    }

    private Vector3? TargetPosition { get; set; }
    #endregion

    #region Unity Events
    void Update()
    {
        // Move smoothly from current position to desired postion
        if (TargetPosition.HasValue)
        {
            if ((MainCamera.localPosition - TargetPosition.Value).magnitude < 0.01f)
            {
                MainCamera.localPosition = TargetPosition.Value;
                TargetPosition = null;
            }
            else
            {
                // Moves the camera from the current position, towards the target position, using a linear extrapolation algorithm, which moves faster in the middle, and slower near the end
                MainCamera.localPosition = Vector3.Lerp(MainCamera.localPosition, TargetPosition.Value, Time.deltaTime);
            }
        }
    }
    #endregion

    #region Button Methods
    public void NextView()
    {
        if (MainCamera == null) { return; }

        CameraPositionIndex++;
        TargetPosition = CameraPositions[CameraPositionIndex];
    }

    public void PrevView()
    {
        if (MainCamera == null) { return; }

        CameraPositionIndex--;
        TargetPosition = CameraPositions[CameraPositionIndex];
    }
    #endregion
}
