using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullCompletionWave : Wave {

    [SerializeField] private List<string> observedTags =
        new List<string>() {
            "Enemy"
        };

    private List<Damageable> observedDamageables = new List<Damageable>();
    
    protected override IEnumerator HandleCompletionLogic() {
        var damageables = FindObjectsOfType<Damageable>();
        foreach (var damageable in damageables) {
            if (IsValidTarget(damageable)) {
                observedDamageables.Add(damageable);
                damageable.DamageTaken += DamageableOnDamageTaken;
            }
        }
        
        yield return null;
    }

    private void DamageableOnDamageTaken() {
        var damageablesToRemove = new List<Damageable>();
        foreach (var damageable in observedDamageables) {
            if (damageable.CurrentHealth <= 0) {
                damageable.DamageTaken -= DamageableOnDamageTaken;
                damageablesToRemove.Add(damageable);
            }
        }

        foreach (var damageable in damageablesToRemove) {
            observedDamageables.Remove(damageable);
        }

        if (observedDamageables.Count == 0) {
            HandleCompletion(true);
        }
    }

    private bool IsValidTarget(Damageable damageable) {
        var validTag = observedTags.Contains(damageable.gameObject.tag);
        var isAlive = damageable.CurrentHealth > 0;
        return validTag && isAlive;
    }
}
