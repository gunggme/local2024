using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum BoostType
{
    Normal,
    Boost,
    MegaBoost
}

public class PlayerCar : MonoBehaviour
{
    [SerializeField] Rigidbody carRigid;

    MovementCamera move_Camera;
    LoadItem loadItem;

    [SerializeField] BoostType boostType;

    public Transform CheckForward;

    public GameObject EffectObj;

    public float Horizontal;
    public float Vertical;
    public float MovementSpeed
    {
        get
        {
            switch (boostType)
            {
                case BoostType.Normal:
                    return loadItem.EngineItem.NormalSpeed;
                case BoostType.Boost:
                    return loadItem.EngineItem.BoostSpeed;
                case BoostType.MegaBoost:
                    return loadItem.EngineItem.MegaBoostSpeed;
                default:
                    return loadItem.EngineItem.NormalSpeed;
            }
        }
    }
    public float SteerPower;

    public bool IsMove;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        loadItem = FindObjectOfType<LoadItem>();
        move_Camera = FindObjectOfType<MovementCamera>();
        FindObjectOfType<MovementCamera_Minimap>().Target = transform;
        move_Camera.Target = transform;
    }

    private void Start()
    {
        carRigid.transform.SetParent(null);
    }

    private void Update()
    {
        transform.position = carRigid.transform.position;
        carRigid.transform.rotation = transform.rotation;
        audioSource.pitch = 1 + (carRigid.velocity.magnitude / 100);
        if (IsMove)
        {
            Movement();
        }
    }

    private void FixedUpdate()
    {
        if (IsMove)
        {
            carRigid.AddForce(transform.forward * (Vertical + CheckFloor()), ForceMode.Acceleration);
        }
        move_Camera.SetDisntance(carRigid.velocity.magnitude);
    }

    public void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Vertical *= MovementSpeed;

        transform.Rotate(0, Horizontal * SteerPower * Time.deltaTime, 0, Space.World);
    }

    private readonly WaitForSeconds wait1Sec = new(1);
    public IEnumerator Boost(BoostType type)
    {
        if (boostType != BoostType.Normal) yield break;

        boostType = type;
        Debug.Log("부스트 시작");
        yield return wait1Sec;
        Debug.Log("부스트 끝");
        boostType = BoostType.Normal;
    }

    public float CheckFloor()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5, loadItem.WheelItem.layers))
        {
            if(hit.transform != null)
            {
                Debug.Log($"현재 레이어 {hit.transform.gameObject.name}");
                return 0;
            }
        }

        return -loadItem.WheelItem.Deaccelation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.7f);
       // Gizmos.DrawLine(CheckForward.position, CheckForward.position + CheckForward.forward * 0.1f);
    }
}
