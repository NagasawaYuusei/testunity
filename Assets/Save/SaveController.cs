//using UnityEngine;

//public class SaveControllerTemplate : MonoBehaviour
//{
//    public static SaveControllerTemplate I { get; private set; }

//    string saveDataPath = "save-data";

//    private void Awake()
//    {
//        I = this;
//    }

//    private void Start()
//    {
//        //�Z�[�u�f�[�^�̓ǂݍ���
//        T saveData = JsonSaveManager<T>.Load(saveDataPath);

//        if (saveData == null)
//        {
//            //�Z�[�u�f�[�^�����݂��Ȃ��ꍇ�̏���
//        }
//        else
//        {
//            //�Z�[�u�f�[�^�����݂���ꍇ�̏���
//        }
//    }

//    private void OnApplicationPause(bool isPaused)//�A���h���C�h�X�}�z�ł͂��������K�v������
//    {
//        if (isPaused)
//        {
//            OverWriteSaveData();
//        }
//    }

//    private void OnApplicationQuit()//�G�f�B�^��Ŋm�F����Ƃ��͂��������K�v������
//    {
//        OverWriteSaveData();
//    }

//    //�Z�[�u�f�[�^�̏㏑��
//    void OverWriteSaveData()
//    {
//        //�V���ȃZ�[�u�f�[�^���쐬����
//        T saveData = new T();

//        //�����̃Z�[�u�f�[�^���㏑��
//        JsonSaveManager<TestSaveData>.Save(T, saveDataPath);
//    }
//}

using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController I { get; private set; }

    string testSaveDataPath = "test-save-data";

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        TestSaveData saveData = JsonSaveManager<TestSaveData>.Load(testSaveDataPath);

        if (saveData == null)//�Z�[�u�f�[�^�����݂��Ȃ��ꍇ�͔C�ӂ̒l�ŏ�����
        {
            //�V���ȃZ�[�u�f�[�^���쐬
            saveData = new TestSaveData()
            {
                num = 3,
                str = "�e�X�g",
                vec = Vector3.one
            };
        }

        TestClass.I.SetValue(saveData);
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            OverWriteSaveData();
        }
    }

    private void OnApplicationQuit()//�A�v���P�[�V�����I�����ɌĂяo��
    {
        OverWriteSaveData();
    }

    //�Z�[�u�f�[�^�̏㏑��
    void OverWriteSaveData()
    {
        TestSaveData testSaveData = new TestSaveData()
        {
            num = TestClass.I.num,
            str = TestClass.I.str,
            vec = TestClass.I.vec,
        };
        JsonSaveManager<TestSaveData>.Save(testSaveData, testSaveDataPath);
    }
}