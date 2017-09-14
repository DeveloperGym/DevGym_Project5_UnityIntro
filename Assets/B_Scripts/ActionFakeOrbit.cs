using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFakeOrbit : MonoBehaviour
{
    #region Unity Editor Fields
    public float Speed = 25;
    public bool RotateClockwise = true;
    #endregion

    #region Local Properties
    private Transform trans { get; set; }
    #endregion

    #region Unity Events
    void Awake()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        trans.Rotate(Vector3.up, Speed * Time.deltaTime * (RotateClockwise ? 1 : -1));
    }
    #endregion
}
