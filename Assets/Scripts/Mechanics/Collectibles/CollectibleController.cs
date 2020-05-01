using UnityEngine;

namespace Platformer.Mechanics {
    public class CollectibleController : MonoBehaviour {
        [SerializeField]
        private Collectible[] _collectibles;
        [Tooltip("Frames per second at which tokens are animated.")]
        private float _frameRate = 12;
        private float _nextFrameTime = 0;

        [SerializeField]
        private Sprite _noSprite;

        [Header("Healthy Collectibles")]
        [SerializeField]
        private Sprite[] _healtyCollect;
        [SerializeField]
        private Sprite[] _healtyFast;
        [SerializeField]
        private Sprite[] _healtyLight;
        [SerializeField]
        private Sprite[] _healtyRestore;

        [Header("Bad Collectibles")]
        [SerializeField]
        private Sprite[] _badHeavy;
        [SerializeField]
        private Sprite[] _badMinusHealth;

        [ContextMenu("Find All Collectibles")]
        private void FindAllCollectiblesInScene() {
            _collectibles = FindObjectsOfType<Collectible>();
        }

        private void Awake() {
            if (_collectibles.Length == 0) {
                FindAllCollectiblesInScene();
            }
        }

        private void Start() {
            for (int i = 0; i < _collectibles.Length; i++) {
                _collectibles[i].SetController(this);
                var sprite = GetRandomCollectibleSprite(_collectibles[i]);
                _collectibles[i].SetCollectibleSprite(sprite);
            }
        }

        private Sprite GetRandomCollectibleSprite(Collectible collectible) {
            switch (collectible) {
                case HealthyPointsCollectible _: {
                        return GetRandomOrDefault(_healtyCollect, _noSprite);
                    }
                case HealthyRestoreHelthCollectible _: {
                        return GetRandomOrDefault(_healtyRestore, _noSprite);
                    }
                case HealtyMaxSpeedCollectible _: {
                        return GetRandomOrDefault(_healtyFast, _noSprite);
                    }
                case HealthyMaxJumpCollectible _: {
                        return GetRandomOrDefault(_healtyLight, _noSprite);
                    }
                case BadDamageHelthCollectible _: {
                        return GetRandomOrDefault(_badMinusHealth, _noSprite);
                    }
                case BadMaxJumpCollectible _: {
                        return GetRandomOrDefault(_badHeavy, _noSprite);
                    }
                default: return _noSprite;
            }
        }

        private T GetRandomOrDefault<T>(T[] array, T @default) {
            if (array == null || array.Length == 0) { return @default; }
            int index = Random.Range(0, array.Length);
            return array[index];
        }

        private void Update() {
            //if it's time for the next frame...
            if (Time.time - _nextFrameTime > (1f / _frameRate)) {
                //update all tokens with the next animation frame.
                for (int i = 0; i < _collectibles.Length; i++) {
                    var collectible = _collectibles[i];
                    //if token is null, it has been disabled and is no longer animated.
                    if (collectible != null) {
                        if (collectible.Collected) {
                            collectible.gameObject.SetActive(false);
                            _collectibles[i] = null;
                        }
                    }
                }
                //calculate the time of the next frame.
                _nextFrameTime += 1f / _frameRate;
            }
        }
    }
}
