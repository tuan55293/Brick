using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fireRate;
    float _fireRate;
    bool _isShooted;
    public GameObject viewFinder;
    GameObject viewFinderClone;

    private void Awake()
    {
        _fireRate = fireRate;
    }

    private void Start()
    {

        //Create clone view finder
        if (viewFinder)
        {
            viewFinderClone = Instantiate(viewFinder, Vector3.zero, Quaternion.identity);
        }
    }
    public void ShowViewFinder(bool isShow)
    {
        Cursor.visible = !isShow;
        if (viewFinderClone)
        {
            viewFinderClone.SetActive(isShow);
        }
    }
    private void Update()
    {
        //Hide and show cursor mouse
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }


        // get location mouse, set direction shooting
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDir = Camera.main.transform.position - mousePos;



        //Normalize vector
        shootDir.Normalize();

        //show  draw ray in scene view
        Debug.DrawRay(mousePos, shootDir, Color.green);


        //Shoot , and set couting time reload bullet
        if (Input.GetMouseButtonDown(0) && !_isShooted)
        {
            Shot(mousePos);
        }
        if (_isShooted)
        {
            _fireRate -= Time.deltaTime;
            GameGUIManager.Ins.UpdateFireFilled(_fireRate / fireRate);
            if (_fireRate <= 0)
            {
                _isShooted = false;
                _fireRate = fireRate;
            }
        }

        // View finder move follow mouse location
        if (viewFinderClone)
        {
            viewFinderClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    //Handle shooting with raycast
    void Shot(Vector3 mousePos)
    {
        AudioController.Ins.PlaySound(AudioController.Ins.shooting);
        _isShooted = true;
        Vector3 shootDir = Camera.main.transform.position - mousePos;

        shootDir.Normalize();
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir);

        if (hits != null && hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if (hit.collider && (Vector2.Distance((Vector2)hit.collider.transform.position, (Vector2)mousePos) <= 0.4f))
                {
                    Bird bird = hit.collider.GetComponent<Bird>();
                    if (bird)
                    {
                        bird.Die();
                    }
                }
            }
        }
        CineController.Ins.ShakeTrigger();
    }

}
