using System;
using UnityEngine;

public class EventService : MonoBehaviour
{
    public void Awake()
    {
        GameServicesLocator.Register(this);
    }

    public static event Action OnBallSplit;
    public static void InvokeBallSplit() { OnBallSplit?.Invoke(); }

    public static event Action OnBrickGenerate;
    public static void InvokeBrickGenerate() { OnBrickGenerate?.Invoke(); }

    public static event Action OnBrickDestroy;
    public static void InvokeBrickDestroy() { OnBrickDestroy?.Invoke(); }
}
