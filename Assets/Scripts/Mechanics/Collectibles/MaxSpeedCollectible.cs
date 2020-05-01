using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics {
    public abstract class MaxSpeedCollectible : PlayerModifierCollectible {
        [SerializeField]
        private float _maxSpeed;

        protected override IEnumerator PlayerModifier(PlayerController player, float lifetime) {
            float initialSpeed = player.maxSpeed;
            player.maxSpeed = _maxSpeed;
            yield return new WaitForSeconds(lifetime);
            player.maxSpeed = initialSpeed;
        }
    }
}
