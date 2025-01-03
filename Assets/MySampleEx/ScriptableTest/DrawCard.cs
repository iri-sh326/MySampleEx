using MySampleEx;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace mySampleEx
{
    /// <summary>
    /// Card 데이터를 오브젝트에 적용
    /// </summary>
    public class DrawCard : MonoBehaviour
    {
        public Card card;

        public TextMeshProUGUI[] text;

        public Image artImage;

        private void Start()
        {
            // Card 데이터를 오브젝트에 적용
            UpdateCard();
        }

        private void UpdateCard()
        {
            text[0].text = card.name;
            text[1].text = card.description;
            text[2].text = card.mana.ToString();
            text[3].text = card.attack.ToString();
            text[4].text = card.health.ToString();

            artImage.sprite = card.artImage;
        }
    }
}
