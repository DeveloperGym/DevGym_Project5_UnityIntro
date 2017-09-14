using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFakeBounce : MonoBehaviour
{
    #region Unity Editor Fields
    public float Bottom = 0f;
    public float Top = 5f;
    public float Speed = 5f;
    #endregion

    #region Local Properties
    private Transform trans { get; set; }
    private bool MovingUp { get; set; }
    #endregion

    #region Unity Events
    void Awake()
    {
        trans = transform;

        if (trans.localPosition.y <= Bottom) { MovingUp = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.localPosition.y <= Bottom) { MovingUp = true; }
        else if (trans.localPosition.y >= Top) { MovingUp = false; }

        trans.Translate(0, Speed * Time.deltaTime * (MovingUp ? 1 : -1), 0);
    }
    #endregion
}
