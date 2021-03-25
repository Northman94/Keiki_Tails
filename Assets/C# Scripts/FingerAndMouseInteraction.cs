using UnityEngine;


//Code dedicated to Mouse (LMB) & Finger with screen interaction
namespace Interaction
{
    public class FingerAndMouseInteraction : MonoBehaviour
    {
        private string tailTag;

        TailsManager tm = new TailsManager();

        Vector2 interactionPosition;
        Collider2D coll;

        private GameObject selectedObjNameString;

        void Update()
        {
              // PC Mouse Interaction
            if (Input.GetMouseButtonDown(0) & Time.timeScale != 0)
            {
                interactionPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(interactionPosition, Vector2.zero, 0f);

                if (hit)
                {
                    Debug.Log(hit.transform.gameObject.name + " - LMB");
                    selectedObjNameString = hit.transform.gameObject;
                }

                coll = hit.collider.gameObject.GetComponent<Collider2D>();

                
                if (coll.OverlapPoint(interactionPosition))
                {
                    tailTag = coll.gameObject.tag;

                    //Tailsmamager tailTag check
                    tm.ObjectTagCheck(tailTag, selectedObjNameString);
                }
            }
                // Finger touch screen interaction
            else if (Input.touchCount == 1 & Time.timeScale != 0)
            {               
                interactionPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                RaycastHit2D hit = Physics2D.Raycast(interactionPosition, Vector2.zero, 0f);

                if (hit)
                {
                    Debug.Log(hit.transform.gameObject.name + " - Fingerprint");                  
                    selectedObjNameString = hit.transform.gameObject;
                }

                coll = hit.collider.gameObject.GetComponent<Collider2D>();
               

                Vector2 touchPos = new Vector2(interactionPosition.x, interactionPosition.y);

                
                if (coll == Physics2D.OverlapPoint(touchPos))
                {
                    tailTag = coll.gameObject.tag;

                    //Tailsmamager tailTag check
                    tm.ObjectTagCheck(tailTag, selectedObjNameString);
                }
            }
        }
    }
}