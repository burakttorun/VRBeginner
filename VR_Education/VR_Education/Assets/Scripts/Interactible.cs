using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    Camera cam;
    public Material highlightedMaterial;
    Material defaultMaterial;
    bool selectedOnce;
    Quaternion defRotation;
    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = GetComponent<Renderer>().material;
        cam = Camera.main;
    }


    internal void Select()
    {

        GetComponent<Renderer>().material = highlightedMaterial;
        if (!selectedOnce)
        {
            defRotation = transform.rotation;
        }
        selectedOnce = true;
    }
    internal void DeSelect()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }
    float zCoor;
    Vector3 offset;
    internal void ComputeInitialOffset()
    {
        
        zCoor = cam.WorldToScreenPoint(transform.position).z; // ekran iki boyutlu olduğu için z ekseni yoktur, erişmek için kullanılan kısım.
        offset = transform.position - GetMousePositionIn3D();
    }

    private Vector3 GetMousePositionIn3D()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = zCoor;

        return cam.ScreenToWorldPoint(mousePos);
    }

    public void Translate()
    {
        transform.position = offset + GetMousePositionIn3D();
    }

    public void ResetRotation()
    {
        transform.rotation = defRotation;
    }

    public void RotateInZ()
    {
        transform.Rotate(Vector3.forward * angle * Time.deltaTime, Space.World);
    }

    public void RotateInY()
    {
        transform.Rotate(Vector3.up * angle * Time.deltaTime, Space.World);
    }
    float angle = 120;
    public void RotateInX()
    {
        transform.Rotate(Vector3.right * angle * Time.deltaTime, Space.World);
    }

    public void ScaleUp()
    {
        transform.localScale += new Vector3(1,1,1)*0.2f;
        var clampX = Mathf.Clamp(transform.localScale.x, 0.1f, 1.8f);//clamp verilen değeri verilen (min max) rakamlar arasında tutmak için kullanılır.
        var clampY = Mathf.Clamp(transform.localScale.y, 0.1f, 1.8f);
        var clampZ = Mathf.Clamp(transform.localScale.z, 0.1f, 1.8f);
        transform.localScale = new Vector3(clampX, clampY, clampZ);
    }

    public void ScaleDown()
    {
        transform.localScale -= new Vector3(1, 1, 1) * 0.2f;
        var clampX = Mathf.Clamp(transform.localScale.x, 0.1f, 1.8f);//clamp verilen değeri verilen (min max) rakamlar arasında tutmak için kullanılır.
        var clampY = Mathf.Clamp(transform.localScale.y, 0.1f, 1.8f);
        var clampZ = Mathf.Clamp(transform.localScale.z, 0.1f, 1.8f);
        transform.localScale = new Vector3(clampX, clampY, clampZ);
    }
}
