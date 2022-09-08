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
//        //セーブデータの読み込み
//        T saveData = JsonSaveManager<T>.Load(saveDataPath);

//        if (saveData == null)
//        {
//            //セーブデータが存在しない場合の処理
//        }
//        else
//        {
//            //セーブデータが存在する場合の処理
//        }
//    }

//    private void OnApplicationPause(bool isPaused)//アンドロイドスマホではこっちが必要だった
//    {
//        if (isPaused)
//        {
//            OverWriteSaveData();
//        }
//    }

//    private void OnApplicationQuit()//エディタ上で確認するときはこっちが必要だった
//    {
//        OverWriteSaveData();
//    }

//    //セーブデータの上書き
//    void OverWriteSaveData()
//    {
//        //新たなセーブデータを作成処理
//        T saveData = new T();

//        //既存のセーブデータを上書き
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

        if (saveData == null)//セーブデータが存在しない場合は任意の値で初期化
        {
            //新たなセーブデータを作成
            saveData = new TestSaveData()
            {
                num = 3,
                str = "テスト",
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

    private void OnApplicationQuit()//アプリケーション終了時に呼び出す
    {
        OverWriteSaveData();
    }

    //セーブデータの上書き
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