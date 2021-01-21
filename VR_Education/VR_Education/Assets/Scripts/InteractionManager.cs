using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    Camera cam;
    public Transform cursor;
    public Text textinfo;
    Interactible current;
    List<Interactible> Interactibles;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Interactibles = new List<Interactible>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var i in Interactibles)
        {
            i.DeSelect();
        }
        Interactibles.Clear();

        Ray ray = cam.ScreenPointToRay(cursor.position);
        if (Physics.Raycast(ray, out RaycastHit info))
        {
            Interactible interactible = info.transform.GetComponent<Interactible>();
            if (interactible!=null)
            {
                interactible.Select();
                current = interactible;
                textinfo.text = interactible.name;
                var offset = Vector3.up * 30;
                textinfo.transform.position = cursor.position-offset;
                

                Interactibles.Add(interactible);

                if (Input.GetKeyDown(KeyCode.Mouse0)) interactible.ComputeInitialOffset();
                if (Input.GetKey(KeyCode.Mouse0)) interactible.Translate();
                if (Input.GetAxis("Mouse ScrollWheel") > 0) interactible.ScaleUp();
                if (Input.GetAxis("Mouse ScrollWheel") < 0) interactible.ScaleDown();
                if (Input.GetKey(KeyCode.X)) interactible.RotateInX();
                if (Input.GetKey(KeyCode.Y)) interactible.RotateInY();
                if (Input.GetKey(KeyCode.Z)) interactible.RotateInZ();
                if (Input.GetKey(KeyCode.R)) interactible.ResetRotation();






            }
        }
        else
        {
            foreach (var interactible in Interactibles)
            {
                textinfo.text = "";
                interactible.DeSelect();
            }
            Interactibles.Clear();
        }


    }
}
