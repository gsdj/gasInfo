using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
   public interface IEntity
   {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      Guid Id { get; set; }

      [Column(TypeName = "Date")]
      DateTime Date { get; set; }
   }
}
