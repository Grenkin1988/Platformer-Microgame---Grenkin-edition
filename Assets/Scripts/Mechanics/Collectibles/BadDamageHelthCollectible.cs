using Platformer.Core;
using Platformer.Gameplay;

namespace Platformer.Mechanics {
    public class BadDamageHelthCollectible : PointsCollectible {
        public override void ApplyPlayerEffect(PlayerController player) {
            base.ApplyPlayerEffect(player);
            Simulation.Schedule<PlayerHurt>();
        }
    }
}
