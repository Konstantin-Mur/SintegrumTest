using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI countBulletCollision;

    private CubeModel _cubeModel;

    private void Awake()
    {
        _cubeModel = FindObjectOfType<CubeModel>();
        countBulletCollision.text = _cubeModel.CountBulletColision.ToString();
    }
   
    private void Update()
    {
        countBulletCollision.text = _cubeModel.CountBulletColision.ToString();
    }
}
