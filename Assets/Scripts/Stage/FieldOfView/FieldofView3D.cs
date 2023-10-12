using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ViewCastInfo
{
    public bool hit;
    public Vector3 point;
    public float dist;
    public float angle;

    public ViewCastInfo(bool _hit, Vector3 _point, float _dist, float _angle)
    {
        hit = _hit;
        point = _point;
        dist = _dist;
        angle = _angle;
    }

}

public struct Edge
{
    public Vector3 PointA, PointB;
    public Edge(Vector3 _PointA, Vector3 _PointB)
    {
        PointA = _PointA;
        PointB = _PointB;
    }
}

public class FieldofView3D : MonoBehaviour
{
    // �þ� ������ �������� �þ� ����
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    // ����ũ 2��
    public LayerMask targetMask, obstacleMask;

    // Target mask�� ray hit�� transform�� �����ϴ� ����Ʈ
    public List<Transform> visibleTargets = new List<Transform>();
    public float meshResolution;

    private Mesh viewMesh;
    public MeshFilter viewMeshFilter;

    public int edgeResolveIterations;
    public float edgeDstThreshold;
    private Transform trPlayer;
    List<GameObject> lstViewMonster = new List<GameObject>();

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    Edge FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            float angle = minAngle + (maxAngle - minAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);
            bool edgeDstThresholdExceed = Mathf.Abs(minViewCast.dist - newViewCast.dist) > edgeDstThreshold;
            if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceed)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new Edge(minPoint, maxPoint);
    }

    private void HideTarget()//CompoerisionVisibleTarget(Collider[] targets)
    {
        foreach (Transform target in visibleTargets)
            target.gameObject.layer = LayerMask.NameToLayer("Target");
        //if (targets.Length <= 0)
        //{
        //    foreach (Transform target in visibleTargets)
        //    {
        //        target.gameObject.layer = LayerMask.NameToLayer("Target");
        //    }
        //}
        //List<GameObject> targetList = new List<GameObject>();
        //for (int i = 0; i < targets.Length; i++)
        //{
        //    targetList.Add(targets[i].gameObject);
        //}

        //for (int i = 0; i < visibleTargets.Count; i++)
        //{
        //    if (!targetList.Contains(visibleTargets[i].gameObject))
        //    {
        //        visibleTargets[i].gameObject.layer = LayerMask.NameToLayer("Target");
        //    }
        //}

    }


    private void FindVisibleTargets()
    {
        // viewRadius�� ���������� �� �� ���� �� targetMask ���̾��� �ݶ��̴��� ��� ������
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        HideTarget();
        visibleTargets.Clear();

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            // �÷��̾�� forward�� target�� �̷�� ���� ������ ���� �����
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                // Ÿ������ ���� ����ĳ��Ʈ�� obstacleMask�� �ɸ��� ������ visibleTargets�� Add
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    target.gameObject.layer = LayerMask.NameToLayer("VisibleTarget");

                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Cos((-angleDegrees + 90) * Mathf.Deg2Rad), 0, Mathf.Sin((-angleDegrees + 90) * Mathf.Deg2Rad));
    }

    private ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
        {
            //if (hit.collider.gameObject.layer != LayerMask.NameToLayer("VisibleObstacle"));
            //hit.collider.gameObject.layer = LayerMask.NameToLayer("VisibleObstacle");
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }

    private void DrawFieldofView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo prevViewCast = new ViewCastInfo();

        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);

            // i�� 0�̸� prevViewCast�� �ƹ� ���� ���� ���� ������ �� �� �����Ƿ� �ǳʶڴ�.
            if (i != 0)
            {
                bool edgeDstThresholdExceed = Mathf.Abs(prevViewCast.dist - newViewCast.dist) > edgeDstThreshold;

                // �� �� �� raycast�� ��ֹ��� ������ �ʾҰų� �� raycast�� ���� �ٸ� ��ֹ��� hit �� ���̶��(edgeDstThresholdExceed ���η� ���)
                if (prevViewCast.hit != newViewCast.hit || (prevViewCast.hit && newViewCast.hit && edgeDstThresholdExceed))
                {
                    Edge e = FindEdge(prevViewCast, newViewCast);

                    // zero�� �ƴ� ������ �߰���
                    if (e.PointA != Vector3.zero)
                    {
                        viewPoints.Add(e.PointA);
                    }

                    if (e.PointB != Vector3.zero)
                    {
                        viewPoints.Add(e.PointB);
                    }
                }
            }

            viewPoints.Add(newViewCast.point);
            prevViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];
        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    // Start is called before the first frame update
    void Start()
    {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        if (StageManager.Instance.player != null)
        { 
            trPlayer = StageManager.Instance.player.transform;
            transform.position = trPlayer.position + Vector3.up*0.5f;
        }
        else
            trPlayer = GameObject.FindWithTag("PLAYER").transform;
        // 0.2�� �������� �ڷ�ƾ ȣ��
        StartCoroutine(FindTargetsWithDelay(0.2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (trPlayer.gameObject != StageManager.Instance.player)
            trPlayer = StageManager.Instance.player.transform;
        transform.position = trPlayer.position + Vector3.up * 0.5f;
        DrawFieldofView();
    }
}
