using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public interface Interactable
    {
        void Touched(Vector3 point);
    }

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch(Input.touches[0].position);
        }
        else if (Application.isEditor && Input.GetMouseButtonUp(0))
        {
            Touch(Input.mousePosition);
        }
    }

    private void Touch(Vector2 pos)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(pos), out hitInfo, 100f))
        {
            var interactable = hitInfo.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Touched(hitInfo.point);
            }
        }
    }
}