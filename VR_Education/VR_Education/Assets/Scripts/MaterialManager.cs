using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    private GameObject room;
    Material[] materials;
    public Material material;
    void Start()
    {
        room = GameObject.Find("room");
        materials = room.GetComponent<MeshRenderer>().sharedMaterials;

    }

    // Update is called once per frame
    public void SetMaterial()
    {
        materials[0] = material;
        room.GetComponent<MeshRenderer>().sharedMaterials[0] = materials[0];
        room.GetComponent<MeshRenderer>().sharedMaterials = materials;


    }
}
