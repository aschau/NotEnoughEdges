using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement player;
    public Vector2 focusAreaSize;
    public float verticalOffset;
    public float verticalSmoothTime;
    public bool showFocusArea = false;

    FocusArea focusArea;

    float smoothVelocityY;

    struct FocusArea
    {
        public Vector2 center;
        float left, right, top, bottom;

        public FocusArea(Vector2 targetPos, Vector2 size)
        {
            left = targetPos.x - size.x / 2;
            right = targetPos.x + size.x / 2;
            bottom = targetPos.y;
            top = targetPos.y + size.y;

            center = targetPos;
        }

        public void Update(Vector2 targetPos)
        {
            float shiftX = 0;
            float shiftY = 0;
            if (targetPos.x < left)
            {
                shiftX = targetPos.x - left;

            }
            else if (targetPos.x > right)
            {
                shiftX = targetPos.x - right;
            }
            left += shiftX;
            right += shiftX;

            if (targetPos.y < bottom)
            {
                shiftY = targetPos.y - bottom;

            }
            else if (targetPos.y > top)
            {
                shiftY = targetPos.y - top;
            }
            top += shiftY;
            bottom += shiftY;

            center += new Vector2(shiftX, shiftY);
        }
    }

    void Start()
    {
        focusArea = new FocusArea(player.transform.position, focusAreaSize);
    }

    void LateUpdate()
    {
        focusArea.Update(player.transform.position);

        Vector2 focusPosition = focusArea.center + Vector2.up * verticalOffset;
        focusPosition.y = Mathf.SmoothDamp(this.transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
        this.transform.position = (Vector3)focusPosition + Vector3.forward * -10;
    }

    void OnDrawGizmos()
    {
        if (showFocusArea)
        {
            Gizmos.color = new Color(1, 0, 0, .5f);
            Gizmos.DrawCube(focusArea.center, focusAreaSize);
        }
    }
}
