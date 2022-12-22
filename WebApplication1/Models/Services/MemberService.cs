using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DTO;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.Services
{
    public class MemberService
    {
        private IMemberRepository repository;
        public MemberService(IMemberRepository repo)
        {
            repository= repo;
        }
        public void Create(MemberCreateDTO dto)
        {
			var dataIndb = repository.FindByAccount(dto.Account);
			if (dataIndb != null)
			{
				throw new Exception("這個帳號註冊過了");
			}
			repository.Create(dto);
        }
    }
}