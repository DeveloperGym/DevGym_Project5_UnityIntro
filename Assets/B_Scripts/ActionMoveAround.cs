using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveAround : MonoBehaviour
{
    #region Unity Editor Fields
    public Transform[] Targets;
    public float TurnSpeed = 15;
    #endregion

    #region Local Properties
    private Transform trans { get; set; }

    public Transform CurrentTarget { get; set; }

    public State CurrentState { get; set; }
    #endregion

    #region Local Enums
    public enum State { Targeting, Moving, Spinning };
    #endregion

    #region Unity Events
    void Awake()
    {
        trans = transform;

        CurrentState = State.Targeting;
        CurrentTarget = Targets[Random.Range(0, Targets.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case State.Targeting:
                Targeting();
                break;
            case State.Moving:
                Moving();
                break;
            case State.Spinning:
                Spinning();
                break;
        }
    }
    #endregion

    #region Methods
    private void Targeting()
    {
        var q = Quaternion.LookRotation(CurrentTarget.position - trans.position);

        var Angle = Quaternion.Angle(trans.localRotation, q);
        if (Angle > 0.5f)
        {
            trans.rotation = Quaternion.RotateTowards(trans.rotation, q, TurnSpeed * Time.deltaTime);
        }
        else
        {
            trans.localRotation = q;
            CurrentState = State.Moving;
        }
    }

    private void Moving()
    {
        var Distance = (trans.localPosition - CurrentTarget.localPosition).magnitude;

        if (Distance > 0.1f)
        {
            trans.localPosition = Vector3.Lerp(trans.localPosition, CurrentTarget.localPosition, Time.deltaTime);
        }
        else
        {
            trans.localPosition = CurrentTarget.localPosition;
            var NewTarget = Targets[Random.Range(0, Targets.Length)];
            while (NewTarget == CurrentTarget)
            {
                NewTarget = Targets[Random.Range(0, Targets.Length)];
            }
            CurrentTarget = NewTarget;
            CurrentState = State.Targeting;
        }
    }

    private void Spinning()
    {
        // TODO: Implement something interesting!
    }
    #endregion
}
