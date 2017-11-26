using UnityEngine;
using DG.Tweening;

public class CoinSpinScript : MonoBehaviour {

    public float TimeToSpin = 5f;
    public float TurnsPerSecond = 10;

    Transform rotateX;
    Transform coin;

    private void Start()
    {
        rotateX = transform.GetChild(0);
        coin = rotateX.GetChild(0);

        transform.DORotate(new Vector3(0, TimeToSpin * TurnsPerSecond * 360, 0), TimeToSpin, RotateMode.WorldAxisAdd).SetEase(Ease.Linear);
        transform.DOLocalMoveY(.2f, TimeToSpin).SetEase(Ease.InSine);
        rotateX.DOLocalRotate(new Vector3(90, 0, 0), TimeToSpin, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);
        coin.DOLocalRotate(new Vector3(0, 0, TimeToSpin * TurnsPerSecond * 380), TimeToSpin, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);
    }
}
