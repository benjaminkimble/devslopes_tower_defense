using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(Damageable)),
	RequireComponent(typeof(Targetable))
]
public class CastleController : MonoBehaviour {

	private Damageable damageableBehaviour;
	private Targetable targetableBehaviour;

	public event Action DamageTaken;

	private void Start() {
		damageableBehaviour = GetComponent<Damageable>();
		targetableBehaviour = GetComponent<Targetable>();

		damageableBehaviour.DamageTaken += OnDamageTaken;
	}

	private void OnDamageTaken() {
		if (damageableBehaviour.CurrentHealth <= 0) {
			targetableBehaviour.Disable();
		}
		SafeEventHandler.SafelyBroadcastAction(ref DamageTaken);
	}
}
