using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Api.Domain.Entities
{
    [Table("user")]
    public record User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Username")]
        [MaxLength(40)]
        public string UserName { get; set; }

    }
}
