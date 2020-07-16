using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    float counter = 0;
    [SerializeField]
    [Range(0, 5)]
    float range = 0;
    //[SerializeField]
    //[Range(0, 1)]
    float speed = 0;
    // Use this for initialization
    void Start()
    {
        counter = Random.Range(0, 25);
        speed = Random.Range(0,0.3f);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(Camera.main.transform.position);
        if (range != 0)
        {
            transform.position = new Vector3(range * Mathf.Sin(counter), 0, range * Mathf.Cos(counter));
            counter += speed * Time.deltaTime / range;
        }

    }
}
