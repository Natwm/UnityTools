using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RaycastExtension 
{
    public static RaycastHit[] ConeCastAll(this Physics physics, Vector3 origin, float maxRadius, Vector3 direction, float maxDistance, float coneAngle)
    {
        RaycastHit[] sphereCastHits = Physics.SphereCastAll(origin - new Vector3(0,0,maxRadius), maxRadius, direction, maxDistance);
        List<RaycastHit> coneCastHitList = new List<RaycastHit>();
        
        if (sphereCastHits.Length > 0)
        {
            for (int i = 0; i < sphereCastHits.Length; i++)
            {
                sphereCastHits[i].collider.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
                Vector3 hitPoint = sphereCastHits[i].point;
                Vector3 directionToHit = hitPoint - origin;
                float angleToHit = Vector3.Angle(direction, directionToHit);

                if (angleToHit < coneAngle)
                {
                    coneCastHitList.Add(sphereCastHits[i]);
                }
            }
        }

        RaycastHit[] coneCastHits = new RaycastHit[coneCastHitList.Count];
        coneCastHits = coneCastHitList.ToArray();

        return coneCastHits;
    }

    public static void DrawRayCast(Vector3 start, Vector3 direction, float distance = 1)
    {
        Debug.DrawRay(start,direction * distance);
    }


    #region Raycast3D

    public static bool IsRaycastTouch(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, distance, layer))
        {
            return hitInfo.collider != null;
        }

        return false;
    }
    
    public static RaycastHit GetHitInfoFromRaycast(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, distance, layer))
        {
            return hitInfo;
        }
        
        return default;
    }
    
    public static RaycastHit[] GetColliderFromAllRaycast(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        var result = Physics.RaycastAll(origin, direction, distance, layer);
        if (result != null)
        {
            return result;
        }
        
        Debug.LogError("there is nothing !");
        return default;
    }
    
    public static Collider GetColliderFromRaycast(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, distance, layer))
        {
            return hitInfo.collider;
        }
        
        return default;
    }
    
    public static GameObject GetGameObjectFromRaycast(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, distance, layer))
        {
            return hitInfo.collider.gameObject;
        }
        
        return default;
    }

    #endregion

    #region Distance

    public static float GetFirstHitDistance(this Ray ray, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask, queryTriggerInteraction)) {
            return hit.distance;
        }
        return -1f;
    }

    // Méthode pour obtenir toutes les distances des GameObject touchés par un raycast
    public static float[] GetAllHitDistances(this Ray ray, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask, queryTriggerInteraction);
        float[] hitDistances = new float[hits.Length];
        for (int i = 0; i < hits.Length; i++) {
            hitDistances[i] = hits[i].distance;
        }
        return hitDistances;
    }

    #endregion

    #region HitPoint

    // Méthode pour obtenir le point d'impact du premier GameObject touché par un raycast
    public static Vector3 GetFirstHitPoint(this Ray ray, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask, queryTriggerInteraction)) {
            return hit.point;
        }
        return Vector3.zero;
    }

    // Méthode pour obtenir tous les points d'impact des GameObject touchés par un raycast
    public static Vector3[] GetAllHitPoints(this Ray ray, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask, queryTriggerInteraction);
        Vector3[] hitPoints = new Vector3[hits.Length];
        for (int i = 0; i < hits.Length; i++) {
            hitPoints[i] = hits[i].point;
        }
        return hitPoints;
    }
    #endregion

    #region Normal

    // Méthode pour obtenir la normale du premier GameObject touché par un raycast
    public static Vector3 GetFirstHitNormal(this Ray ray, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask, queryTriggerInteraction)) {
            return hit.normal;
        }
        return Vector3.zero;
    }

    // Méthode pour obtenir toutes les normales des GameObject touchés par un raycast
    public static Vector3[] GetAllHitNormals(this Ray ray, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask, queryTriggerInteraction);
        Vector3[] hitNormals = new Vector3[hits.Length];
        for (int i = 0; i < hits.Length; i++) {
            hitNormals[i] = hits[i].normal;
        }
        return hitNormals;
    }

    #endregion
    
