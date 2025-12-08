using UnityEngine;

public class SplitBall : PowerUpParent
{
    protected override void ApplyEffect()
    {
        EventService.InvokeBallSplit();
    }
}
