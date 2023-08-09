namespace FinalBlog.Services.ViewModels
{
    /// <summary>
    /// ������ ������������� ��� ���������� �������� ������ ��� �������������
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}