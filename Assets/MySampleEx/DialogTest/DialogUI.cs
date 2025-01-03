using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MySampleEx
{
    /// <summary>
    /// ��ȭâ ���� Ŭ����
    /// ��ȭ ������ ���� �б�
    /// ��ȭ ������ UI ����
    /// </summary>
    public class DialogUI : MonoBehaviour
    {
        #region Variables
        // XML
        public string xmlFile = "Dialog/Dialog";    // Path
        private XmlNodeList allNodes;

        private Queue<Dialog> dialogs;

        // UI
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI sentenceText;
        public GameObject npcImage;
        public GameObject nextButton;
        #endregion

        private void Start()
        {
            // xml ������ ���� �б�
            LoadDialogXml(xmlFile);

            dialogs = new Queue<Dialog>();
            InitDialog();

            //
            StartDialog(0);
        }

        private void LoadDialogXml(string path)
        {
            TextAsset xmlFile = Resources.Load<TextAsset>(path);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile.text);
            allNodes = xmlDoc.SelectNodes("root/Dialog");
        }

        private void InitDialog()
        {
            dialogs.Clear();

            npcImage.SetActive(false);
            nameText.text = "";
            sentenceText.text = "";
        }

        // ��ȭ �����ϱ�
        public void StartDialog(int dialogIndex)
        {
            // ���� ��ȭ�� ������ ť�� �Է�
            foreach(XmlNode node in allNodes)
            {
                int num = int.Parse(node["number"].InnerText);
                if(num == dialogIndex)
                {
                    Dialog dialog = new Dialog();
                    dialog.number = num;
                    dialog.character = int.Parse(node["character"].InnerText);
                    dialog.name = node["name"].InnerText;
                    dialog.sentence = node["sentence"].InnerText;

                    dialogs.Enqueue(dialog);
                }
            }

            // ù��° ��ȭ�� �����ش�
            DrawNextDialog();
        }

        // ���� ��ȭ�� �����ش� - (ť)dialogs���� �ϳ� ������ �����ش�
        public void DrawNextDialog()
        {
            // dialog Check


            // dialogs���� �ϳ� �����´�
            Dialog dialog = dialogs.Dequeue();

            if(dialog.character > 0)
            {
                npcImage.SetActive(true);
                npcImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(
                    "Dialog/Npc/npc0" + dialog.character.ToString());
            }
            else
            {
                npcImage.SetActive(false);
            }
            nextButton.SetActive(false);

            nameText.text = dialog.name;
            StartCoroutine(typingSentence(dialog.sentence));
        }

        // Ÿ���� ȿ��
        IEnumerator typingSentence(string typingText)
        {
            sentenceText.text = "";

            foreach(char latter in typingText)
            {
                sentenceText.text += latter;
                yield return new WaitForSeconds(0.03f);
            }

            nextButton.SetActive(true);
        }

        // ��ȭ ����
        private void EndDialog()
        {
            InitDialog();

            // ��ȭ ����� �̺�Ʈ ó��
        }
    
    }


}
