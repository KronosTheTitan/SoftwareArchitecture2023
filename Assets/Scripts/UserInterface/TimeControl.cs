using UnityEngine;

namespace UserInterface
{
    /// <summary>
    /// speeds up the game speed when the keypad plus key is pressed.
    /// </summary>
    public class TimeControl : MonoBehaviour
    {
        private const float DefaultGameSpeed = 1;
        [SerializeField] private float increasedGameSpeed = 2;
        private void Update()
        {
            if (Input.GetKey(KeyCode.KeypadPlus))
            {
                Time.timeScale = increasedGameSpeed;
            }
            else
            {
                Time.timeScale = DefaultGameSpeed;
            }
        }
    }
}
