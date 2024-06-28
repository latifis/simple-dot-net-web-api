using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("mst_office")]
    public class MstOffice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameDeptHead { get; set; }

        public string? Alamat { get; set; }

    }
}
