namespace PruebaPracticaGISSA.Data
{
    public class ToastOption
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public class ToastService
    {
        public event Action<ToastOption> ShowToastTrigger;
        public void ShowToast(ToastOption options)
        {
            this.ShowToastTrigger.Invoke(options);
        }
    }
}
