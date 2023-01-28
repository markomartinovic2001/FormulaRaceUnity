using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller: MonoBehaviour
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
        if (Input.GetKey(KeyCode.UpArrow)) currentacceleration = -acceleration * 1 * Time.deltaTime *100;
        if (Input.GetKey(KeyCode.DownArrow)) currentacceleration = acceleration * 1 * Time.deltaTime * 100;

        if (Input.GetKey(KeyCode.RightShift))
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

        if (Input.GetKey(KeyCode.LeftArrow)) {
            currentTurnAngleLeft = -maxTurnAngle * 1; 
        } else {
            currentTurnAngleLeft = 0f; 
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentTurnAngleRight = maxTurnAngle * 1;
        } else {
            currentTurnAngleRight = 0f;
        }

        frontLeft.steerAngle = currentTurnAngleLeft;
        frontRight.steerAngle = currentTurnAngleRight;
    }

}