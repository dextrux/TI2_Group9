using UnityEngine;

namespace Scenario
{
    public class TileControl : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private TileManager _tileManager;
        [SerializeField] private float _distanceToDisable;
        [SerializeField] private sbyte _area;
        public bool Active;
        private void OnEnable()
        {
            Active = true;
            Transform[] _childrens = GetComponentsInChildren<Transform>();
            foreach (Transform t in _childrens)
            {
                t.gameObject.SetActive(true);
            }
        }
        private void Update()
        {
            if (_player.position.z - transform.position.z>= _distanceToDisable)
            {
                gameObject.SetActive(false);
            }
        }
        private void OnDisable()
        {
            _tileManager.TileCount--;
            Active = false;
        }
    }
}
