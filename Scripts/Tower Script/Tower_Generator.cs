using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Generator : MonoBehaviour
{
    [SerializeField] private int _platformCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _cylinder;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private NextLevel _nextLevel;
    [SerializeField] private Platform[] _platforms;

    public float CylinderScaleY => _platformCount / 2 + _startAndFinishAditionalScale + _additionalScale/2f;
    private float _startAndFinishAditionalScale = 1f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject cylinder = Instantiate(_cylinder, transform);
        cylinder.transform.localScale = new Vector3(1, CylinderScaleY, 1);
        Vector3 spawnPos = cylinder.transform.position;
        spawnPos.y += cylinder.transform.localScale.y - _additionalScale;
        SpawnPlatform(_startPlatform, ref spawnPos, cylinder.transform);

        for (int i = 0; i < _platformCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)],ref spawnPos, cylinder.transform);
        }
        SpawnPlatform(_finishPlatform, ref spawnPos, cylinder.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPos, Transform parent)
    {
        Instantiate(platform, spawnPos, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPos.y -= 1;
    }
}

