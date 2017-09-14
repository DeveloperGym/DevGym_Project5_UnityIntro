using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBetterBounce : MonoBehaviour
{
    #region Unity Editor Fields
    public float Bottom = 0f;
    public float Top = 5f;
    #endregion

    #region Local Fields
    private float yVelocity;
    #endregion

    #region Local Properties
    private Transform trans { get; set; }
    private float TargetY { get; set; }
    #endregion

    #region Unity Events
    void Awake()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.localPosition.y <= Bottom) { TargetY = Top; }
        else if (trans.localPosition.y >= Top) { TargetY = Bottom; }

        var pos = trans.localPosition;
        if (Mathf.Abs(pos.y-TargetY) < 0.02f)
        {
            pos.y = TargetY;
        }
        else
        {
            pos.y = Mathf.SmoothDamp(pos.y, TargetY, ref yVelocity, 0.3f);
        }
        trans.localPosition = pos;
    }
    #endregion
}
