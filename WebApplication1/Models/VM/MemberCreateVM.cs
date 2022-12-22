using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebApplication1.Models.DTO;

namespace WebApplication1.Models.VM
{
	public class MemberCreateVM
	{
		//public int id { get; set; }
		[Display(Name= "中文姓名")]
		[Required(ErrorMessage ="{0}必填")]
		[StringLength(30,ErrorMessage ="{0}不能超過{1}個字")]
		public string Name { get; set; }
		[Display(Name = "帳號")]
		[Required]
		[StringLength(30)]
		public string Account { get; set; }
		[Display(Name = "密碼")]
		[Required]
		[StringLength(30)]
		public string Password { get; set; }
		[Compare("Password")]
		[Display(Name = "確認密碼")]
		[Required]
		[StringLength(30)]
		public string ConfirmPassword { get; set; }
		[Display(Name = "手機")]
		[StringLength(10)]
		public string Cellphone { get; set; }
    }
    public static class MemberCreateVMExts
    {
        public static MemberCreateDTO ToDto(this MemberCreateVM model)
        {
            return new MemberCreateDTO
            {
                Name = model.Name,
                Account = model.Account,
                Password = model.Password,
                Cellphone = model.Cellphone,

            };
        }
    }

}