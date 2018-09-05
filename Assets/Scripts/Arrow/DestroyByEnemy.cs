using UnityEngine;

namespace Assets.Scripts.Arrow
{
    public class DestroyByEnemy : MonoBehaviour {

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Enemy")) {
                gameObject.SetActive(false);
            }
        }
    }
}
