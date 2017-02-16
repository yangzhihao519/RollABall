using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text timeText;

    private Rigidbody rb;

	private int count;
	private float timer;
	private bool increaseTime;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;
		timer = 0;
		SetCountText ();
		winText.text = "";
		increaseTime = true;
		SetTimerText();
    }

	void Update ()
	{
		if (increaseTime) 
		{
			timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
			SetTimerText();
		}
	} 

	// called before performing any physics calculations
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed); 
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You win! You used " + timer.ToString() + " s";
			increaseTime = false;
			timeText.text = "";
		}
	}

	void SetTimerText ()
	{
		timeText.text = "Time: " + timer.ToString() + " s";
	}
}



	