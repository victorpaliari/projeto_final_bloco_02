﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projeto_final_bloco_02.Model
{
    public class Produto : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5,2)")]
        //[Decimal(5, 2)]

        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Foto { get; set; } = string.Empty;

    }
}
