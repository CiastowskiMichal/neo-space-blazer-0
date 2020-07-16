using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPlanetChoose : MonoBehaviour
{
    [SerializeField]
    GameObject cameraRotation;
    [SerializeField]
    Material blur;
    private float blurValue = 0;

    [SerializeField]
    Camera camera;
    //private Button btn1;
    private Vector3 startPosition = new Vector3(0, 2.06f, -6.25f);
    //[SerializeField]
    GameObject Planet3;
    //private Vector3 endPosition = new Vector3(0, 0.048f, -0.549f);
    //private Vector3 currentPosition;
    private bool toPlanet = false;


    // Use this for initialization
    void Start()
    {
        blur.SetFloat("_Radius",blurValue);
        cameraRotation.transform.position = camera.transform.position;
        camera.transform.position = startPosition;
        //GetComponent<Button>().onClick.AddListener(positionSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "_planetTag")
                {
                    Debug.Log(hit.transform.GetSiblingIndex());
                    foreach (Transform planet in transform)
                    {
                        planet.gameObject.GetComponent<SphereCollider>().enabled = false;
                    }
                }
				transform.GetChild(hit.transform.GetSiblingIndex()).transform.GetComponent<SphereCollider>().enabled=true;
				toPlanet=true;
				Planet3 = transform.GetChild(hit.transform.GetSiblingIndex()).transform.gameObject;
            }
        }
        cameraRotation.transform.position = camera.transform.position;
        if (camera != null && toPlanet)
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, Planet3.transform.position, 0.02f);
            cameraRotation.transform.LookAt(Planet3.transform.position, Vector3.up);
            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, cameraRotation.transform.rotation, 0.2f);
            blurValue = Mathf.Lerp(blurValue,10,0.01f);
            blur.SetFloat("_Radius",blurValue);

            //camera.transform.rotation = Planet3.transform.rotation;
        }
    }
    void positionSwitch()
    {
        toPlanet = true;
        //currentPosition = Planet3.transform.position;
    }
}
