namespace TodoListBlazorWeb.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        private string test = "";
        private void IncrementCount()
        {
            currentCount++;
            test = "Số " + currentCount.ToString();
        }
    }
}
