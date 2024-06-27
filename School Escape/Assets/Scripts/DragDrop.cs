using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private Vector3 offset;
    private Vector3 screenPoint;

    public Transform targetPosition; // The target position where the object should snap to
    public float snapDistance = 0.5f; // The distance within which the object will snap to the target position
    public int partOrder; // The order of this part in the assembly process
    public static int currentOrder = 1; // The current order part that needs to be placed
    public Animator openbox;

    void Update()
    {
        if (isDragging)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            transform.position = currentPosition;
        }
    }

    void OnMouseDown()
    {
        // Check if this part is the next one to be placed
        if (partOrder == currentOrder)
        {
            isDragging = true;
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            startPosition = transform.position;
        }
    }

    void OnMouseUp()
    {
        if (!isDragging)
            return;

        isDragging = false;

        // Check if the object is close enough to the target position
        float distance = Vector3.Distance(transform.position, targetPosition.position);
        if (distance <= snapDistance)
        {
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
            currentOrder++; // Update the order to the next part
            if (currentOrder>15){
                openbox.Play("OpenBoxCabInfo");
            }
        }
        else
        {
            transform.position = startPosition; // Reset to the start position if not close enough
        }
    }
}
