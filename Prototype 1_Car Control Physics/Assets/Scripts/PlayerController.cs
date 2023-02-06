using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    //[SerializeField] private float speed;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;
    [SerializeField] float acceleration;
    [SerializeField] float brakingForce;
    [SerializeField] float maxTurnAngle;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform rearRightTransform;
    [SerializeField] Transform rearLeftTransform;

    private float horizontalInput;
    private float forwardInput;
    private bool isBraking;

    private float currentAccel = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;



    // Update is called once per frame
    void FixedUpdate()
    {

        CarInput();
        MotorAccel();
        Steering();

    }

    private void CarInput() //Assigns forward input, steering input, and braking input
    {

        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        isBraking = Input.GetKey(KeyCode.Space);

    }

    private void MotorAccel() //Get forward accel and braking parameters, AWD car
    {
        currentAccel = acceleration * forwardInput;
        frontRight.motorTorque = currentAccel;
        frontLeft.motorTorque = currentAccel;
        rearRight.motorTorque = currentAccel;
        rearLeft.motorTorque = currentAccel;


        //Braking logic
        if (isBraking)
        {
            currentBrakeForce = brakingForce;
        }
        else
        {
            currentBrakeForce = 0;
        }

        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        rearRight.brakeTorque = currentBrakeForce;
        rearLeft.brakeTorque = currentBrakeForce;

    }

    private void Steering()
    {
        //Assign steering to wheel colliders
        currentTurnAngle = maxTurnAngle * horizontalInput;
        frontRight.steerAngle = currentTurnAngle;
        frontLeft.steerAngle = currentTurnAngle;

        //Updates wheel meshes to match collider steering angle
        UpdateWheels(frontRight, frontRightTransform);
        UpdateWheels(frontLeft, frontLeftTransform);
        UpdateWheels(rearRight, rearRightTransform);
        UpdateWheels(rearLeft, rearLeftTransform);
    }

    private void UpdateWheels(WheelCollider wheelCol, Transform wheelTrans)
    {
        //Get wheel collider state
        Vector3 pos;
        Quaternion rotation;
        wheelCol.GetWorldPose(out pos, out rotation);

        //Gets wheel transfrom state
        wheelTrans.position = pos;
        wheelTrans.rotation = rotation;
    }


}

