using UnityEngine;

namespace UnityTemplateProjects.Utils
{
    public static class VectorExtensions
    {
        /// <summary>
        /// Takes a Vector2 and converty it to a XZY Vector3
        /// </summary>
        /// <param name="vector">The Vector to transform</param>
        /// <returns>Transformed Vector, example: Vector2(1, 1) => Vector3(1, 0, 1)</returns>
        public static Vector3 ToXZVector(this Vector2 vector) => new Vector3(vector.x, 0f, vector.y);
    }
}