using Platformer.Core;
using Platformer.Model;

namespace Platformer.Gameplay {
    public class PlayerHurt : Simulation.Event<PlayerHurt> {
        private PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute() {
            var player = model.player;
            if (player.health.IsAlive) {
                player.health.Damage();
                if (!player.health.IsAlive) { return; }
                if (player.audioSource && player.ouchAudio) {
                    player.audioSource.PlayOneShot(player.ouchAudio);
                }

                player.animator.SetTrigger("hurt");
            }
        }
    }
}