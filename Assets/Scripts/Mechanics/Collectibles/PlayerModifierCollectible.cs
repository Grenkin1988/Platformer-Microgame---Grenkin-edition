using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics {
    public abstract class PlayerModifierCollectible : PointsCollectible {
        [Range(0, 5)]
        [SerializeField]
        private float _duration = 1f;

        public override void ApplyPlayerEffect(PlayerController player) {
            base.ApplyPlayerEffect(player);
            player.StartCoroutine(PlayerModifier(player, _duration));
        }

        protected abstract IEnumerator PlayerModifier(PlayerController player, float lifetime);
    }
}
