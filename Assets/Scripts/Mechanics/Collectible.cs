using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics {
    public abstract class Collectible : MonoBehaviour {
        private SpriteRenderer _renderer;
        private CollectibleController _controller;

        [SerializeField]
        private AudioClip collectibleCollectAudio;
        
        public bool Collected { get; private set; }

        public void SetCollectibleSprite(Sprite sprite) {
            _renderer.sprite = sprite;
        }

        public void SetController(CollectibleController controller) {
            _controller = controller;
        }

        public void PlayCollectedSound() {
            AudioSource.PlayClipAtPoint(collectibleCollectAudio, transform.position);
        }

        private void Awake() {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) {
                OnPlayerEnter(player);
            }
        }

        private void OnPlayerEnter(PlayerController player) {
            if (Collected) {
                return;
            }
            if (_controller != null) {
                Collected = true;
            }
            //send an event into the gameplay system to perform some behaviour.
            var ev = Schedule<PlayerCollectibleCollision>();
            ev.Collectible = this;
        }
    }
}
