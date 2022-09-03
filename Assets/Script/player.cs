using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] private InputController InputController;
    [SerializeField] private GameObject textPanel;
    [SerializeField] private Image image;
    [SerializeField] private GameObject food;

    Animator animator;
    Vector3 movement;
    Rigidbody rigidbody;
    Camera cam;

    public float speed = 5.0f;

    public static bool isKey = false;
    public static List<GameObject> objList;
    void Start()
    {
        objList = new List<GameObject>();
        cam = GetComponentInChildren<Camera>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        LookMouseCursor();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRun", true);
        }
        else
            animator.SetBool("isRun", false);

        if (objList.Count >= 2)
            food.SetActive(true);
    }

    private void FixedUpdate()
    {
        movement.x = InputController.returnHorizontal();
        movement.z = InputController.returnVertical();

        Vector3 _moveHorizontal = transform.right * movement.x;
        Vector3 _moveVertical = transform.forward * movement.z;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        movement.Normalize();

        rigidbody.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    public void LookMouseCursor()
    {
        int layerMask = 1 << LayerMask.NameToLayer("ground");

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,Mathf.Infinity,layerMask))
        {
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            animator.transform.forward = mouseDir;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "npc")
        {
            image.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                textPanel.SetActive(true);
                isKey = true;
            }
        }

        if(other.tag == "object")
        {
            image.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "npc")
        {
            image.gameObject.SetActive(false);
            textPanel.SetActive(false);
        }

        if(other.gameObject.tag == "object")
            image.gameObject.SetActive(false);
    }
}
