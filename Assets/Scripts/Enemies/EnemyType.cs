using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// A type of enemy for usage with the wave and Enemy classes.
    /// </summary>
    [CreateAssetMenu(fileName = "New EnemyType", menuName = "SoftwareArchitecture/EnemyType")]
    public class EnemyType : ScriptableObject
    {
        [SerializeField] private int health;
        [SerializeField] private int carriedMoney;
        [SerializeField] private float speed;
        [SerializeField] private GameObject gfx;

        public int Health => health;
        public int CarriedMoney => carriedMoney;
        public float Speed => speed;
        public GameObject GFX => gfx;
    }
}
