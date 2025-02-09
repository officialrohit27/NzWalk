using System;
using System.ComponentModel.DataAnnotations;


namespace NzWalkApi.Models.DTO
{
	public class AddRegionDto
	{
        [Required]
        [MaxLength(100, ErrorMessage ="Name has to be maximum 100 character")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Code has to be minimum 3 charater")]
        [MaxLength(3, ErrorMessage = "Code can be maximum 3 character")]
        public string Code { get; set; }

        public string? RegionImageURL { get; set; }
    }
}

