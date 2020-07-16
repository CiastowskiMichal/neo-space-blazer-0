using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    [SerializeField]
    bool isPassable;
    private bool isOpening = false;
    [SerializeField]
    GameObject leftDoor;
    [SerializeField]
    GameObject rightDoor;
    private Vector3 leftStartingPose = new Vector3(0, 0, 0);
    private Vector3 rightStartingPose = new Vector3(0, 0, 0);
    private Vector3 leftDoorOpened = new Vector3(6, 0, 0);
    private Vector3 rightDoorOpened = new Vector3(-6, 0, 0);
    [SerializeField]
    Light light1;
    [SerializeField]
    Light light2;
    private float lightIntensity = 0;
    // Use this for initialization
    void Start()
    {
        if (leftDoor != null && rightDoor != null && light1 != null && light2 != null)
        {
            leftDoor.transform.localPosition = leftStartingPose;
            rightDoor.transform.localPosition = rightStartingPose;
            light1.intensity = lightIntensity;
            light2.intensity = lightIntensity;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isPassable)
        {
            leftStartingPose = new Vector3(0.2f, 0, 0);
            rightStartingPose = new Vector3(-0.2f, 0, 0);
            lightIntensity = 2;

        }
        else
        {
            leftStartingPose = new Vector3(0, 0, 0);
            rightStartingPose = new Vector3(0, 0, 0);
            lightIntensity = 0;
        }
        if (leftDoor != null && rightDoor != null)
        {
            if (isOpening)
            {
                leftDoor.transform.localPosition = Vector3.Lerp(leftDoor.transform.localPosition, leftDoorOpened, 0.1f);
                rightDoor.transform.localPosition = Vector3.Lerp(rightDoor.transform.localPosition, rightDoorOpened, 0.1f);
                light1.intensity = Mathf.Lerp(light1.intensity, 0, 0.1f);
                light2.intensity = Mathf.Lerp(light2.intensity, 0, 0.1f);
            }
            else
            {
                leftDoor.transform.localPosition = Vector3.Lerp(leftDoor.transform.localPosition, leftStartingPose, 0.1f);
                rightDoor.transform.localPosition = Vector3.Lerp(rightDoor.transform.localPosition, rightStartingPose, 0.1f);
                light1.intensity = Mathf.Lerp(light1.intensity, lightIntensity, 0.1f);
                light2.intensity = Mathf.Lerp(light2.intensity, lightIntensity, 0.1f);
            }
        }
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (isPassable)
        {
            if (other.gameObject.tag == "_playerController")
            {
                isOpening = true;
            }
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if (isPassable)
        {
            if (other.gameObject.tag == "_playerController")
            {
                isOpening = false;
            }
        }
    }
}
