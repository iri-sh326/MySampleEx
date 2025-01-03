using MySampleEx;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace mySampleEx
{
    /// <summary>
    /// Card �����͸� ������Ʈ�� ����
    /// </summary>
    public class DrawCard : MonoBehaviour
    {
        public Card card;

        public TextMeshProUGUI[] text;

        public Image artImage;

        private void Start()
        {
            // Card �����͸� ������Ʈ�� ����
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
