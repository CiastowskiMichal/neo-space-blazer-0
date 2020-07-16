using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuHandler : MonoBehaviour
{

    [SerializeField]
    Button startTestLevel;
    [SerializeField]
    GameObject menuArtifact;
    [SerializeField]
    GameObject sunSprite;
	    [SerializeField]
    GameObject titleSprite;
		    [SerializeField]
    Image Fade;
    private float counter = 0;
	private Vector3 titleStartPosition = new Vector3(0,1.4f,-8f);
	private Vector3 titleEndPosition = new Vector3(0,2.4f,-2.9f);
    // Use this for initialization
    void Start()
    {
        if (startTestLevel != null)
        {
            startTestLevel.onClick.AddListener(loadTestLevel);
        }
		if(titleSprite!=null)
		{
			titleSprite.transform.position = titleStartPosition;
		}
		if(Fade !=null)
		{
			Fade.color = new Vector4(0,0,0,1);
			Fade.GetComponent<RectTransform>().sizeDelta = new Vector2(1280,720);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (menuArtifact != null && sunSprite != null)
        {
            counter += Time.deltaTime;
            menuArtifact.transform.Rotate(0, 0, -0.2f);
            sunSprite.transform.position = new Vector3(0, -1 + 0.2f * Mathf.Sin(counter), 4);
        }
		if(titleSprite!=null && Fade!=null)
		{
			titleSprite.transform.position = Vector3.Lerp(titleSprite.transform.position,titleEndPosition,0.03f);
			Fade.color = new Vector4(0,0,0,Mathf.Lerp(Fade.color.a,0,0.15f));
		}
    }
    void loadTestLevel()
    {
        SceneManager.LoadScene("baseScene");
    }
}
