using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerComponenet : MonoBehaviour {

	private Rigidbody rb;
	private int count; 
	public Text countText;
	public Text winText; 

	void Start(){
		
		rb = GetComponent<Rigidbody>();
		count = 0; 
		countText.text = "Count: " + count.ToString (); 
		winText.text = "";
	}
	
	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * 25);
		
		
	}

	void OnTriggerEnter(Collider other){

		//Destroy (other.gameObject);
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			countText.text = "Count: " + count.ToString();
			if(count >= 10){
				winText.text = "WIN!";
			}
		}
	}

}
