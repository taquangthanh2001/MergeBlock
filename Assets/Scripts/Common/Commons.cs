using UnityEngine;

public static class Commons
{
    public static void CalculateAngleByTargetDirection(Transform transform, Vector3 targetPos)
    {
        Vector3 relative = transform.InverseTransformPoint(targetPos);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        transform.Rotate(0, angle, 0);
    }
    public static float CalculateSpeed(float speed)
    {
        return speed / 2 * Time.deltaTime;
    }
}
