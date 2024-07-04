using UnityEngine;

namespace Scenario
{
    public class TileControl : MonoBehaviour
    {
        private Transform _player;
        [SerializeField] private TileManager _tileManager;
        [SerializeField] private float _distanceToDisable;
        [SerializeField] private sbyte _area;
        [SerializeField] private ExpGroup[] _expGroup;
        public bool Active;
        private void OnEnable()
        {
            _player = PlayerCharacter.Instance.GetComponent<Transform>();
            Active = true;
            Transform[] _childrens = GetComponentsInChildren<Transform>();
            _expGroup = GetComponentsInChildren<ExpGroup>();
            foreach (Transform t in _childrens)
            {
                t.gameObject.SetActive(true);
                if (t.TryGetComponent(out ExpGroup group))
                {
                    group.SetActiveXp();
                }
            }
        }
        private void Update()
        {
            if (_player.position.z - transform.position.z >= _distanceToDisable)
            {
                foreach (ExpGroup group in _expGroup)
                {
                    group.SetActiveXp();
                }
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
