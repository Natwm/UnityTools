using System.Linq;
using UnityEngine;

public static class ColliderExtensions
{
    /// <summary>
    /// Définit si le collider est actif ou inactif.
    /// </summary>
    /// <param name="collider">Le collider concerné</param>
    /// <param name="isActive">Indique si le collider doit être actif</param>
    public static void SetActive(this Collider collider, bool isActive)
    {
        collider.enabled = isActive;
    }

    /// <summary>
    /// Obtient le centre du collider en prenant en compte sa position et son décalage local.
    /// </summary>
    /// <param name="collider">Le collider concerné</param>
    /// <returns>Le centre du collider dans le monde</returns>
    public static Vector3 GetWorldCenter(this Collider collider)
    {
        return collider.transform.TransformPoint(collider.GetWorldCenter());
    }

    /// <summary>
    /// Obtient la taille du collider en prenant en compte son échelle locale.
    /// </summary>
    /// <param name="collider">Le collider concerné</param>
    /// <returns>La taille du collider dans le monde</returns>
    public static Vector3 GetWorldSize(this Collider collider)
    {
        return Vector3.Scale(collider.bounds.size, collider.transform.lossyScale);
    }

    /// <summary>
    /// Déplace le collider vers une nouvelle position.
    /// </summary>
    /// <param name="collider">Le collider concerné</param>
    /// <param name="position">La nouvelle position</param>
    public static void MoveTo(this Collider collider, Vector3 position)
    {
        collider.transform.position = position;
    }
    
        /// <summary>
        /// Détermine si le collider intersecte un autre collider spécifié.
        /// </summary>
        /// <param name="collider">Le collider concerné</param>
        /// <param name="otherCollider">L'autre collider à tester l'intersection</param>
        /// <returns>True si les colliders s'intersectent, sinon False</returns>
        public static bool Intersects(this Collider collider, Collider otherCollider)
        {
            return collider.bounds.Intersects(otherCollider.bounds);
        }
    
        /// <summary>
        /// Détermine si le collider est entièrement à l'intérieur d'un autre collider spécifié.
        /// </summary>
        /// <param name="collider">Le collider concerné</param>
        /// <param name="otherCollider">L'autre collider pour le test d'inclusion</param>
        /// <returns>True si le collider est entièrement inclus, sinon False</returns>
        public static bool IsFullyInside(this Collider collider, Collider otherCollider)
        {
            return otherCollider.bounds.Contains(collider.bounds.min) && otherCollider.bounds.Contains(collider.bounds.max);
        }

        /// <summary>
        /// Obtient le(s) GameObject(s) à l'intérieur du collider qui correspondent à un certain tag.
        /// </summary>
        /// <param name="collider">Le collider concerné</param>
        /// <param name="tag">Le tag pour filtrer les GameObjects</param>
        /// <returns>Un tableau de GameObjects à l'intérieur du collider correspondant au tag</returns>
        public static GameObject[] GetGameObjectsWithTag(this Collider collider, string tag)
        {
            Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask(tag));
            return colliders.Select(c => c.gameObject).ToArray();
        }
}
