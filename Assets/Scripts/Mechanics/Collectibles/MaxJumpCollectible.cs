using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics {
    public abstract class MaxJumpCollectible : PlayerModifierCollectible {
        [SerializeField]
        private float _maxJumpTakeOffSpeed;

        protected override IEnumerator PlayerModifier(PlayerController player, float lifetime) {
            float initialSpeed = player.initialJumpTakeOffSpeed;
            player.jumpTakeOffSpeed = _maxJumpTakeOffSpeed;
            yield return new WaitForSeconds(lifetime);
            player.jumpTakeOffSpeed = initialSpeed;
        }
    }
}
