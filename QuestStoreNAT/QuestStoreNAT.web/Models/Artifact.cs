﻿using System.ComponentModel.DataAnnotations;

namespace QuestStoreNAT.web.Models
{
    public class Artifact
    {
        public int Id { get; set; }

        public Type Type { get; set; }

        public CompletionStatus CompletionStatus { get; set; }

        [Required(ErrorMessage = "Name required")]
        [StringLength(20, ErrorMessage = "1 to 20 characters.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Description required")]
        [StringLength(255, ErrorMessage = "1 to 120 characters.", MinimumLength = 1)]
        public string Description { get; set; }
    }
}
