using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	[SerializeField] private int maxHealth = 10;
	[SerializeField] private List<string> damagingTags =
		new List<string>();
	
	public int CurrentHealth { get; private set; }
	public int MaxHealth { get { return maxHealth; } }

	public event Action DamageTaken;

	private void Awake() {
		CurrentHealth = MaxHealth;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		HandleDamage(other);
	}

	private void HandleDamage(Collider2D other) {
		var validTag = damagingTags.Contains(other.gameObject.tag);
		if (!validTag) {
			return;
		}

		var damager = other.gameObject.GetComponent<Damaging>();
		var projectile = other.gameObject.GetComponent<Projectile>();
		if (damager != null) {
			ResolveDamager(damager);
		} else if (projectile != null) {
			ResolveProjectile(projectile);
		}
	}

	private void ResolveDamager(Damaging damager) {
		if (damager.Target == null || damager.Target == this.gameObject) {
			TakeDamage(damager.Damage);
		}
	}

	private void ResolveProjectile(Projectile projectile) {
		if (projectile.Target == this.gameObject) {
			TakeDamage(projectile.Damage);
		}
	}

	private void TakeDamage(int damageAmount) {
		CurrentHealth = Mathf.Max(0, CurrentHealth - damageAmount);
		SafeEventHandler.SafelyBroadcastAction(ref DamageTaken);
	}
}
