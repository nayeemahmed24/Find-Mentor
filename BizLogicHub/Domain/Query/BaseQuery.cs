namespace Domain.Query
{
    public class BaseQuery
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();

        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set;} = 10;
    }
}
