using UnityEngine;

namespace HomeTest.CharacterPage
{

    [CreateAssetMenu(fileName = "Character", menuName = "Character")]
    public class Character : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _modelPrefab;

        public string Name => _name;
        public GameObject ModelPrefab => _modelPrefab;
    }
}
