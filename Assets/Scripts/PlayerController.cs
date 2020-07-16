using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    [Range(5, 25)]
    float speed;

    [SerializeField]
    Button deleteEngramFromScene;

    private Animator animator;
    private bool isWalking = false;
    private Transform playerTransform;
    private Vector3 playerRotation = new Vector3(0, 0, 0);
    //private float[] directions;
    private float xMove, yMove, speedMultiplier;
    private float yRotation;
    private Rigidbody playerBody;
//    private float timeStamp = 0.02f;
    [SerializeField]
    GameObject playerModel;
    // Use this for initialization
    void Start()
    {
        deleteEngramFromScene.onClick.AddListener(deleteEngram);
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("isWalking", isWalking);
        playerTransform = GameObject.FindGameObjectWithTag("_playerModel").transform;
        playerTransform.rotation = Quaternion.Euler(playerRotation);
        playerBody = GetComponent<Rigidbody>();
        //directions = new float[] { Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") };
    }

    // Update is called once per frame
    void Update()
    {
        if(playerModel != null)
        {
            playerModel.transform.localPosition = new Vector3(0,-1,0);
        }

        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.Euler(playerRotation), 0.5f);

        xMove = Input.GetAxisRaw("Vertical");
        yMove = Input.GetAxisRaw("Horizontal");
        if(Mathf.Sqrt(xMove * xMove + yMove * yMove)>1)
        {
            speedMultiplier = 1;
        }
        else
        {
            speedMultiplier = Mathf.Sqrt(xMove * xMove + yMove * yMove);
        }
        
        
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            isWalking = true;
            //transform.Translate(yMove, 0, xMove);
            yRotation = (float)(Mathf.Atan2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * (180.0 / Mathf.PI));
            playerRotation = new Vector3(0, yRotation - 45, 0);
            //transform.Translate(Mathf.Sin(Mathf.PI * (yRotation) / 180) * Time.deltaTime * speed, 0, Mathf.Cos(Mathf.PI * (yRotation) / 180) * Time.deltaTime * speed);


            //playerBody.velocity = new Vector3(Mathf.Sin(Mathf.PI * (yRotation) / 180) * speed, 0, Mathf.Cos(Mathf.PI * (yRotation) / 180) * speed);

            
            playerBody.velocity = new Vector3(Mathf.Sin(Mathf.PI * (yRotation - 45) / 180) * speed * speedMultiplier, 0, Mathf.Cos(Mathf.PI * (yRotation - 45) / 180) * speed * speedMultiplier);
            animator.SetFloat("speedMultiplyer",speedMultiplier);
            //Debug.Log(playerBody.velocity);
        }
        else
        {
            isWalking = false;
        }
        animator.SetBool("isWalking", isWalking);
        //Debug.Log(isWalking);
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "_lootItem")
        {
            //
            other.gameObject.GetComponent<ItemParamentersContainer>().setDestroyer(true);
            Destroy(other.gameObject);
        }
    }
    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "_lootContainer1")
        {
            other.GetComponent<ContainerHandler>().setSpriteAlpha(0.5f);
            //Debug.Log("Sukces");
            if (Input.GetButtonDown("Jump"))
            {
                other.GetComponent<ContainerHandler>().generateLoot();
            }
        }
        if (other.gameObject.tag == "_questComputer")
        {
            other.GetComponent<questComputerHandler>().setSpriteAlpha(0.5f);
            //Debug.Log("Sukces");
            if (Input.GetButtonDown("Jump"))
            {
                if (other.GetComponent<questComputerHandler>().getTookAll())
                {
                    other.GetComponent<questComputerHandler>().returnQuests();
                }
                else
                {
                    other.GetComponent<questComputerHandler>().takeQuests();
                }

            }
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "_questComputer")
        {
            other.GetComponent<questComputerHandler>().setSpriteAlpha(0);
        }
        if (other.gameObject.tag == "_lootContainer1")
        {
            other.GetComponent<ContainerHandler>().setSpriteAlpha(0);
        }
    }
    void deleteEngram()
    {
        Destroy(GameObject.FindGameObjectWithTag("_lootItem"));
    }
}
