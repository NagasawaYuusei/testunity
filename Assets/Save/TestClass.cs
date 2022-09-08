using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TestSaveData
{
    public int num;
    public string str;
    public Vector3 vec;
    string notSave = "�Z�[�u����Ȃ�";
}


public class TestClass : MonoBehaviour
{
    public int num;
    public string str;
    public Vector3 vec;

    public void SetValue(TestSaveData saveData)
    {
        //�lTestSaveData����Z�b�g
        num = saveData.num;
        str = saveData.str;
        vec = saveData.vec;
    }

    public static TestClass I { get; private set; }
    private void Awake()
    {
        I = this;
    }
}