// Méthode pour obtenir le GameObject le plus proche touché par un raycast
    public static GameObject GetClosestHitObject(this Ray ray, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask, queryTriggerInteraction);
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;
        foreach (RaycastHit hit in hits) {
            float distance = Vector3.Distance(ray.origin, hit.point);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestObject = hit.collider.gameObject;
            }
        }
        return closestObject;
    }


    #region Raycast2D
    
    public static bool IsRaycast2DTouch(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        return Physics2D.Raycast(origin, direction, distance, layer);
    }
    
    public static RaycastHit2D GetFirstHitInfoFromRaycast2D(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        var collider = Physics2D.Raycast(origin, direction, distance, layer);

        if (collider != null)
            return collider;

        Debug.LogError("No Hit");
        return default;
    }
    
    public static Collider2D GetCollider2DFromRaycast2D(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        var collider = Physics2D.Raycast(origin, direction, distance, layer);

        if (collider != null)
            return collider.collider;
        
        return default;
    }
    
    public static GameObject GetGameObjectFromRaycast2D(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        var collider = Physics2D.Raycast(origin, direction, distance, layer);

        if (collider != null)
            return collider.collider.gameObject;
        
        return default;
    }
    
    public static RaycastHit2D[] GetAllColliderFromRayCast2D(Vector3 origin, Vector3 direction, float distance, LayerMask layer)
    {
        var colliders = Physics2D.RaycastAll(origin, direction, distance, layer);
        if (colliders != null)
            return colliders;
        
        Debug.LogError("There is no element");
        return default;
    }
    
    #endregion

    #region Sphere Cast

    public static bool ThereIsElementInsideThisSphereCast(Vector3 origin,Vector3 direction,float radius)
    {
        Ray ray = new Ray(origin, direction);
        return Physics.SphereCast(ray, radius);
    }

    public static bool ThereIsElementInsideThisSphereCast(Vector3 origin,Vector3 direction,float radius, float maxDistance)
    {
        Ray ray = new Ray(origin, direction);
        return Physics.SphereCast(ray, radius,maxDistance);
    }
    
    public static bool ThereIsElementInsideThisSphereCast(Vector3 origin,Vector3 direction,float radius, float maxDistance, LayerMask layer)
    {
        Ray ray = new Ray(origin, direction);
        return Physics.SphereCast(ray, radius,maxDistance,layer);
    }

    public static RaycastHit GetAnElementInsideThisSphereCast(Vector3 origin,Vector3 direction,float radius, float maxDistance, LayerMask layer)
    {
        Ray ray = new Ray(origin, direction);
        Physics.SphereCast(ray, radius,out RaycastHit hitInfo,maxDistance,layer);
        if (hitInfo.collider != null)
            return hitInfo;

        Debug.LogError("There is no element inside the circle");
        return default;
    }
    
    public static RaycastHit[] GetAllElementInsideThisSphereCast(Vector3 origin,Vector3 direction,float radius, float maxDistance, LayerMask layer)
    {
        Ray ray = new Ray(origin, direction);
        var hitInfo = Physics.SphereCastAll(ray, radius,maxDistance,layer);
        if (hitInfo.Length > 0 )
            return hitInfo;

        Debug.LogError("There is no element inside the circle");
        return default;
    }
    
    public static RaycastHit GetLastElementInsideThisSphereCast(Vector3 origin,Vector3 direction,float radius, float maxDistance, LayerMask layer)
    {
        Ray ray = new Ray(origin, direction);
        var hitInfo = Physics.SphereCastAll(ray, radius,maxDistance,layer);
        if (hitInfo.Length > 0 )
            return hitInfo[hitInfo.Length];
        
        Debug.LogError("There is no element inside the circle");
        return default;
    }

    #endregion
    
    #region Box Cast

    public static bool ThereIsElementInsideThisBoxCast(Vector3 origin,Vector3 direction,float radius)
    {
        Ray ray = new Ray(origin, direction);
        return Physics.SphereCast(ray, radius);
    }

    public static bool ThereIsElementInsideThisBoxCast(Vector3 origin,Vector3 direction,Vector3 halfValue)
    {
        Ray ray = new Ray(origin, direction);
        return Physics.BoxCast(origin, halfValue,direction);
    }
    
    public static bool ThereIsElementInsideThisBoxCast(Vector3 origin,Vector3 direction,Vector3 halfValue,Quaternion rotation,float maxDistance, LayerMask layer)
    {
        Ray ray = new Ray(origin, direction);
        return Physics.BoxCast(origin, halfValue,direction,rotation,maxDistance,layer);
    }

    public static RaycastHit[] GetAllElementInsideThisBoxCast(Vector3 origin,Vector3 direction,Vector3 halfValue,Quaternion rotation,float maxDistance, LayerMask layer)
    {
        var hitInfo = Physics.BoxCastAll(origin, halfValue,direction,rotation,maxDistance,layer);
        if (hitInfo.Length > 0 )
            return hitInfo;

        Debug.LogError("There is no element inside the circle");
        return default;
    }
    
    public static RaycastHit GetLastElementInsideThisBoxCast(Vector3 origin,Vector3 direction,Vector3 halfValue,Quaternion rotation,float maxDistance, LayerMask layer)
    {
        var hitInfo = Physics.BoxCastAll(origin, halfValue,direction,rotation,maxDistance,layer);
        if (hitInfo.Length > 0 )
            return hitInfo[hitInfo.Length];
        
        Debug.LogError("There is no element inside the circle");
        return default;
    }

    #endregion
    
}
