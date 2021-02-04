using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Animator animController { get { return GetComponent<Animator>(); } }
    private GameObject kitchen;
    static Material[] kitchenMaterials;
    public Material selectedMaterial;
    public int id;
    void Start()
    {
        kitchen = GameObject.Find("Kitchen");
        kitchenMaterials = kitchen.GetComponent<MeshRenderer>().sharedMaterials;

    }

    // Update is called once per frame
    public void SetMaterial()
    {
        animController.SetTrigger("click");
        kitchenMaterials[id] = selectedMaterial;

        kitchen.GetComponent<MeshRenderer>().sharedMaterials = kitchenMaterials;


    }
}
