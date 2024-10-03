using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Extras
{
    public static class ScreenObjectFinder
    {
        public static Vector3 GetRandomPointBeyondScreen(Camera camera, float spawnOffset, float minDistanceFromEdge)
        {
            var screenBottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
            var screenTopRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
            
            int side = Random.Range(0, 4);

            var spawnPosition = Vector3.zero;

            switch (side)
            {
                case 0:
                    spawnPosition = new Vector3(screenBottomLeft.x - spawnOffset,
                        Random.Range(screenBottomLeft.y + minDistanceFromEdge, screenTopRight.y - minDistanceFromEdge), 0);
                    break;
                case 1:
                    spawnPosition = new Vector3(screenTopRight.x + spawnOffset,
                        Random.Range(screenBottomLeft.y + minDistanceFromEdge, screenTopRight.y - minDistanceFromEdge), 0);
                    break;
                case 2:
                    spawnPosition =
                        new Vector3(
                            Random.Range(screenBottomLeft.x + minDistanceFromEdge, screenTopRight.x - minDistanceFromEdge),
                            screenBottomLeft.y - spawnOffset, 0);
                    break;
                case 3:
                    spawnPosition =
                        new Vector3(
                            Random.Range(screenBottomLeft.x + minDistanceFromEdge, screenTopRight.x - minDistanceFromEdge),
                            screenTopRight.y + spawnOffset, 0);
                    break;
            }

            return spawnPosition;
        }
        
        public static T FindNearestObjectOnScreen<T>(Camera camera, Transform searchStartPoint, bool includeInactive = false) where T : Component
        {
            T[] objectsToCheck = Object.FindObjectsOfType<T>(includeInactive);

            if (objectsToCheck == null || objectsToCheck.Length == 0)
            {
                Debug.LogError("No objects found in the scene.");
                return null;
            }

            T nearestObject = null;
            float minDistance = Mathf.Infinity;

            foreach (T obj in objectsToCheck)
            {
                if (obj == null) continue;

                Vector3 screenPoint = camera.WorldToViewportPoint(obj.transform.position);

                if (screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0)
                {
                    float distance = Vector3.Distance(searchStartPoint.position, obj.transform.position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestObject = obj;
                    }
                }
            }

            return nearestObject;
        }
    }
}