using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraPlanetMovement : MonoBehaviour
{

    [SerializeField]
    GameObject cameraObject;
       [SerializeField]
    Material blur;
    private float blurValue = 10;
    //private Button btn1;
    private Vector3 startPosition = new Vector3(0, 0, -1.5f);
    private Vector3 endPosition = new Vector3(0,0.57f,0.63f);
    private Vector3 currentPosition;
    // Use this for initialization
    void Start()
    {
        blur.SetFloat("_Radius",blurValue);
        currentPosition = startPosition;
        cameraObject.transform.position = currentPosition;
        GetComponent<Button>().onClick.AddListener(backToSystem);
        positionSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraObject != null)
        {
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, currentPosition, 0.01f);
            blurValue = Mathf.Lerp(blurValue,0,0.04f);
            blur.SetFloat("_Radius",blurValue);
        }
    }
    void positionSwitch()
    {
        currentPosition = endPosition;
    }
    void backToSystem()
    {
        SceneManager.LoadScene("PlanetSelection");
    }

}
