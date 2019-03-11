using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausableTimer : MonoBehaviour {
	
	public float Timer { get; private set; }
	
	protected void Start () {
		ResetTimer();
	}
	
	protected void Update () {
			Timer += Time.deltaTime;
	}

	protected void ResetTimer() {
		Timer = 0.0f;
	}

	protected IEnumerator WaitForTime(float timeToWait) {
		var timer = 0.0f;
		while (timer <= timeToWait) {
			timer += Time.deltaTime;
			yield return null;
		}

		yield return null;
	}
}
