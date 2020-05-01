using System;
using UnityEngine;

namespace Platformer.Mechanics {
    public class HealthyPointsCollectible : Collectible {
        [SerializeField]
        [Range(-300, 300)]
        [Tooltip("Points change by collecting")]
        private int _points = 100;

        public override void ApplyPlayerEffect(PlayerController player) {
            player.ChangeScore(_points);
        }
    }
}
