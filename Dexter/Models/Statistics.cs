namespace Dexter.Models
{
    public enum TypeOfChart
    {
        PieChart,
        BarChart
    }
    public class DexterChart
    {
        public string? ChartId { get; set; }
        public TypeOfChart ChartType { get; set; }
        public bool Is3D { get; set; } // Applies to Pie Chart
        public string? ChartLabel { get; set; }
        public string? ChartTitle { get; set; }
        public List<string> XAxisValues { get; set; }
        public string XLabel { get; set; }
        public List<int> YAxisValues { get; set; }
        public string? YLabel { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class Statistics
    {
        private List<DexterChart> _data;
        public List<DexterChart> Data { get => _data; }
        public Statistics()
        {
            _data = new List<DexterChart>();
        }
        public void AddDexterChart(DexterChart chart)
        {
            this._data.Add(chart);
        }
    }
}
