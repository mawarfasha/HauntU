using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    //EDLEENA

    [SerializeField] protected CinemachineStateDrivenCamera _camera;
    [SerializeField] protected Transform player;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera.Follow = player.transform;
    }
}
