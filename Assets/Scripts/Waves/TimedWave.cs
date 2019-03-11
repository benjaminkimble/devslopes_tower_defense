using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedWave : Wave {

	[SerializeField] private float completionDelay = 15.0f;

	protected override IEnumerator HandleCompletionLogic() {
		yield return WaitForTime(completionDelay);
		HandleCompletion(true);
	}
}
