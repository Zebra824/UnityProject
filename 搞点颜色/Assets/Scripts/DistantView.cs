using UnityEngine;

public class DistantView : MonoBehaviour
{
    //public PhysicsCheck physicsCheck;
    public GameObject follow;
    public float scaleOffset;
    public bool isHorizontal = true;
    public bool isVertical = true;
    Vector2 pos;
    Vector2 followPos;
    private float offsetX;
    private float offsetY;
    public bool areGround;

    private void Start()

    {
        

        if (follow != null )
            followPos = follow.transform.localPosition;
    }


    void LateUpdate()
    {
        if (follow != null )
        {
            pos = transform.localPosition;

            if (isHorizontal)
            {
                offsetX = (follow.transform.localPosition.x - followPos.x) * scaleOffset;
                pos.x += offsetX;
            }

            if (isVertical )
            {
                pos.y += offsetY;
                offsetY = (follow.transform.localPosition.y - followPos.y) * scaleOffset;
            }

            transform.localPosition = pos;
            followPos = follow.transform.localPosition;
        }

    }
}