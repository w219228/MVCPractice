using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DTO;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Services;

namespace WebApplication1.Models.Repositories
{
    public class MemberRepository : IMemberRepository
    {
		private AppDbContext db;
		public MemberRepository()
		{
			db = new AppDbContext();
		}
		public void Create(MemberCreateDTO dto)
        {
            Member member = new Member { 
            Name= dto.Name,
            Account= dto.Account,
			Password= dto.Password,
			Cellphone= dto.Cellphone,
            };
			db.Members.Add(member);
			db.SaveChanges();

        }
		public Member FindByAccount(string account)
		{
			return db.Members.FirstOrDefault(x => x.Account == account);
		}
	}
}