using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour {
	public AudioClip ScoreSound;
	public GUIText ScoreText;
	public int CurrentScore = 0;

	public void Score(Ball ball) {
		AudioSource.PlayClipAtPoint(ScoreSound, Vector3.zero);
		CurrentScore++;
		ScoreText.text = "" + CurrentScore;
		ball.RestartBall();
	}
}