using UnityEngine;

namespace Platformer.UI {
    /// <summary>
    /// A simple controller for switching between UI panels.
    /// </summary>
    public class MainUIController : MonoBehaviour {
        public GameObject menu;
        public GameObject[] panels;

        public void SetMenuActive(bool active) {
            menu.gameObject.SetActive(active);
        }

        public void SetActivePanel(int index) {
            for (int i = 0; i < panels.Length; i++) {
                bool active = i == index;
                var g = panels[i];
                if (g.activeSelf != active) {
                    g.SetActive(active);
                }
            }
        }

        private void OnEnable() {
            SetActivePanel(0);
        }
    }
}