namespace Domain.Entities
{
    public class GateAccess
    {
        public long Id { get; set; }

        public required string Gate { get; set; }

        public DateTime Timestamp { get; set; }

        public int NumberOfPeople { get; set; }

        public GateAccessType Type { get; set;  }
    }
}
