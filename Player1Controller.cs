using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller: MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 35f;

    private float currentacceleration = 0f;
    private float currentbreakingForce = 0f;
    private float currentTurnAngleLeft = 0f;
    private float currentTurnAngleRight = 0f;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) currentacceleration = -acceleration * 1 * Time.deltaTime *100;
        if (Input.GetKey(KeyCode.S)) currentacceleration = acceleration * 1 * Time.deltaTime * 100;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentbreakingForce = breakingForce*100;
        } else {
            currentbreakingForce = 0f;
        }

        frontRight.motorTorque = currentacceleration;
        frontLeft.motorTorque = currentacceleration;

        frontRight.brakeTorque = currentbreakingForce;
        frontLeft.brakeTorque = currentbreakingForce;
        backRight.brakeTorque = currentbreakingForce;
        backLeft.brakeTorque = currentbreakingForce;

        if (Input.GetKey(KeyCode.A)) {
            currentTurnAngleLeft = -maxTurnAngle * 1; 
        } else {
            currentTurnAngleLeft = 0f; 
        }

        if (Input.GetKey(KeyCode.D))
        {
            currentTurnAngleRight = maxTurnAngle * 1;
        } else {
            currentTurnAngleRight = 0f;
        }

        frontLeft.steerAngle = currentTurnAngleLeft;
        frontRight.steerAngle = currentTurnAngleRight;
    }

}