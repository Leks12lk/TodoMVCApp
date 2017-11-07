﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TodoMVCApp.Models
{
	public class Todo
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public bool IsDone { get; set; }

		public DateTime? DateAdded { get; set; }
		

		public Todo()
		{
			IsDone = false;
			DateAdded = DateTime.Now;
		}
	}
}