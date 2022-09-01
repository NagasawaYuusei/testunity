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
        Debug.Log($"{_name}が通知の受け取りを完了しました");
    }

    public void OnError(Exception error)
    {
        Debug.Log($"{_name}が次のエラーを受信しました:{error.Message}");
    }

    public void OnNext(int value)
    {
        Debug.Log($"{_name}が{value}を受け取りました");
    }
}

public class Observable : IObservable<int>
{
    //購読されたIObserver<int>のリスト
    List<IObserver<int>> _observers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
        //購読解除用のクラスをIDisposableとして返す
        return new Unsubscriber(_observers, observer);
    }

    public void SendNotice()
    {
        //すべての発行先に対して1,2,3を発行する
        foreach (var observer in _observers)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
        }
    }

    //購読解除用内部クラス
    private class Unsubscriber : IDisposable
    {
        //発行先リスト
        List<IObserver<int>> _observers;
        //DisposeされたときにRemoveするIObserver<int>
        IObserver<int> _observer;

        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            //Disposeされたら発行先リストから対象の発行先を削除する
            _observers.Remove(_observer);
        }
    }
}
