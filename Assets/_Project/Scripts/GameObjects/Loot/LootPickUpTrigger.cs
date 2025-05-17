

public class JumpToMovingTarget
{
    /*[SerializeField] private GameObject _pickUpPrefab;
    public float jumpPower = 2f;
    public float jumpDuration = 1f;

    private Transform target;
    private bool isAsd;
    private TweenerCore<Quaternion, Vector3, QuaternionOptions> tween;
    private TweenerCore<float, float, FloatOptions> tween2;
    private Sequence scaleAndRotate;

    private void OnDisable()
    {
        tween?.Kill();
        tween2?.Kill();
        scaleAndRotate.Kill();
    }

    public void JumpTo(Transform playerTransform)
    {
        target = playerTransform;
        Vector3 startPos = transform.position;
        Vector3 originalScale = transform.localScale;
        Vector3 enlargedScale = originalScale * 1.7f;

        float elapsed = 0f;

        // Анимация движения (слежение за игроком и парабола)
        tween2 = DOTween.To(() => 0f, x =>
            {
                elapsed = x;

                Vector3 currentTargetPos = target.position;
                Vector3 newPos = Vector3.Lerp(startPos, currentTargetPos, x / jumpDuration);
                float yOffset = jumpPower * Mathf.Sin(Mathf.PI * (x / jumpDuration));
                newPos.y += yOffset;

                transform.position = newPos;
            }, jumpDuration, jumpDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                GameObject go = Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
                go.transform.SetParent(playerTransform.transform);
                tween.Kill();
                tween2.Kill();
                scaleAndRotate.Kill();
                Destroy(gameObject);
            });

        // Scale + Rotation анимация
        scaleAndRotate = DOTween.Sequence();

        // Масштаб: увеличение и уменьшение
        scaleAndRotate.Append(transform.DOScale(enlargedScale, jumpDuration / 2f).SetEase(Ease.OutQuad));
        scaleAndRotate.Append(transform.DOScale(Vector3.zero, jumpDuration / 2f).SetEase(Ease.InQuad));

        // Вращение: по всем осям (360° на протяжении всего прыжка)
        tween = transform.DORotate(new Vector3(0, 360, 360), jumpDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAsd) return;

        if (other.TryGetComponent<PlayerTransform>(out PlayerTransform playerTransform))
        {
            isAsd = true;
            JumpTo(playerTransform.transform);
        }
    }*/
}