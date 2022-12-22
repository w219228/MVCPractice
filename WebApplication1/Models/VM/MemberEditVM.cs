using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.VM
{
	public class MemberEditVM
	{
		public int Id { get; set; }
		[Display(Name = "姓名")]
		[Required]
		[StringLength(30)]
		public string Name { get; set; }
		[Display(Name = "手機")]
		[StringLength(10)]
		public string Cellphone { get; set; }
	}
}