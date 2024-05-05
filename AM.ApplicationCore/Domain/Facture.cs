namespace AirportManagementRevision.Domain;
using System.ComponentModel.DataAnnotations;

public class Facture
{
    public DateTime Date { get; set; }
    public float Montant { get; set; }
    [Range(1,9999, ErrorMessage ="ConsommationKWH doit etre positif.")]
    public int ConsommationKWH { get; set; }
    public bool Payement { get; set; }
    
    
    public virtual Compteur Compteur { get; set; }
    public virtual Periode Periode { get; set; }
    
    public int CompteurKey { get; set; }
   
    public int PeriodeKey { get; set; }

}