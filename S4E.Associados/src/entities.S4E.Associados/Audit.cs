namespace entities.S4E.Associados;

public class Audit
{
    public bool IsActive { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedWhen { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTime? UpdatedWhen { get; set; }
}
