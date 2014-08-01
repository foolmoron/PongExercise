using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Ball : MonoBehaviour {

	public Vector2 StartPosition;
	[Range(0, 5)]
	public float StartDelay = 1f;
	[Range(0, 10)]
	public float MovementSpeed = 5f;
	public AudioClip WallHitSound;
	
	new Rigidbody2D rigidbody2D;
	new BoxCollider2D collider2D;

	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<BoxCollider2D>();

		RestartBall();
	}

	public void RestartBall() {
		StartCoroutine(StartBall(StartDelay));
	}

	IEnumerator StartBall(float delay) {
		for (int i = 0; i < 3; i++) { // do this over the course of 3 updates so make sure for real that velocity is 0
			rigidbody2D.velocity = Vector2.zero;
			transform.position = StartPosition;
			yield return new WaitForFixedUpdate();
		}
		yield return new WaitForSeconds(delay);
	    Vector2 startDirection = new Vector2(1f, 1f * Random.value);
        rigidbody2D.velocity = startDirection.normalized * MovementSpeed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		var paddleBounce = other.gameObject.GetComponent<PaddleBounce>();
		var winZone = other.gameObject.GetComponent<WinZone>();
		if (paddleBounce) { // do special Pong-like bounce when interacting with paddles
			paddleBounce.Hit();

			// change angle of velocity based on Y diff of contact
			var paddleSize = paddleBounce.transform.localScale.y / 10;
			var contactYDiff = transform.position.y - paddleBounce.transform.position.y;
			var contactYDiffNormalized = contactYDiff / (paddleSize/2);

			var newVelocity = new Vector2(-rigidbody2D.velocity.x, contactYDiffNormalized * MovementSpeed).normalized * MovementSpeed;
			rigidbody2D.velocity = newVelocity;
		} else if (winZone) { // add score and restart game
			winZone.Score(this);
		} else { // just regular wall, do basic bounce
			AudioSource.PlayClipAtPoint(WallHitSound, Vector3.zero);
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -rigidbody2D.velocity.y);
		}
	}

	void Update() {
		var vel = rigidbody2D.velocity;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(StartPosition, 0.2f);
	}
}
