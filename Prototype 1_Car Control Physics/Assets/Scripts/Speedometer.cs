using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    public Rigidbody vehicleRb;
    public WheelCollider vehicleWheelCol;

    private float vehicleSpeed;
    private float vehicleRPM;

    [SerializeField] float maxVehicleSpeed;
    [SerializeField] float maxVehicleRPM;

    [SerializeField] float minArrowAngle;
    [SerializeField] float maxArrowAngle;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] RectTransform speedArrow;
    [SerializeField] RectTransform rpmArrow;

    private void Update()
    {
        //getting vehicle speed using the vehicles rigidbody and rounding it to an integer
        vehicleSpeed = Mathf.Round(vehicleRb.velocity.magnitude * 2.237f); //2.237 gives use mph. For Kmh use 3.6
        vehicleRPM = vehicleWheelCol.rpm / 1000;
        speedText.text = vehicleSpeed.ToString("0") + " mph";
        rpmText.text = vehicleRPM.ToString("0") + " rpm";

        //Updating the rotation of the arrow using the speed of the vehicle and clamping it by its max speed
        if (speedArrow != null)
        {
            speedArrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minArrowAngle, maxArrowAngle, vehicleSpeed / maxVehicleSpeed));
        }

        if (rpmArrow != null)
        {
            rpmArrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minArrowAngle, maxArrowAngle, vehicleWheelCol.rpm / maxVehicleRPM));
        }
    }

}
