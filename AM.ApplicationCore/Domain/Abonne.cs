using System.ComponentModel.DataAnnotations;

namespace AirportManagementRevision.Domain;

public class Abonne
{
    [Key]
    public string CIN { get; set; }
    [Required]
    public string Nom { get; set; }
    [Required]
    public string Prenom { get; set; }
    
    public IList<Compteur> Compteurs { get; set; }


}