﻿using System.ComponentModel.DataAnnotations;

namespace DashbordMangment.Models
{
	public class User
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
