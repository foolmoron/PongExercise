using UnityEngine;
using System.Collections;

public class AIPaddle : MonoBehaviour {

	public GameObject Ball;
	[Range(0, 1)]
	public float BallFollowThreshold = 0.1f;
	[Range(0, 10)]
	public float MovementRange = 4.6f;
	[Range(0, 10)]
	public float MovementSpeed = 5f;
	
	void Update() {
		var newPosition = transform.position;
		var ballY = Ball.transform.position.y;
		var ballDiff = ballY - newPosition.y;
		if (ballDiff > BallFollowThreshold) {
			newPosition.y += MovementSpeed * Time.deltaTime;
			if (newPosition.y > MovementRange/2) {
				newPosition.y = MovementRange/2;
			}
			transform.position = newPosition;
		} else if (ballDiff < -BallFollowThreshold) {
			newPosition.y -= MovementSpeed * Time.deltaTime;
			if (newPosition.y < -MovementRange/2) {
				newPosition.y = -MovementRange/2;
			}
			transform.position = newPosition;
		}
	}
}