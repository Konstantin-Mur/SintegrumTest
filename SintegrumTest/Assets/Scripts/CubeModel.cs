using UnityEngine;

public class CubeModel : MonoBehaviour
{
    private int _countBulletColision = 0;

    public int CountBulletColision => _countBulletColision;

    public void UpdateCount()
    {
        _countBulletColision += 1;
    }

    private void Awake()
    {
        EventAgregator.updateUI.AddListener(UpdateCount);
    }
}
