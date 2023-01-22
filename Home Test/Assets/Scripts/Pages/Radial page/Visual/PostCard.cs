using UnityEngine;
using TMPro;

namespace HomeTest.RadialPage
{
    public class PostCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text) => _text.text = text;
    }
}
