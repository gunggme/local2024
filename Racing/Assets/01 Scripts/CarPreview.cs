using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPreview : MonoBehaviour
{
    public float RotateSpeed;

    private void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0, Space.World);
    }

    public void ChangePreviewItem(GameObject prefab)
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        GameObject obj =Instantiate(prefab, transform.position + new Vector3(0, 1, 0), transform.rotation);
        obj.transform.SetParent(transform);
    }
}
