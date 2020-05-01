using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics {
    public class EnemyController : KinematicObject {
        public PatrolPath path;
        [SerializeField]
        private AudioClip _ouchClip;

        [SerializeField]
        private Sprite[] _enemySprites;

        private PatrolPath.Mover _mover;
        private Collider2D _collider;
        private AudioSource _audio;
        private SpriteRenderer _spriteRenderer;

        public float maxSpeed = 7;

        public Vector2 move;

        public Bounds Bounds => _collider.bounds;

        private void Awake() {
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            int index = Random.Range(0, _enemySprites.Length);
            _spriteRenderer.sprite = _enemySprites[index];
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null) {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        protected override void Update() {
            if (path != null) {
                if (_mover == null) {
                    _mover = path.CreateMover(maxSpeed * 0.5f);
                }
                move.x = Mathf.Clamp(_mover.Position.x - transform.position.x, -1, 1);
            }
            base.Update();
        }

        protected override void ComputeVelocity() {
            if (move.x > 0.01f) {
                _spriteRenderer.flipX = false;
            } else if (move.x < -0.01f) {
                _spriteRenderer.flipX = true;
            }

            targetVelocity = move * maxSpeed;
        }

        public void Die() {
            _collider.enabled = false;
            if (_audio && _ouchClip) {
                _audio.PlayOneShot(_ouchClip);
            }
        }
    }
}