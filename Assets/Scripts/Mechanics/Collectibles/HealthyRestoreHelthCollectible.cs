using System;
using UnityEngine;

namespace Platformer.Mechanics {
    public class HealthyRestoreHelthCollectible : PointsCollectible {
        public override void ApplyPlayerEffect(PlayerController player) {
            base.ApplyPlayerEffect(player);
            player.health.Increment();
        }
    }
}
