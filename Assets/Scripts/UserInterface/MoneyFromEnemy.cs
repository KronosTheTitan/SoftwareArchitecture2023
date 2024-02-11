using TMPro;
using UnityEngine;

namespace UserInterface
{
    /// <summary>
    /// used for the visual effect when receiving money, is removed after a pre determined amount of seconds
    /// </summary>
    public class MoneyFromEnemy : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private float duration = 2f;
        public void Setup(int amount)
        {
            text.text = "+" + amount.ToString();
        }

        private void Update()
        {
            transform.position += Vector3.up * Time.deltaTime;
        }

        private void Start()
        {
            Destroy(gameObject, duration);
        }
    }
}
