using UnityEngine;

namespace MySampleEx
{
    /// <summary>
    /// Data �⺻ Ŭ����
    /// �������� ������ : �̸� ���
    /// �������� ��� : �������� ���� ��������, �̸� ��� ����Ʈ ������, ������ �߰�, ����, ����
    /// </summary>
    public class BaseData : ScriptableObject
    {
        #region Variables
        public string[] names;
        public const string DataDirectory = "/ResourcesData/Resources/Data/";
        #endregion

        // ������
        public BaseData() { }

        // �������� ���� ��������
        public int GetDataCount()
        {
            if(names == null)
            {
                return 0;
            }
            return names.Length;
        }

        // ���� ����ϱ� ���� �̸� ��� ����Ʈ ������
        public string[] GetNameList(bool showID, string filterWord = "")
        {
            int length = GetDataCount();
            string[] retList = new string[length];

            for(int i = 0; i < length; i++)
            {
                if(filterWord != "")
                {
                    if (names[i].ToLower().Contains(filterWord.ToLower()))
                    {
                        continue;
                    }
                }

                if (showID)
                {
                    retList[i] = i.ToString() + " : " + names[i];
                }
                else
                {
                    retList[i] = names[i];
                }
            }

            return retList;
        }

        // ������ �߰��ϰ� ���� ���� ����
        public virtual int AddData(string newName)
        {
            return GetDataCount();
        }

        // ������ ����
        public virtual void Copy(int index)
        {

        }

        // ������ ����
        public virtual void RemoveData(int index)
        {

        }
    }
}
