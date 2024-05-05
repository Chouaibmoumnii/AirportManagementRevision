namespace AirportManagementRevision.Domain;
using System.ComponentModel.DataAnnotations;

public class Periode
{
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime Debut { get; set; }
    [DataType(DataType.Date)]
    public DateTime Fin { get; set; }
    
    public virtual IList<Facture> Factures { get; set; }



}