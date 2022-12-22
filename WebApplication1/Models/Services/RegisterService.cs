using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Models.Services
{
	public class RegisterService
	{
		private RegisterRepository repository = new RegisterRepository();
		public void Create(Register register)
		{

			var dataIndb = repository.FindByEmail(register.Email);	
			if (dataIndb != null)
			{
				throw new Exception("這個email報名過了");
			}
			register.CreatedTime = DateTime.Now;
			repository.Create(register);
		}
		public Register Find(int id)
		{
			Register register = repository.FindById(id);
			if (register == null)
			{
				throw new Exception("找不到指定的紀錄");
			}
			return register;
		}
	}
}