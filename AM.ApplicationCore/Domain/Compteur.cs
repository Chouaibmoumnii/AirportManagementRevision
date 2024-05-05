namespace AirportManagementRevision.Domain;
using System.ComponentModel.DataAnnotations;

public class Compteur
{
    
    [Key]
    public int Reference { get; set; }
    public float Voltage { get; set; }
    public long Index { get; set; }
    public TypeCompteur Type { get; set; }
    
    public Abonne Abonnes { get; set; }
    public virtual IList<Facture> Factures { get; set; }


    

}