using UnityEngine;
using System.Collections;

public class PaddleBounce : MonoBehaviour {
	public AudioClip HitSound;

	public void Hit() {
		AudioSource.PlayClipAtPoint(HitSound, Vector3.zero);
	}
}