using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBetterOrbit : MonoBehaviour
{
    #region Unity Editor Fields
    public float OrbitSpeed = 2.5f;
    public bool RotateClockwise = true;
    #endregion

    #region Constants
    const float MAX_RAD = 2f * Mathf.PI;
    #endregion

    #region Local Fields
    protected float _OrbitAngle = 0f;
    #endregion

    #region Local Properties
    protected Transform trans { get; set; }

    private float OrbitDistance { get; set; }

    public float OrbitAngle
    {
        get { return _OrbitAngle; }
        set
        {
            _OrbitAngle = value;
            while (_OrbitAngle > MAX_RAD) { _OrbitAngle -= MAX_RAD; }
            while (_OrbitAngle < 0) { _OrbitAngle += MAX_RAD; }
        }
    }
    #endregion

    #region Unity Events
    void Awake()
    {
        trans = transform;
        OrbitDistance = trans.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAngle += OrbitSpeed * Time.deltaTime * (RotateClockwise ? 1 : -1);
        var pos = new Vector3(Mathf.Cos(OrbitAngle), 0, Mathf.Sin(OrbitAngle)) * OrbitDistance;
        pos.y = trans.localPosition.y;
        trans.localPosition = pos;
    }
    #endregion
}
