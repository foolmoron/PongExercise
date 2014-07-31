using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	[Range(0, 10)]
	public float MovementRange = 4.6f;
	[Range(0, 10)]
	public float MovementSpeed = 5f;

	public GameObject Instructions;
	
	void Update() {
		var newPosition = transform.position;
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			newPosition.y += MovementSpeed * Time.deltaTime;
			if (newPosition.y > MovementRange/2) {
				newPosition.y = MovementRange/2;
			}
			transform.position = newPosition;
			Instructions.SetActive(false);
		} else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			newPosition.y -= MovementSpeed * Time.deltaTime;
			if (newPosition.y < -MovementRange/2) {
				newPosition.y = -MovementRange/2;
			}
			transform.position = newPosition;
			Instructions.SetActive(false);
		}
	}
}