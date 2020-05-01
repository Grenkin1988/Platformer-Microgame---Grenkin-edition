using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay {
    public class PlayerCollectibleCollision : Simulation.Event<PlayerCollectibleCollision> {
        public PlayerController Player { get; set; }
        public Collectible Collectible { get; set; }

        public override void Execute() {
            Collectible.PlayCollectedSound();
            Collectible.ApplyPlayerEffect(Player);
        }
    }
}