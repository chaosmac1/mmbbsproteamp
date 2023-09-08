namespace SensorLib.Record; 

public struct GraphRows {
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public List<GraphRow> Rows { get; set; }
}