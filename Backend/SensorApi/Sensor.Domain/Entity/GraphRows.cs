using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class GraphRows: Sensor.Domain.Model.Entity<Guid> {
    private class Box<T> where T: notnull  {
        public T V { get; set; }
        
        public Box(T v) {
            V = v;
        }
    }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required List<GraphRow> Rows { get; set; }

    public GraphRows(Guid id) : base(id) => Id = id;

    public GraphRows MergeByUseDate() {
        Box<long> iter = new Box<long>(0);
        
        var dic = new Dictionary<DateTime, List<GraphRow>>(Rows.Count);
        foreach (var graphRow in this.Rows) {
            if (!dic.TryGetValue(graphRow.UseDate, out var row)) {
                row = new List<GraphRow>(2);
            }
            row.Add(graphRow);
        }

        var rows = dic
                   .Select(x=>x.Value)
                   .OrderBy(x => x)
                   .Select(x => {
                       
                           var first = x[0]!;
            
                           var result = new GraphRow(new GraphRowId() { Value = iter.V }) {
                               Time = first.Time,
                               DeviceId = new IotId { Value = Guid.Empty },
                               ValueKelvin = new Kelvin() { Value = x.Average(x => x.ValueKelvin.Value) },
                           };
                           iter.V += 1;
                           return result; 
                       }
                   );


        return new GraphRows(Guid.NewGuid()) {
            Start = this.Start,
            End = this.End,
            Rows = rows.ToList()
        };
    }
}