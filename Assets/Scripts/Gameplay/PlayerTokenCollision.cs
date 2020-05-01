using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay {
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision> {
        public PlayerController player;
        public TokenInstance token;
        private PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute() {
            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
        }
    }

    public class PlayerCollectibleCollision : Simulation.Event<PlayerCollectibleCollision> {
        public PlayerController Player { get; set; }
        public Collectible Collectible { get; set; }

        public override void Execute() {
            Collectible.PlayCollectedSound();
            Collectible.ApplyPlayerEffect(Player);
        }
    }
}