using UnityEngine;

public class SizeUp : PowerUpParent
{
    protected override void ApplyEffect()
    {
        _paddle.GetChild(0).transform.localScale += Vector3.right * 0.8f;
        Invoke("DelEffect", 10f);
    }

    protected void DelEffect()
    {
        _paddle.GetChild(0).transform.localScale -= Vector3.right * 0.8f;
        Destroy(gameObject);
    }

   
}
