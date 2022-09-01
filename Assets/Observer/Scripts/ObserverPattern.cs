using System;
using System.Collections.Generic;
using UnityEngine;

public class Observer : IObserver<int>
{
    string _name;
    public Observer(string name)
    {
        _name = name;
    }

    public void OnCompleted()
    {
        Debug.Log($"{_name}���ʒm�̎󂯎����������܂���");
    }

    public void OnError(Exception error)
    {
        Debug.Log($"{_name}�����̃G���[����M���܂���:{error.Message}");
    }

    public void OnNext(int value)
    {
        Debug.Log($"{_name}��{value}���󂯎��܂���");
    }
}

public class Observable : IObservable<int>
{
    //�w�ǂ��ꂽIObserver<int>�̃��X�g
    List<IObserver<int>> _observers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
        //�w�ǉ����p�̃N���X��IDisposable�Ƃ��ĕԂ�
        return new Unsubscriber(_observers, observer);
    }

    public void SendNotice()
    {
        //���ׂĂ̔��s��ɑ΂���1,2,3�𔭍s����
        foreach (var observer in _observers)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
        }
    }

    //�w�ǉ����p�����N���X
    private class Unsubscriber : IDisposable
    {
        //���s�惊�X�g
        List<IObserver<int>> _observers;
        //Dispose���ꂽ�Ƃ���Remove����IObserver<int>
        IObserver<int> _observer;

        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            //Dispose���ꂽ�甭�s�惊�X�g����Ώۂ̔��s����폜����
            _observers.Remove(_observer);
        }
    }
}
