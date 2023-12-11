using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomController : MonoBehaviour
{
    [SerializeField]
    GameObject[] targets;

    CinemachineTargetGroup _targetGroup;

    CinemachineVirtualCamera _virtualCamera;

    Collider2D _collider;


    private void Start()
    {
        _targetGroup = GetComponent<CinemachineTargetGroup>();
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _collider = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _virtualCamera.Follow = _targetGroup.transform;

            foreach (var target in targets)
            {
                _targetGroup.AddMember(target.transform, 1, 1);
            }

            _collider.enabled = false;
        }
        
    }
}
