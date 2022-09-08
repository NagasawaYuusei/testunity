using System;
using UnityEngine;

public class ObserverTest : MonoBehaviour
{
    void Start()
    {
        //�l���󂯎��N���X���R�쐬
        Observer observerA = new Observer("A����");
        Observer observerB = new Observer("B����");
        Observer observerC = new Observer("C����");

        //�l�𔭍s����N���X���쐬
        Observable observable = new Observable();

        //�R��Observer���A�������g�𔭍s��Ƃ��ēo�^����i=�w�ǁj
        IDisposable disposableA = observable.Subscribe(observerA);
        IDisposable disposableB = observable.Subscribe(observerB);
        IDisposable disposableC = observable.Subscribe(observerC);
        Debug.Log("A����B����C���񂪒l���w�ǂ��܂���");

        Debug.Log("�l�𔭍s�����܂�");
        //Observable�ɒl�𔭍s������
        observable.SendNotice();

        Debug.Log("A���񂪍w�ǉ������܂�");
        //A���񂪍w�ǉ�������
        disposableA.Dispose();

        Debug.Log("�l�𔭍s�����܂�");
        //�Ăђl�𔭍s������
        observable.SendNotice();

        Debug.Log("B���񂪍w�ǉ������܂�");
        //B���񂪍w�ǉ�������
        disposableB.Dispose();

        Debug.Log("�l�𔭍s�����܂�");
        //�Ăђl�𔭍s������
        observable.SendNotice();
    }
}
